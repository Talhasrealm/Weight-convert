using System;
using System.Windows.Forms;

namespace Weight_convert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // This is the vital line that fixes your errors!
            InitializeComponent();

            // Setting up our items
            comboBox1.Items.Add("Pounds (lbs) to Kilograms (kg)");
            comboBox1.Items.Add("Kilograms (kg) to Pounds (lbs)");
            comboBox1.SelectedIndex = 0;
            trackBar1.Maximum = 200;
            this.Text = "Weight Converter Pro";
        }

        private void CalculateTheWeight(double value)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                double kg = value / 2.20462;
                label1.Text = $"{value} lbs = {Math.Round(kg, 2)} kg";
            }
            else
            {
                double lbs = value * 2.20462;
                label1.Text = $"{value} kg = {Math.Round(lbs, 2)} lbs";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double typedNumber))
            {
                CalculateTheWeight(typedNumber);
                if (typedNumber >= 0 && typedNumber <= 200)
                {
                    trackBar1.Value = (int)typedNumber;
                }
            }
            else
            {
                MessageBox.Show("Please type a valid number!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            CalculateTheWeight(trackBar1.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}