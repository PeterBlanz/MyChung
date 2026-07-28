using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Dynastream.Fit;

namespace MyChung
{
    public partial class MainForm : Form
    {
        private readonly DensityForm _densForm = new DensityForm();

        public MainForm()
        {
            InitializeComponent();
            txtAirDens.Text = (1.2215).ToString();
            txtCrr.Text = (0.0028).ToString();
            txtMass.Text = (90.0).ToString();
            txtEff.Text = (98.0).ToString();
            txtTrimStart.Text = (0.0).ToString();
            txtTrimEnd.Text = (0.0).ToString();
            txtWindCalib.Text = (1.0).ToString();
            txtSpeedCalib.Text = (1.0).ToString();
        }

        private bool ParseParameters(out ChungParameters cp)
        {
            cp = new ChungParameters();

            // parse trim start
            if (!double.TryParse(txtTrimStart.Text, out double trimStart))
            {
                MessageBox.Show("Failed to parse trim start!");
                return false;
            }
            cp.TrimStart = trimStart;

            // parse trim end
            if (!double.TryParse(txtTrimEnd.Text, out double trimEnd))
            {
                MessageBox.Show("Failed to parse trim end!");
                return false;
            }
            cp.TrimEnd = trimEnd;

            // parse wind calibration factor
            if (!double.TryParse(txtWindCalib.Text, out double windCalib))
            {
                MessageBox.Show("Failed to parse wind calibration factor!");
                return false;
            }
            cp.WindCalib = windCalib;

            // parse speed calibration factor
            if (!double.TryParse(txtSpeedCalib.Text, out double speedCalib))
            {
                MessageBox.Show("Failed to parse speed calibration factor!");
                return false;
            }
            cp.SpeedCalib = speedCalib;

            // parse air density
            if (!double.TryParse(txtAirDens.Text, out double airDens))
            {
                MessageBox.Show("Failed to parse parameters!");
                return false;
            }
            cp.AirDensity = airDens;

            // parse mass
            if (!double.TryParse(txtMass.Text, out double mass))
            {
                MessageBox.Show("Failed to parse mass!");
                return false;
            }
            cp.Mass = mass;

            // parse crr
            if (!double.TryParse(txtCrr.Text, out double crr))
            {
                MessageBox.Show("Failed to parse crr!");
                return false;
            }
            cp.RollingResistance = crr;

            // parse drive train efficiency
            if (!double.TryParse(txtEff.Text, out double eff))
            {
                MessageBox.Show("Failed to parse drive train efficiency!");
                return false;
            }
            cp.Efficiency = eff;

            return true;
        }

        private Tuple<double, double> ProcessFitFile(string fileName, ChungParameters cp)
        {
            // create empty lists
            List<double> timeValues = new List<double>();
            List<double> distValues = new List<double>();
            List<double> powerValues = new List<double>();
            List<double> speedValues = new List<double>();
            List<double> windValues = new List<double>();

            // attempt to open .FIT file
            using (FileStream fitSource = new FileStream(fileName, FileMode.Open))
            {
                // use a FitListener to capture all decoded messages in a FitMessages object
                FitListener fitListener = new FitListener();
                Decode decoder = new Decode();
                decoder.MesgEvent += fitListener.OnMesg;
                decoder.Read(fitSource);

                // parse messages
                FitMessages fitMessages = fitListener.FitMessages;
                foreach (RecordMesg mesg in fitMessages.RecordMesgs)
                {
                    // add data
                    distValues.Add(mesg.Fields.FirstOrDefault(f => f.Name.ToLower() == "distance").ValueOrDefault(distValues));
                    timeValues.Add(mesg.Fields.FirstOrDefault(f => f.Name.ToLower() == "timestamp").ValueOrDefault(timeValues));
                    powerValues.Add(mesg.Fields.FirstOrDefault(f => f.Name.ToLower() == "power").ValueOrDefault(powerValues));
                    speedValues.Add(mesg.Fields.FirstOrDefault(f => f.Name.ToLower() == "speed").ValueOrDefault(speedValues));
                    windValues.Add(mesg.DeveloperFields.FirstOrDefault(f => f.Name.ToLower() == "wind").ValueOrDefault(windValues));
                }
            }

            // scale speed and distance
            if (cp.SpeedCalib != 1)
            {
                for (int i = 0; i < distValues.Count; i++)
                {
                    distValues[i] *= cp.SpeedCalib;
                    speedValues[i] *= cp.SpeedCalib;
                }
            }

            // trim
            if (cp.TrimStart > 0 || cp.TrimEnd > 0)
            {
                double maxDist = distValues[distValues.Count - 1] - cp.TrimEnd;
                for (int i = 0; i < distValues.Count; i++)
                {
                    if (distValues[i] < cp.TrimStart || distValues[i] > maxDist)
                    {
                        distValues.RemoveAt(i);
                        timeValues.RemoveAt(i);
                        powerValues.RemoveAt(i);
                        speedValues.RemoveAt(i);
                        windValues.RemoveAt(i);
                        i--;
                    }
                }
            }

            // pre-multiply power values
            double eff = cp.Efficiency * 0.01;
            for (int i = 0; i < powerValues.Count; i++) powerValues[i] *= eff;

            // scale wind values
            if(cp.WindCalib != 1)
            {
                for (int i = 0; i < windValues.Count; i++)
                    windValues[i] *= cp.WindCalib;
            }

            // analyze
            return DoChungAnalysis(timeValues, powerValues, speedValues, windValues, cp);
        }

