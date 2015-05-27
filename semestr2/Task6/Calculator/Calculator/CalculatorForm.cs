using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private Calculator calculator;

        public CalculatorForm()
        {
            InitializeComponent();
            screen.Enabled = false;
            screen.BackColor = Color.White;
            ResizeText();
            screen.Lines = new string[2];
            calculator = new Calculator();
            Rewrite();
        }

        private void ResizeText()
        {
            float textSize = screen.Height * 2 / 7;
            screen.Font = new Font(Font.FontFamily, textSize);
        }

        private void Rewrite()
        {
            screen.Text = calculator.Result + " " + calculator.Operation + " \r\n" + calculator.SecondOperand;
        }

        private void NumberIsPressed(object sender, EventArgs e)
        {
            Button number = sender as Button;
            calculator.AddNumber(number.Text);
            Rewrite();
        }

        private void DenialIsPressed(object sender, EventArgs e)
        {
            calculator.DenialButtonPressed();
            Rewrite();
        }

        private void OperationIsPressed(object sender, EventArgs e)
        {
            Button operation = sender as Button;
            calculator.OperationButtonPresed(operation.Text);
            Rewrite();
        }

        private void ClearButtonIsPressed(object sender, EventArgs e)
        {
            calculator.ClearButtonPressed();
            Rewrite();
        }

        private void PointButtonIsPressed(object sender, EventArgs e)
        {
            calculator.PointButttonPressed();
            Rewrite();
        }

        private void EaqualButtonPressed(object sender, EventArgs e)
        {
            calculator.EaqualButtonPressed();
            Rewrite();
        }

        private void CalculatorFormResize(object sender, EventArgs e)
        {
            ResizeText();
            Rewrite();
        }
    }
}
