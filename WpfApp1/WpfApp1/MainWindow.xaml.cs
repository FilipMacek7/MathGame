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

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            generateExample();
        }
        Random rnd = new Random();
        private void generateExample()
        {
            int num1 = rnd.Next(0, 100);
            int num2 = rnd.Next(0, 100);
            int sum = num1 + num2;
            string numb1 = num1.ToString();
            string numb2 = num2.ToString();
            Question.Text = numb1 + " + " + numb2 + "=";
            Button1.Content = sum;
            int rndNumOper = rnd.Next(0, 4);
            int rndOper = rnd.Next(0, 4);
            int rndsumres = 0;
            switch (rndOper)
            {
                case 1:
                    rndsumres = num1 + num2;
                    break;
                case 2:
                    rndsumres = num1 - num2;
                    break;
                case 3:
                    rndsumres = num1 * num2;
                    break;
                case 4:
                    rndsumres = num1 / num2;
                    break;
            }
            if(sum == rndsumres)
            {

            }
            else
            {
                Button2.Content = rndsumres;
            }            
        } 
        private void Button_Click(object sender, RoutedEventArgs e)
        {           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