        private double GetStandardDeviation(List<double> values)
        {
            double mean = values.Sum() / values.Count;

            double sumOfSquares = 0;
            foreach (double val in values)
            {
                double diff = val - mean;
                sumOfSquares += diff * diff;
            }

            return Math.Sqrt(sumOfSquares / (values.Count - 1));
        }

        private Tuple<double, double> DoChungAnalysis(List<double> timeValues, List<double> powerValues, List<double> speedValues, List<double> windValues, ChungParameters cp)
        {
            // solve CdA
            double CdA = 0.25;
            double totalVirtualElevation = GetTotalVirtualElevation(cp, CdA, timeValues, powerValues, speedValues, windValues);
            int iterationDirection = Math.Sign(totalVirtualElevation);
            for (int i = 0; i < 1000000; i++)
            {
                if (Math.Sign(totalVirtualElevation) != iterationDirection) break;
                CdA += iterationDirection * 0.000001;
                totalVirtualElevation = GetTotalVirtualElevation(cp, CdA, timeValues, powerValues, speedValues, windValues);
            }

            return Tuple.Create(timeValues[0], CdA);
        }

        private double GetTotalVirtualElevation(ChungParameters chungParams, double CdA, List<double> timeValues, List<double> powerValues, List<double> speedValues, List<double> windValues)
        {
            double totalVirtualElevation = 0;
            for (int i = 1; i < timeValues.Count - 1; i++)
            {
                totalVirtualElevation += GetVirtualElevation(chungParams, CdA, timeValues, powerValues, speedValues, windValues, i);
            }
            return totalVirtualElevation;
        }

        private double GetVirtualElevation(ChungParameters chungParams, double CdA, List<double> timeValues, List<double> powerValues, List<double> speedValues, List<double> windValues, int i)
        {
            // get parameters
            const double g = 9.81;
            double Crr = chungParams.RollingResistance;
            double m = chungParams.Mass;
            double rho = chungParams.AirDensity;

            // calculate acceleration
            double dt = timeValues[i + 1] - timeValues[i - 1];
            double a = (speedValues[i + 1] - speedValues[i - 1]) / dt;

            // calculate slope
            double v = speedValues[i];
            double va = v + windValues[i];
            double w = powerValues[i];
            double s = w / (m * g * v) - Crr - a / g - (rho * CdA * va * va) / (2 * m * g);

            // return virtual elevation
            return s * v * dt;
        }


        private void ButBrowseA_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Title = "Select FIT file", Filter = "FIT files|*.fit|All files|*.*" };
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK) txtFileNamesA.Text = string.Join("\r\n", ofd.FileNames);
        }

        private void ButBrowseB_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Title = "Select FIT file", Filter = "FIT files|*.fit|All files|*.*" };
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK) txtFileNamesB.Text = string.Join("\r\n", ofd.FileNames);
        }

        private void ButProcess_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (!ParseParameters(out ChungParameters cp)) return;

                // process list A
                string[] fileNamesA = txtFileNamesA.Text.Split('\n');
                List<Tuple<double, double>> resultsA = new List<Tuple<double, double>>();
                foreach (string fileName in fileNamesA)
                {
                    resultsA.Add(ProcessFitFile(fileName.Trim(), cp));
                }

                // process list B
                string[] fileNamesB = txtFileNamesB.Text.Split('\n');
                List<Tuple<double, double>> resultsB = new List<Tuple<double, double>>();
                foreach (string fileName in fileNamesB)
                {
                    resultsB.Add(ProcessFitFile(fileName.Trim(), cp));
                }

                // get results
                StringBuilder sb = new StringBuilder();
                int maxCount = Math.Max(resultsA.Count, resultsB.Count);
                for (int i = 0; i < maxCount; i++)
                {
                    // result A
                    if (i < resultsA.Count)
                    {
                        sb.Append(resultsA[i].Item1);
                        sb.Append('\t');
                        sb.Append(resultsA[i].Item2);
                    }
                    else sb.Append("0\t0");

                    // result B
                    if (i < resultsB.Count)
                    {
                        sb.Append('\t');
                        sb.Append(resultsB[i].Item1);
                        sb.Append('\t');
                        sb.Append(resultsB[i].Item2);
                    }
                    else sb.Append("\t0\t0");

                    sb.AppendLine();
                }

                Clipboard.SetText(sb.ToString());
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private class ChungParameters
        {
            public double Mass { get; set; }
            public double RollingResistance { get; set; }
            public double AirDensity { get; set; }
            public double TrimEnd { get; set; }
            public double TrimStart { get; set; }
            public double SpeedCalib { get; set; }
            public double WindCalib { get; set; }
            public double Efficiency { get; set; }
        }

        private void ButDens_Click(object sender, EventArgs e)
        {
            if (_densForm.ShowDialog(this) != DialogResult.OK) return;
            txtAirDens.Text = _densForm.AirDensity.ToString("0.0000");
        }
    }

    public static class FieldExtensions
    {
        public static double ValueOrDefault(this FieldBase field, List<double> values)
        {
            if (field != null) return Convert.ToDouble(field.GetValue());
            if (values.Count > 0) return values[values.Count - 1];
            else return 0.0;
        }
    }
}
