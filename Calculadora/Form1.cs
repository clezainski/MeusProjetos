using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        string valor;
        string valor2;
        string op;
        double resultado;
        string memoria;

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateDisplay()
        {
            Display.Text = valor;
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (valor == "0")
            {
                valor = "0";
            }
            else
            {
                valor += "0";
            }
            UpdateDisplay();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if(valor == "0")
            {
                valor = "1";
            }
            else
            {
                valor += "1";
            }
            UpdateDisplay();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (valor == "0")
            {
                valor = "2";
            }
            else
            {
                valor += "2";
            }
            UpdateDisplay();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (valor == "0")
            {
                valor = "3";
            }
            else
            {
                valor += "3";
            }
            UpdateDisplay();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (valor == "0")
            {
                valor = "4";
            }
            else
            {
                valor += "4";
            }
            UpdateDisplay();
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            if (valor == "0")
            {
                valor = "5";
            }
            else
            {
                valor += "5";
            }
            UpdateDisplay();
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            if (valor == "0")
            {
                valor = "6";
            }
            else
            {
                valor += "6";
            }
            UpdateDisplay();
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            if (valor == "0")
            {
                valor = "7";
            }
            else
            {
                valor += "7";
            }
            UpdateDisplay();
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(op))
            {
                if (valor == "0")
                {
                    valor = "8";
                }
                else
                {
                    valor += "8";
                }
            }
            else
            {
                if (valor2 == "0")
                {
                    valor2 = "8";
                }
                else
                {
                    valor2 += "8";
                }
            }

            UpdateDisplay();
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(op))
            {
                if (valor == "0")
                {
                    valor = "9";
                }
                else
                {
                    valor += "9";
                }              
            }
            else
            {
                if (valor2 == "0")
                {
                    valor2 = "9";
                }
                else
                {
                    valor2 += "9";
                }               
            }

            UpdateDisplay();
        }

        private void button_igual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(op))
            {
                double operando = Convert.ToDouble(valor2);
                double operador = Convert.ToDouble(valor);
                

                if (op.Equals("x"))
                {
                    resultado = operando * operador;
                }

                if (op.Equals("/"))
                {
                    resultado = operando / operador;
                }

                if (op.Equals("-"))
                {
                    resultado = operando - operador;
                }

                if (op.Equals("+"))
                {
                    resultado = operando + operador;
                }
                
                if (op.Equals("p"))
                {
                    resultado = Math.Pow(operando, operador);
                }

                valor = Convert.ToString(resultado);

                op = "";
            }

            UpdateDisplay();
            valor = "0";
            valor2 = "";
            op = "";

        }

        private void button_menos_Click(object sender, EventArgs e)
        {
            valor2 = valor;
            valor = "0";
            op = "-";
        }

        private void button_mais_Click(object sender, EventArgs e)
        {
            valor2 = valor;
            valor = "0";
            op = "+";
        }

        private void button_divisor_Click(object sender, EventArgs e)
        {
            valor2 = valor;
            valor = "0";
            op = "/";
        }

        private void button_multi_Click(object sender, EventArgs e)
        {
            valor2 = valor;
            valor = "0";
            op = "x";
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memoria))
            {
                memoria = valor;
            }

            else
            {
                valor = memoria;
                UpdateDisplay();
            }

        }

        private void button_C_Click(object sender, EventArgs e)
        {
            valor = "0";
            valor2 = "";
            op = "";
            UpdateDisplay();
        }

        private void button_raiz_Click(object sender, EventArgs e)
        {
            resultado = Math.Sqrt(Convert.ToDouble(valor));
            valor = Convert.ToString(resultado);
            UpdateDisplay();

            valor = "0";
            valor2 = "";
            op = "";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valor2 = valor;
            valor = "0";
            op = "p";
        }
    }
}
