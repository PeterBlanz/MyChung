using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChung
{
    public partial class DensityForm : Form
    {
        public double AirDensity { get; private set; }

        public DensityForm()
        {
            InitializeComponent();
            txtTemperature.Text = (22.0).ToString();
            txtAirPressure.Text = (1010.0).ToString();
            txtHumidity.Text = (50.0).ToString();
        }

        private void ButOK_Click(object sender, EventArgs e)
        {
            // parse values
            if (!double.TryParse(txtTemperature.Text, out double tem) || !double.TryParse(txtAirPressure.Text, out double pre) || !double.TryParse(txtHumidity.Text, out double hum))
            {
                MessageBox.Show("Cannot parse all values!");
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            hum *= 0.01;

            // calculate
            double tk = tem + 273.15;
            double saturVaporPres = 6.1078 * Math.Pow(10, (7.5 * tem / (tem + 237.3)));
            double actualVaporPres = hum * saturVaporPres;
            double dryAirPres = pre - actualVaporPres;
            AirDensity = (100 * dryAirPres / (287.058 * tk)) + (100 * actualVaporPres / (461.495 * tk));
        }
    }
}
