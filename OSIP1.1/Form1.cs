using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace OSIP1._1
{
    public partial class Form1 : Form
    {
        public Configuration config;
        public Form1()
        {
            InitializeComponent();
            config = new Configuration();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            config.functionX = textFunctionX.Text;
            config.functionY = textFunctionY.Text;
            config.gridScale = int.Parse(textScale.Text);
            config.points = int.Parse(textPoints.Text);
            
            config.A = decimal.Parse(textFunctionX.Text, NumberStyles.Float, new CultureInfo("en-US"));
            config.B = decimal.Parse(textFunctionY.Text, NumberStyles.Float, new CultureInfo("en-US"));
            switch (boxSelectMode.SelectedIndex)
            {
                case 0:
                    {
                        Form2 lab1 = new Form2(config);
                        lab1.Show();
                        lab1.Run();
                        break;
                    }
                case 1:
                    {
                        Form3 lab2 = new Form3(config);
                        lab2.Show();
                        lab2.Run();
                        break;
                    }
                case 2:
                    {
                        var lab3 = new GraphicsLab(config);
                        lab3.Run();
                        break;
                    }


            }
            
        }

        #region StartButtonConditions
        private void textFunctionX_TextChanged(object sender, EventArgs e)
        {
            StartButtonUpdate();
        }

        private void textFunctionY_TextChanged(object sender, EventArgs e)
        {
            StartButtonUpdate();
        }

        private void textScale_TextChanged(object sender, EventArgs e)
        {
            StartButtonUpdate();
        }

        private void textPoints_TextChanged(object sender, EventArgs e)
        {
            StartButtonUpdate();
        }

        private void boxSelectMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartButtonUpdate();
        }

        private void StartButtonUpdate()
        {
            buttonStart.Enabled =
                textFunctionX.Text != string.Empty &&
                textFunctionY.Text != string.Empty &&
                textPoints.Text != string.Empty &&
                textScale.Text != string.Empty &&
                boxSelectMode.SelectedIndex != -1;
        }

        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
