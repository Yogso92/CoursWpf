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

namespace ExoCalculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double Result;
        private double Memory;
        private string Operator;
        private bool NeedWipe;
        public MainWindow()
        {
            InitializeComponent();
            Output.Content = "0";
            
        }
        public void OnNumberClick(object sender, RoutedEventArgs e)
        {
            if (NeedWipe)
            {
                Output.Content = "0";
                NeedWipe = false;
                Result = 0;
            }
            Button btn = sender as Button;
            Output.Content = double.Parse(Output.Content.ToString() + btn.Content.ToString()).ToString();
        }
        public void OnMplusClick(object sender, RoutedEventArgs e)
        {
            Memory += double.Parse(Output.Content.ToString());
            NeedWipe = true;
            
        }
        public void OnMmoinsClick(object sender, RoutedEventArgs e)
        {
            Memory -= double.Parse(Output.Content.ToString());
            NeedWipe = true;

        }
        public void OnMrClick(object sender, RoutedEventArgs e)
        {
            Output.Content = Memory.ToString();
            NeedWipe = true;

        }
        public void OnMcClick(object sender, RoutedEventArgs e)
        {
            Memory = 0;

        }
        public void OnCClick(object sender, RoutedEventArgs e)
        {
            Output.Content = "0";
            Result = 0;

        }
        public void OnpmClick(object sender, RoutedEventArgs e)
        {
            Output.Content = (0-Double.Parse(Output.Content.ToString())).ToString();

        }
        public void OnOperatorClick(object sender, RoutedEventArgs e)
        {
            
            if (Result == 0 || Operator == null)
            {
                Result = Double.Parse(Output.Content.ToString());
            }
            else
            {
                Calculate();
            }
            NeedWipe = false;
            Operator = (sender as Button).Content.ToString();
            SmallOut.Content = Result.ToString() + Operator;
            Output.Content = "0";

        }
        public void OnEqClick(object sender, RoutedEventArgs e)
        {
            if(Operator != null)
            {
                Calculate();
                SmallOut.Content = "";
                Output.Content = Result.ToString();
                Operator = null;
                NeedWipe = true;
            }
        }
        public void OnComaClick(object sender, RoutedEventArgs e)
        {
            Output.Content += ",";
        }
        private void Calculate()
        {
            double temp = double.Parse(Output.Content.ToString());
            Console.WriteLine(Operator);
            switch (Operator)
            {
                case "/":
                    Result /= temp;
                    break;
                case "+":
                    Result += temp;
                    break;
                case "x":
                    Result *= temp;
                    break;
                case "-":
                    Result -= temp;
                    break;
                default:
                    throw new ArithmeticException();
            }
        }

    }
}
