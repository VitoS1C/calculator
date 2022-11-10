using System;
using System.Windows;
using System.Windows.Controls;

namespace This_Project
{
    public partial class MainWindow : Window
    {
        decimal? firstNumber;
        decimal? sencondNumber;
        decimal? result;
        char? calc;


        public MainWindow()
        {
            InitializeComponent();

        }

        private void NumbersButton_Click(object sender, RoutedEventArgs e)
        {
            WindowCalc.Content += (sender as Button).Content.ToString();

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            WindowCalc.Content = string.Empty;
            firstNumber = null;
            sencondNumber = null;
            calc = null;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if ((string)WindowCalc.Content != string.Empty && firstNumber != null)
                sencondNumber = decimal.Parse(WindowCalc.Content.ToString());

            if (calc == null || sencondNumber == null)
            {
                return;
            }

            WindowCalc.Content = string.Empty;

            switch (calc)
            {
                case '+':
                    result = firstNumber + sencondNumber;
                    break;
                case '-':
                    result = firstNumber - sencondNumber;
                    break;
                case '×':
                    result = firstNumber * sencondNumber;
                    break;
                case '÷':
                    if (sencondNumber == 0)
                    {
                        MessageBox.Show("На ноль делить нельзя!");
                        return;
                    }
                    result = firstNumber / sencondNumber;
                    break;
            }

            WindowCalc.Content = result.ToString();
        }

        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            if ((string)WindowCalc.Content == string.Empty)
            {
                calc = (sender as Button).Content.ToString()[0];
                return;
            }
            firstNumber = decimal.Parse(WindowCalc.Content.ToString());
            WindowCalc.Content = string.Empty;
            calc = (sender as Button).Content.ToString()[0];

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            string currentText = WindowCalc.Content.ToString();
            if (currentText == string.Empty)
            {
                return;
            }

            currentText = currentText.Remove(currentText.Length - 1, 1);
            WindowCalc.Content = currentText;
        }


    }
}
