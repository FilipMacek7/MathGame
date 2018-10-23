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
using System.Windows.Threading;

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
        int points = 1;
        bool game = true;
        private int generateExample()
        {
            int sum = 0;             
            if (game == true & points <= 10)
            {
                int num1 = 0;
                int num2 = 0;
                if (points < 5)
                {
                    num1 = rnd.Next(0, 100);
                    num2 = rnd.Next(0, 100);
                }
                else if (points >= 5)
                {
                    num1 = rnd.Next(0, 1000);
                    num2 = rnd.Next(0, 1000);
                }
                sum = num1 + num2;
                int rndNumOper = rnd.Next(1, 6);
                int rndOper = rnd.Next(1, 3);
                int rndsumres = 0;
                switch (rndOper)
                {
                    case 1:
                        rndsumres = num1 + num2 + rndNumOper;
                        break;
                    case 2:
                        rndsumres = num1 + num2 - rndNumOper;
                        break;
                }
                Question.Text = num1.ToString() + " + " + num2.ToString() + "=";
                int rndPos = rnd.Next(1, 3);
                switch (rndPos)
                {
                    case 1:
                        Button1.Content = sum.ToString();
                        Button2.Content = rndsumres;
                        break;
                    case 2:
                        Button1.Content = rndsumres;
                        Button2.Content = sum.ToString();
                        break;
                }
                string strpoints = points.ToString();
                Level.Content = strpoints + "/10";

            }
            else if(points >= 10)
            {
                Question.Text = "You won";
                Level.Content = "Congratulations!";
                dt.Stop();
            }
            return sum;
        }
        DispatcherTimer dt = new DispatcherTimer();
        private int increment = 10;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string strsum = generateExample().ToString();
            if (Button1.Content.ToString() == strsum)
            {
                points++;              
            }
            increment = 11;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string strsum = generateExample().ToString();
            if (Button2.Content.ToString() == strsum)
            {
                points++;
            }
            increment = 11;
        }        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void dtTicker(object sender, EventArgs e)
        {
            if (increment == 1)
            {
                dt.Stop();
                Question.Text = "YOU LOST LOSER";
                game = false;
                Time.Content = "Time left: 0";
            }
            else
            {
                increment--;
                Time.Content = "Time left: " + increment.ToString();
            }            
        }
    }
}
