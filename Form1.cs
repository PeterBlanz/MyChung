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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtAirDens.Text = (1.2215).ToString();
            txtCrr.Text = (0.0028).ToString();
            txtMass.Text = (90.0).ToString();
            txtEff.Text = (98.0).ToString();
        }

        private void ProcessFitFile(string fileName)
        {
            // create empty lists
            List<double> timeValues = new List<double>();
            List<double> powerValues = new List<double>();
            List<double> speedValues = new List<double>();

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
                    foreach (Field field in mesg.GetOverrideField(RecordMesg.FieldDefNum.Timestamp)) timeValues.Add(Convert.ToDouble(field.GetValue()));
                    foreach (Field field in mesg.GetOverrideField(RecordMesg.FieldDefNum.Power)) powerValues.Add(Convert.ToDouble(field.GetValue()));
                    foreach (Field field in mesg.GetOverrideField(RecordMesg.FieldDefNum.Speed)) speedValues.Add(Convert.ToDouble(field.GetValue()));
                }
            }

            // analyze
            DoChungAnalysis(timeValues, powerValues, speedValues);
        }

        private void DoChungAnalysis(List<double> timeValues, List<double> powerValues, List<double> speedValues)
        {
            // check data sets
            if (timeValues.Count != powerValues.Count || timeValues.Count != speedValues.Count)
            {
                MessageBox.Show("Data set lengths must match!");
                return;
            }

            // parse parameters TODO: individual sanity checks
            if (!double.TryParse(txtAirDens.Text, out double airDens) || !double.TryParse(txtMass.Text, out double mass) || !double.TryParse(txtCrr.Text, out double crr) || !double.TryParse(txtEff.Text, out double eff))
            {
                MessageBox.Show("Failed to parse parameters!");
                return;
            }

            // pre-multiply power values
            eff *= 0.01;
            for (int i = 0; i < powerValues.Count; i++) powerValues[i] *= eff;

            // solve CdA
            ChungParameters chungParams = new ChungParameters { AirDensity = airDens, Mass = mass, RollingResistance = crr, CdA = 0.25 };
            double totalVirtualElevation = GetTotalVirtualElevation(chungParams, timeValues, powerValues, speedValues);
            int iterationDirection = Math.Sign(totalVirtualElevation);
            for (int i = 0; i < 1000000; i++)
            {
                if (Math.Sign(totalVirtualElevation) != iterationDirection) break;
                chungParams.CdA += iterationDirection * 0.000001;
                totalVirtualElevation = GetTotalVirtualElevation(chungParams, timeValues, powerValues, speedValues);
            }
            MessageBox.Show(chungParams.CdA.ToString("0.00000"));
        }

        private double GetTotalVirtualElevation(ChungParameters chungParams, List<double> timeValues, List<double> powerValues, List<double> speedValues)
        {
            double totalVirtualElevation = 0;
            for (int i = 1; i < timeValues.Count - 1; i++)
            {
                totalVirtualElevation += GetVirtualElevation(chungParams, timeValues, powerValues, speedValues, i);
            }
            return totalVirtualElevation;
        }

        private double GetVirtualElevation(ChungParameters chungParams, List<double> timeValues, List<double> powerValues, List<double> speedValues, int i)
        {
            double dt = 0.5 * (timeValues[i + 1] - timeValues[i - 1]);
            double a = (speedValues[i + 1] - speedValues[i - 1]) / (2 * dt);
            double v = speedValues[i];
            double Crr = chungParams.RollingResistance;
            double CdA = chungParams.CdA;
            double m = chungParams.Mass;
            double w = powerValues[i];
            double rho = chungParams.AirDensity;
            const double g = 9.81;
            double s = w / (m * g * v) - Crr - a / g - (rho * CdA * v * v) / (2 * m * g);

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
    }
}
