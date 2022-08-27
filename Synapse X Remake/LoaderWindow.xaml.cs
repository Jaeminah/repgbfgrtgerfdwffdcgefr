using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
        ExploitAPI exploit = new ExploitAPI();

        public LoaderWindow()
        {
            InitializeComponent();
        }

        // EVENTS

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

                exploit.LaunchExploit();

                await Task.Delay(500);
                StatusBox.Content = "Ready to launch!";
                await Task.Delay(500);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            };
        }
    }
}
