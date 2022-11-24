using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtHeSoA.KeyPress += TxtHeSo_KeyPress;
            txtHeSoB.KeyPress += TxtHeSo_KeyPress;
            txtHeSoC.KeyPress += TxtHeSo_KeyPress;
            btnCalculator.Click += BtnCalculator_Click;
            BtnCancel.Click += BtnCancel_Click;
            txtResult.Enabled = false;
            txtResult.ForeColor = Color.Aquamarine;
        }

        private void TxtHeSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) // không phải là kí tự
                e.Handled = true;
        }

  

        private void BtnCalculator_Click(object sender, EventArgs e)
        {
            int hesoa = int.Parse(txtHeSoA.Text);
            int hesob = int.Parse(txtHeSoB.Text);
            int hesoc = int.Parse(txtHeSoC.Text);
            // Kiểm tra các hệ số do người dùng nhập
            if (hesoa == 0)
            {
                if (hesob == 0)
                {
                    if (hesoc == 0)
                        txtResult.Text = "Equation has infinite soluations";
                    else
                        txtResult.Text = "Equation has not solution";
                }
                else
                {
                    double result = -hesoc / (hesob * 1.0);
                    result = Math.Round(result, 2);
                    txtResult.Text = "x1 = x2 = " + result.ToString();
                }
            }
            else
            {
                double delta = hesob * hesob - 4 * hesoa * hesoc;
                if (delta == 0)
                {
                    double result = -hesob / (2 * hesoa * 1.0);
                    result = Math.Round(result, 2);
                    txtResult.Text = "x1 = x2 = " + result.ToString();
                }
                else if (delta < 0)
                    txtResult.Text = "Equation has not solution";
                else
                {
                    double x1 = (-hesob + Math.Sqrt(delta)) / (2 * hesoa * 1.0);
                    double x2 = (-hesob - Math.Sqrt(delta)) / (2 * hesoa * 1.0);
                    x1 = Math.Round(x1, 2);
                    x2 = Math.Round(x2, 2);
                    txtResult.Text = "x1 = " + x1.ToString() + " and " + "x2 = " + x2.ToString();
                }
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCalculator.Click -= BtnCalculator_Click;
        }
    }

    
}
    