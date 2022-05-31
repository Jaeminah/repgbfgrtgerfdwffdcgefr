using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WeAreDevs_API;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for LoaderWindow.xaml
    /// </summary>
    public partial class LoaderWindow : Window
    {

        DispatcherTimer Timer = new DispatcherTimer();
        ExploitAPI api = new ExploitAPI();

        public LoaderWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string ctopmost = File.ReadAllText("./bin/ontopsettings.txt");
            bool sconvert = bool.Parse(ctopmost);

            if (sconvert == true)
            {
                CTopMost.IsChecked = true;
            }
            else
            {
                CTopMost.IsChecked = false;
            }

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer1.Start();
            timer1.Tick += (obj, args) =>
            {
                timer1.Stop();
                ProgressBox.Value = 50;
            };

            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 3);
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer1.Start();
            timer1.Tick += async (obj, args) =>
            {
                timer1.Stop();
                ProgressBox.Value = 100;
                api.LaunchExploit();
                await Task.Delay(500);
                StatusBox.Content = "Ready to launch!";
                await Task.Delay(500);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            };
        }

        private void CTopMost_Checked(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void CTopMost_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
        }
    }
}
