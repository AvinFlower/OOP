using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class Calculator : Form
    {
        private Form2 form2;

        private string currentInput = string.Empty;
        private double result = 0;
        private char operation;

        public Calculator(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text[0];
            result = double.Parse(textBox1.Text);
            currentInput = string.Empty;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double secondOperand = double.Parse(currentInput);
                switch (operation)
                {
                    case '+':
                        result += secondOperand;
                        break;
                    case '-':
                        result -= secondOperand;
                        break;
                    case '*':
                        result *= secondOperand;
                        break;
                    case '/':
                        if (secondOperand != 0)
                            result /= secondOperand;
                        else
                            MessageBox.Show("Error: Division by zero!");
                        break;
                    case '%':
                        result = result * (secondOperand / 100);
                        break;
                }
                textBox1.Text = result.ToString();
                currentInput = string.Empty;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            result = 0;
            textBox1.Text = string.Empty;
        }
    }
}