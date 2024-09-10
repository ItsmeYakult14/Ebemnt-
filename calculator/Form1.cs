using System;
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
        Calculator cal = new Calculator();
        double num1 = 0;
        double num2 = 0;
        public Form1()
        {
            InitializeComponent();
            cal = new Calculator();
        }

        public event Action CalculateEvent
        {
            add { Console.WriteLine("Added the Delegate"); CalculateEvent += value; }
            remove { Console.WriteLine("Removed the Delegate"); CalculateEvent -= value; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);

            string selectedcbOperator = cbOperator.Text;
            double result = 0;

            switch (cbOperator.SelectedItem.ToString())
            {
                case "+":
                    cal.calculateEvent += new Formula<double>(cal.GetSum);
                    lblDisplayTotal.Text = cal.GetSum(num1, num2).ToString();
                    cal.calculateEvent -= new Formula<double>(cal.GetSum);
                    break;

                case "-":
                    cal.calculateEvent += new Formula<double>(cal.GetDiff);
                    lblDisplayTotal.Text = cal.GetDiff(num1, num2).ToString();
                    cal.calculateEvent -= new Formula<double>(cal.GetDiff);
                    break;
                case "*":
                    cal.calculateEvent += new Formula<double>(cal.GetProd);
                    lblDisplayTotal.Text = cal.GetProd(num1, num2).ToString();
                    cal.calculateEvent -= new Formula<double>(cal.GetProd);
                    break;
                case "/":
                    cal.calculateEvent += new Formula<double>(cal.GetQout);
                    lblDisplayTotal.Text = cal.GetQout(num1, num2).ToString();
                    cal.calculateEvent -= new Formula<double>(cal.GetQout);
                    break;

            }
           


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
