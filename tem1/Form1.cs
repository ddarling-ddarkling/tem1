using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tem1
{
    public partial class Form1 : Form
    {
        char decimalSeparator = Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

        public static double Factorial(int N) 
        {
            double fact = 1;
            for (int i = 1; i <= N; i++)
                fact *= i;
            return fact;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox_X.Text);                // аргумент функции
            double a = Convert.ToDouble(textBox_a.Text);                // точность
            double sin, element, raz, summ = 1, previous = 1;           // sin - функция, summ - сумма ряда, raz - разность между соседними членами ряда, element - эл-т ряда, previous - предыдущий член ряда
            int n = 1;                                                  // n - счётчик

            if ( 0 < a && a < 1)
            {
                do
                {
                    element = ((Math.Pow(-1, n) * Math.Pow(x, 2 * n)) / Factorial(2 * n + 1));
                    summ += element;
                    raz = element - previous;
                    previous = element;
                    n++;
                }
                while (Math.Abs(raz) > a);

                sin = (x * summ);

                label_result.Text = "Результат:\n" +
                                    "Sin(x) = " + Convert.ToString(sin) +
                                    "\nСумма ряда = " + Convert.ToString(summ) +
                                    "\nКоличество членов ряда = " + Convert.ToString(n) +
                                    "\nМат.Син. = " + Convert.ToString(Math.Sin(x));
            }
            else
            {
                MessageBox.Show("Значение точности не соответствует условию!");
            }
        }

        private void textBox_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == decimalSeparator || e.KeyChar == (Char)Keys.Delete || e.KeyChar == (Char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox_a_TextChanged(object sender, EventArgs e)
        {
            if (textBox_a.Text.Length == 0 || textBox_X.Text.Length == 0) button1.Enabled = false;
                else button1.Enabled = true;
        }

        private void textBox_X_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
