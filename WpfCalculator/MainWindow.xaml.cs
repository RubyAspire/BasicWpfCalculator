using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstNumber, secondNumber;
        string operation = "";
        bool firstNumberHasValue = false;
        StringBuilder formula = new StringBuilder();
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
           
            if (button.Content.ToString() == ",")
            {
                if (!txtResult.Text.Contains(","))
                    txtResult.Text += button.Content.ToString();
            }
            else
            {
                txtResult.Text += button.Content.ToString();
            }
            AppendString($"{button.Content}");
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            
            switch (operation)
            {
                case "+":
                    firstNumber += Convert.ToDouble(txtResult.Text);
                    break;
                case "/":
                    firstNumber /= Convert.ToDouble(txtResult.Text);
                    break;
                case "x":
                    firstNumber *= Convert.ToDouble(txtResult.Text);
                    break;
                case "-":
                    firstNumber -= Convert.ToDouble(txtResult.Text);
                    break;
                default:
                    break;
            }
            var button = sender as Button;
            operation = button.Content.ToString();
            if(firstNumberHasValue == false)
                firstNumber = Convert.ToDouble(txtResult.Text);

            firstNumberHasValue = true;
            txtResult.Text = "";
            AppendString($" {button.Content} ");
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            AppendString($" {button.Content}");
            secondNumber = Convert.ToDouble(txtResult.Text);
            switch (operation)
            {
                case "+":
                    txtResult.Text = (firstNumber + secondNumber).ToString();
                    break;
                case "/":
                    txtResult.Text = (firstNumber / secondNumber).ToString();
                    break;
                case "x":
                    txtResult.Text = (firstNumber * secondNumber).ToString();
                    break;
                case "-":
                    txtResult.Text = (firstNumber - secondNumber).ToString();
                    break;
            }
            firstNumberHasValue = false;
            formula.Clear();
            formula.Append(txtResult.Text);
        }
        
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = String.Empty;
            secondNumber = 0;
            firstNumber = 0;
            formula.Clear();
            txtFormula.Text = "";
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            
            if (firstNumberHasValue)
            {
                int index = 0;
                for (int i = 0; i < formula.Length; i++)
                {
                    if (formula[i].ToString() == operation)
                        index = i;
                }
                formula.Remove(index + 2, txtResult.Text.Length);
                txtResult.Text = "";
                
                txtFormula.Text = formula.ToString();
            }
            else 
            { 
                txtResult.Text = "";
                formula.Clear();
                txtFormula.Text = "";
            }
                
        }

        private void AppendString(string item)
        {
            formula.Append(item);
            txtFormula.Text = formula.ToString();
        }
    }
}
