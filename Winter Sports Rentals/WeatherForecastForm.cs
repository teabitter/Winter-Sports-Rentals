using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winter_Sports_Rentals
{
    public partial class WeatherForecastForm : Form
    {
        public WeatherForecastForm()
        {
            InitializeComponent();
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
