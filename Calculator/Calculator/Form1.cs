using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        String equation = "", ans = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.NewLine + "--------------\n";
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            equation = "";
            ans = "";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Check if the equation is currently empty, to prevent out of bounds exceptions
            if (equation.Length > 0)
            {
                //Add a negative symbol if there isn't already one
                if (equation[equation.Length - 1] != '-')
                    equation += "-";
                else
                    equation = equation.Substring(0, equation.Length - 1);
            }
            //String is empty, so just add a negative sign
            else
            {
                equation += "-";
            }
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            equation += "%";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            equation += "/";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            equation += "+";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            equation += "3";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            equation += "2";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            equation += "1";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            equation += "-";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            equation += "6";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            equation += "5";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            equation += "4";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            equation += "*";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            equation += "9";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            equation += "8";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            equation += "7";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            //Catch syntax errors
            try
            {
                //Store the equation
                string eqn = equation;
                //Cycle through the order of operations
                string ops = "*/%+-";
                //Store the operands
                double a, b;
                //Store the current operation in order of operations,
                //The index of the end of the first operand,
                //The index of the end of the second operand
                int currOp = 0, j, k;

                //Cycle through all order of operations
                for (int i = 0; i < eqn.Length && currOp < 5; i++)
                {
                    string temp = "";
                    //If a symbol is detected, and is not a negative symbol in scientific notation
                    if (eqn[i] == ops[currOp] && eqn[i - 1] != 'E' && i != 0)
                    {
                        //Cycle through the string and store the first operand
                        for (j = i - 1; j >= 0; j--)
                        {
                            //If we run into a symbol that isn't the first element of the string or next to another
                            if (ops.Contains(eqn[j]) && j != 0 && !ops.Contains(eqn[j - 1]))
                            {
                                break;
                            }

                            //Store the valid character
                            temp += eqn[j];
                        }

                        //Reverse the string, since we cycled through the string backwards
                        char[] guh = temp.ToCharArray();
                        Array.Reverse(guh);
                        temp = new String(guh);

                        //Convert the string to a double and clear the string for future use
                        a = Convert.ToDouble(temp);
                        temp = "";

                        //Cycle through the string and store the second operand
                        for (k = i + 1; k < eqn.Length; k++)
                        {
                            //If the current index has a symbol that isn't next to another,
                            //because we already know that it's next to the operator
                            if (ops.Contains(eqn[k]) && ops.Contains(eqn[k + 1]))
                            {
                                break;
                            }

                            //Store the valid symbol in the string
                            temp += eqn[k];
                        }

                        //Convert the string to a double and clear the string for future use
                        b = Convert.ToDouble(temp);
                        temp = "";

                        //Perform the current operation and the operands
                        switch (ops[currOp])
                        {
                            case '*':
                                a *= b;
                                break;
                            case '/':
                                a /= b;
                                break;
                            case '%':
                                a %= b;
                                break;
                            case '+':
                                a += b;
                                break;
                            case '-':
                                a -= b;
                                break;
                        }

                        //Replace the two operands and the operator with the resulting answer

                        //Get the left side of the equation
                        for (int m = 0; m <= j; m++)
                        {
                            temp += eqn[m];
                        }

                        //Put the answer in the middle
                        temp += a.ToString();

                        //Get the right side of the equation
                        for (int m = k; m < eqn.Length; m++)
                        {
                            temp += eqn[m];
                        }

                        //Save the result and start the loop again if we have more potential symbols
                        eqn = temp;
                        ans = eqn;
                        i = 0;
                    }

                    //If we ran through the entire string without a deteced symbol equal to the current operation,
                    //change to the next operation
                    if (i == eqn.Length - 1)
                    {
                        currOp++;
                        i = 0;
                    }
                }
                ans = eqn;
                textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
            }
            
            //If there is an error, it should be a formatting error, so there is a syntax error
            catch (Exception ex)
            {
                ans = "Syntax Error!";
                textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            equation += ".";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            equation += "0";
            textBox1.Text = equation + Environment.NewLine + "--------------" + Environment.NewLine + ans;
        }
    }
}
