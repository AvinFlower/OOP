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
            char newOperation = button.Text[0];

            // Проверяем, есть ли введенное число
            if (string.IsNullOrEmpty(currentInput))
            {
                // Если нет, проверяем, есть ли предыдущий результат
                if (operation != '\0')
                {
                    // Если есть, сохраняем текущую операцию
                    operation = newOperation;
                }
                return;
            }

            double currentOperand = double.Parse(currentInput);

            // Если уже есть предыдущий результат и операция, выполняем операцию
            if (operation != '\0')
            {
                // Выполняем предыдущую операцию
                switch (operation)
                {
                    case '+':
                        result += currentOperand;
                        break;
                    case '-':
                        result -= currentOperand;
                        break;
                    case '*':
                        result *= currentOperand;
                        break;
                    case '/':
                        if (currentOperand != 0)
                            result /= currentOperand;
                        else
                        {
                            MessageBox.Show("Error: Division by zero!");
                            return; // Возвращаемся без изменений
                        }
                        break;
                    case '%':
                        result = result * (currentOperand / 100);
                        break;
                    default:
                        result = currentOperand;
                        break;
                }

                // Отображаем результат вычисления
                textBox1.Text = result.ToString();
            }
            else
            {
                // Если нет предыдущего результата, просто сохраняем текущий ввод
                result = currentOperand;
            }

            // Очищаем текущий ввод
            currentInput = string.Empty;

            // Сохраняем новую операцию
            operation = newOperation;
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
            textBox1.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                // Удаляем последний символ из текущего ввода
                currentInput = currentInput.Remove(currentInput.Length - 1);
                // Отображаем текущий ввод
                textBox1.Text = currentInput;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            textBox1.Cursor = Cursors.Arrow;
            textBox1.SelectionLength = 0;
            textBox1.SelectionStart = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            textBox1.Text = "0"; // Можно также очистить текстовое поле, чтобы отобразить, что введено "0"
        }
    }
}