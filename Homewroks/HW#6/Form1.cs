using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCalculator
{
    public partial class Form1 : Form
    {
        double num1;
        double num2;
        string myOperator;
        bool equalPressed = false;
        double res = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonClick(object sender, EventArgs e)
        {
            if(output.Text == "0")
                output.Clear();
            if (equalPressed == true)
            {
                output.Clear();
                num1 = 0;
                myOperator = "";
            }
            
            Button btn = (Button)sender;
            if (btn.Text == ".")
            {
                if (!output.Text.Contains("."))
                {
                    output.Text += btn.Text;
                }
            }
            else
            {
                output.Text += btn.Text;
            }
           
            equalPressed = false;
        }

        private void m(object sender, EventArgs e)
        {

        }

        private void operatorClick(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            num1 = double.Parse(output.Text);     
            output.Clear();
            myOperator = btn.Text;
            equalPressed = false;

        }

        private void equalClick(object sender, EventArgs e)
        {
            double result = 0;
            num2 = double.Parse(output.Text);
            if (myOperator == "+")
            {
                result = num1 + num2;
            }
            else if (myOperator == "-")
            {
                result = num1 - num2;
            }
            else if (myOperator == "*")
            {
                result = num1 * num2;
            }
            else if (myOperator == "/")
            {
                result = num1 / num2;
            }
            output.Text = result.ToString();
            equalPressed = true;

        }

        private void clearClick(object sender, EventArgs e)
        {
            output.Text = "0";
            num1 = 0;
            myOperator = "";
            num2 = 0;
        }
    }
}
