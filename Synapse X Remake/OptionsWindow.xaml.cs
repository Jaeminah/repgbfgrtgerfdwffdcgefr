using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void UnlockBox_Checked(object sender, RoutedEventArgs e)
        {
            Process[] dunlockfps = Process.GetProcessesByName("rbxfpsunlocker");
            if (dunlockfps.Length > 0)
            {
                MessageBox.Show(this, "Fps Unlocker is already running.", "Fps Unlocker", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = "./bin/rbxfpsunlocker.exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.Start();
                }
            }
        }

        private void UnlockBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var killunfps in Process.GetProcessesByName("rbxfpsunlocker"))
            {
                killunfps.Kill();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void KillRoblox_Checked(object sender, RoutedEventArgs e)
        {
            Process[] DetectingRoblox = Process.GetProcessesByName("RobloxPlayerBeta");
            if (DetectingRoblox.Length > 0)
            {
                foreach (var RobloxKilled in Process.GetProcessesByName("RobloxPlayerBeta"))
                {
                    RobloxKilled.Kill();
                    MessageBox.Show("Roblox has killed", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Couldn't find RobloxPlayerBeta.exe!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TopMostBox_Checked(object sender, RoutedEventArgs e)
        {
            TopMost topMost = new TopMost(true);
            Properties.Settings.Default["TopMost"] = true;
            Properties.Settings.Default.Save();
        }

        private void TopMostBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TopMost topMost = new TopMost(false);
            Properties.Settings.Default["TopMost"] = false;
            Properties.Settings.Default.Save();
        }

        private void TopMostBox_Click(object sender, RoutedEventArgs e)
        {
            if (TopMostBox.IsChecked == true)
            {
                var restart = MessageBox.Show("Would you mind to restart to restart the Program?", "Restart needed", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (restart == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
                else
                {
                    TopMostBox.IsChecked = false;
                }
            }
            else
            {
                var restart = MessageBox.Show("Would you mind to restart to restart the Program?", "Restart needed", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (restart == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
                else
                {
                    TopMostBox.IsChecked = true;
                }
            }
        }

        // EVENTS

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString());
            TopMostBox.IsChecked = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
