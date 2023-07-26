using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
x - Pressing a number shows the number in the text field 
x - Pressing an operator shows after the number in the text field
x - Pressing another number shows the number after the operator in the text field
x - Pressing the equal sign shows the result of the calculation
x - Add a clear Button
x - Add a delete one number button

Fix:
x - Just one operator at once
x - Delete button if textbox1 is empty
x - Crashes if pressing equal too early 
x - Clean up Code (Pressing multiple 0, ',' , operators




*/




namespace Improved_Calculator
{
    public partial class Form1 : Form
    {
        string num1 = "";
        string num2 = "";
        string oper = "";


        public Form1()
        {
            InitializeComponent();
        }


        // Type a number and show it in the text field
        private void numBttn(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;


            // Check if the text field shows an operator or 0, then clears it
            if (textBox1.Text == oper || textBox1.Text == "0")
            {
                textBox1.Clear();
            }

            // Append the button text to the text field and set the flag if it's a comma
            textBox1.Text += buttonText;
            textBox2.Text += buttonText;

        }


        // press an operator and shows in the text field
        private void opBttn(object sender, EventArgs e)
        {   
            // Checks if last character ends with an operator
            if (textBox1.Text != oper)
            {
                num1 = textBox1.Text;
            }

            oper = "";

            Button button = (Button)sender;
            oper = button.Text;
            textBox1.Text = oper;

            checkOper();
       }


        // Result button
        private void resBttn(object sender, EventArgs e)
        {
            double result = 0;
            num2 = textBox1.Text;

            // Check if both num1 and num2 are not empty before performing the calculation
            if (!string.IsNullOrEmpty(num1) && !string.IsNullOrEmpty(num2))
            {
                double dnum1 = double.Parse(num1);
                double dnum2 = double.Parse(num2);

                switch (oper)
                {
                    case "+":
                        result = dnum1 + dnum2;
                        break;
                    case "-":
                        result = dnum1 - dnum2;
                        break;
                    case "*":
                        result = dnum1 * dnum2;
                        break;
                    case "/":
                        result = dnum1 / dnum2;
                        break;
                }
                textBox1.Text = result.ToString();
            }
            else
            {
                textBox1.Text = "";
            }
        }


        // Clear button
        private void clearBttn(object sender, EventArgs e)
        {
           // Button button = (Button)sender;
            num1 = "";
            num2 = "";
            oper = "";
            textBox1.Clear();
            textBox2.Clear();
        }


        // Delete button
        private void delBttn(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(textBox1.Text))
            { 
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }

           textBox1.Text = textBox1.Text;
           textBox2.Text = textBox2.Text;
        }

        // Comma button
        private void comBttn(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";

                if (textBox2.Text.EndsWith(","))
                {
                    return;
                }
                else
                {
                    textBox2.Text += ",";
                }
            }
        }


        // Checks if last character ends with an operator, deletes last character if true
        public void checkOper()
        {
            if (textBox2.Text.EndsWith("+"))
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                textBox2.Text += oper;
            }
            else if (textBox2.Text.EndsWith("-"))
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                textBox2.Text += oper;
            }
            else if (textBox2.Text.EndsWith("*"))
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                textBox2.Text += oper;
            }
            else if (textBox2.Text.EndsWith("/"))
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                textBox2.Text += oper;
            }
            else
            {
                textBox2.Text += oper;
            }
        }

        // Zero button
        private void zeroBttn(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
            }
            else
            {
                textBox1.Text += "0";
                textBox2.Text += "0";
            }
        }
    }
}
