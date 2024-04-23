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
    public partial class Form1 : Form
    {
        public double[,] priceArray = new double[,]
        {
            {35, 45, 80, 150, 280 },
            {45, 55, 90, 170, 320 },
            {32, 42, 78, 148, 275 },
            {45, 55, 100, 175, 335 },
            {10, 15, 25, 50, 90 },
            {10, 15, 20, 45, 80 },
            {10, 12, 15, 50, 90 },
            {15, 20, 25, 70, 110 }
        };

        public string[] rentalDurations =
        {
            "1 day",
            "2 days",
            "3 days",
            "1 week",
            "2 weeks"
        };
        
        public enum EquipmentType
        {
            Skis_Basic,
            Skis_Advanced,
            Snow_Basic,
            Snow_Advanced,
            Ski_Boots,
            Snow_Boots,
            Helmet_Std,
            Helmet_Deluxe
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(rentalDurations);
            listBox1.DataSource = Enum.GetValues(typeof(EquipmentType));
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count == 0)
            {
                errorProvider1.SetError(listBox1, "Select at least one equipment item");
                return;
            }
           
            if(comboBox1.SelectedIndex == -1)
            {
                errorProvider1.SetError(listBox1, "Select at least one equipment item");
                return;
            }
            
            if(!double.TryParse(textBoxDeposit.Text, out double deposit) || deposit < 0)
            {
                errorProvider1.SetError(textBoxDeposit, "Enter a valid positive deposit amount");
                return;
            }
            
            double subtotal = 0;
            foreach(var item in listBox1.SelectedItems)
            {
                int rowIndex = (int)((EquipmentType)item);
                int colIndex = comboBox1.SelectedIndex;
                subtotal += priceArray[rowIndex, colIndex];
            }
            double tax = 0.1 * subtotal;
            double total = subtotal + tax;
            double balanceDue = total - deposit;

            labelSubtotal.Text = subtotal.ToString("c");
            labelTax.Text = tax.ToString("c");
            labelBal.Text = balanceDue.ToString("c");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WeatherForecastForm weatherForm = new WeatherForecastForm();
            weatherForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EquipmentType selectedValue = (EquipmentType)listBox1.SelectedItem;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
