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

        private void ProcessFitFile(string fileName)
        {
            // create empty lists
            List<double> timeValues = new List<double>();
            List<double> distValues = new List<double>();
            List<double> powerValues = new List<double>();
            List<double> speedValues = new List<double>();
            List<double> windValues = new List<double>();

            // parse limits
            if (!double.TryParse(txtTrimStart.Text, out double trimStart) || !double.TryParse(txtTrimEnd.Text, out double trimEnd))
            {
                MessageBox.Show("Failed to parse trim limits!");
                return;
            }

            // parse wind calibration factor
            if (!double.TryParse(txtWindCalib.Text, out double windCalib))
            {
                MessageBox.Show("Failed to parse wind calibration factor!");
                return;
            }

            // parse speed calibration factor
            if (!double.TryParse(txtSpeedCalib.Text, out double speedCalib))
            {
                MessageBox.Show("Failed to parse speed calibration factor!");
                return;
            }

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

            // check data sets
            if (timeValues.Count != powerValues.Count || timeValues.Count != speedValues.Count || timeValues.Count != distValues.Count)
            {
                MessageBox.Show("Data set lengths must match!");
                return;
            }

            // scale
            if (speedCalib != 1)
            {
                for (int i = 0; i < distValues.Count; i++)
                {
                    distValues[i] *= speedCalib;
                    speedValues[i] *= speedCalib;
                }
            }

            // trim
            if (trimStart > 0 || trimEnd > 0)
            {
                double maxDist = distValues[distValues.Count - 1] - trimEnd;
                for (int i = 0; i < distValues.Count; i++)
                {
                    if (distValues[i] < trimStart || distValues[i] > maxDist)
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

            // analyze
            DoChungAnalysis(timeValues, powerValues, speedValues, windValues, windCalib);
        }

        private double Calibrate(List<double> timeValues, List<double> distValues, List<double> powerValues, List<double> speedValues, List<double> windValues, double windCalib)
        {
            // TEMP!! better splitting needed
            List<double> lapTimeValues = new List<double>();
            List<double> lapPowerValues = new List<double>();
            List<double> lapSpeedValues = new List<double>();
            List<double> lapWindValues = new List<double>();
            List<double> cdaValues = new List<double>();
            int threshold = 400;
            for (int i = 0; i < distValues.Count; i++)
            {
                lapTimeValues.Add(timeValues[i]);
                lapPowerValues.Add(powerValues[i]);
                lapSpeedValues.Add(speedValues[i]);
                lapWindValues.Add(windValues[i]);

                if (distValues[i] > threshold)
                {
                    cdaValues.Add(DoChungAnalysis(lapTimeValues, lapPowerValues, lapSpeedValues, lapWindValues, windCalib, true));
                    threshold += 400;
                    lapTimeValues.Clear();
                    lapPowerValues.Clear();
                    lapSpeedValues.Clear();
                    lapWindValues.Clear();
                }
            }

            cdaValues.RemoveAt(0);
            cdaValues.RemoveAt(cdaValues.Count - 1);
            double stdev = GetStandardDeviation(cdaValues);
            return stdev;
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

        private double DoChungAnalysis(List<double> timeValues, List<double> powerValues, List<double> speedValues, List<double> windValues, double windCalib, bool silent = false)
        {
            // parse parameters TODO: individual sanity checks
            if (!double.TryParse(txtAirDens.Text, out double airDens) || !double.TryParse(txtMass.Text, out double mass) || !double.TryParse(txtCrr.Text, out double crr) || !double.TryParse(txtEff.Text, out double eff))
            {
                MessageBox.Show("Failed to parse parameters!");
                return double.NaN;
            }

            // pre-multiply power values
            eff *= 0.01;
            for (int i = 0; i < powerValues.Count; i++) powerValues[i] *= eff;

            // solve CdA
            ChungParameters chungParams = new ChungParameters { AirDensity = airDens, Mass = mass, RollingResistance = crr, CdA = 0.25 };
            double totalVirtualElevation = GetTotalVirtualElevation(chungParams, timeValues, powerValues, speedValues, windValues, windCalib);
            int iterationDirection = Math.Sign(totalVirtualElevation);
            for (int i = 0; i < 1000000; i++)
            {
                if (Math.Sign(totalVirtualElevation) != iterationDirection) break;
                chungParams.CdA += iterationDirection * 0.000001;
                totalVirtualElevation = GetTotalVirtualElevation(chungParams, timeValues, powerValues, speedValues, windValues, windCalib);
            }

            // place result in clipboard, show message
            string cdaString = chungParams.CdA.ToString("0.00000");
            Clipboard.SetText($"{timeValues[0]}\t{cdaString}");
            if (!silent) MessageBox.Show($"CdA: {cdaString} m²\n\nResult has been copied into clipboard.");
            return chungParams.CdA;
        }

        private double GetTotalVirtualElevation(ChungParameters chungParams, List<double> timeValues, List<double> powerValues, List<double> speedValues, List<double> windValues, double windCalib)
        {
            double totalVirtualElevation = 0;
            for (int i = 1; i < timeValues.Count - 1; i++)
            {
                totalVirtualElevation += GetVirtualElevation(chungParams, timeValues, powerValues, speedValues, windValues, windCalib, i);
            }
            return totalVirtualElevation;
        }

        private double GetVirtualElevation(ChungParameters chungParams, List<double> timeValues, List<double> powerValues, List<double> speedValues, List<double> windValues, double windCalib, int i)
        {
            // get parameters
            const double g = 9.81;
            double Crr = chungParams.RollingResistance;
            double CdA = chungParams.CdA;
            double m = chungParams.Mass;
            double rho = chungParams.AirDensity;

            // calculate acceleration
            double dt = 0.5 * (timeValues[i + 1] - timeValues[i - 1]);
            double a = (speedValues[i + 1] - speedValues[i - 1]) / (2 * dt);

            // calculate slope
            double v = speedValues[i];
            double va = v + windCalib * windValues[i];
            double w = powerValues[i];
            double s = w / (m * g * v) - Crr - a / g - (rho * CdA * va * va) / (2 * m * g);

            // return virtual elevation
            return s * v * dt;
        }


        private void ButBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Title = "Select FIT file", Filter = "FIT files|*.fit|All files|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK) txtFileName.Text = ofd.FileName;
        }

        private void ButProcess_Click(object sender, EventArgs e)
        {
            ProcessFitFile(txtFileName.Text);
        }

        private class ChungParameters
        {
            public double Mass { get; set; }
            public double RollingResistance { get; set; }
            public double AirDensity { get; set; }
            public double CdA { get; set; }
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
