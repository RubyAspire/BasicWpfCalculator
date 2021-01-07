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
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            firstNumber += Convert.ToDouble(txtResult.Text);
            
            txtResult.Text = "";
            operation = button.Content.ToString();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    secondNumber = double.Parse(txtResult.Text);
                    txtResult.Text = (firstNumber + secondNumber).ToString();
                    firstNumber = 0;
                    break;
                case "/":
                    secondNumber = double.Parse(txtResult.Text);
                    txtResult.Text = (firstNumber / secondNumber).ToString();
                    break;
                case "x":
                    secondNumber = double.Parse(txtResult.Text);
                    txtResult.Text = (firstNumber * secondNumber).ToString();
                    firstNumber = 0;
                    break;
                case "-":
                    secondNumber = double.Parse(txtResult.Text);
                    txtResult.Text = (firstNumber - secondNumber).ToString();
                    firstNumber = 0;
                    break;
            }
        }
        
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = String.Empty;
            secondNumber = 0;
            firstNumber = 0;
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";
        }
    }
}
