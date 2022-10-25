using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WeAreDevs_API;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        ExploitAPI exploit = new ExploitAPI();

        public OptionsWindow()
        {
            InitializeComponent();

            this.Topmost = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString());
            TopMostBox.IsChecked = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString());
        }

        private void UnlockBox_Checked(object sender, RoutedEventArgs e)
        {
            Process[] dunlockfps = Process.GetProcessesByName("rbxfpsunlocker");
            if (dunlockfps.Length > 0)
            {
                MessageBox.Show(this, "Fps Unlocker is already running\nUncheck the CheckBox again to turn off FPS Unlocker.", "Fps Unlocker", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            Properties.Settings.Default["TopMost"] = true;
        }

        private void TopMostBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["TopMost"] = false;
        }

        private void TopMostBox_Click(object sender, RoutedEventArgs e)
        {
            if (TopMostBox.IsChecked == true)
            {
                var restart = MessageBox.Show("Restart is require for changes to take effect.", "Restart require", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (restart == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            else
            {
                var restart = MessageBox.Show("Restart is require for changes to take effect.", "Restart needed", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (restart == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
        }

        private void CustomFPSButton_Click(object sender, RoutedEventArgs e)
        {
            if (exploit.isAPIAttached() == true)
            {
                CustomFPSWindow customFPS = new CustomFPSWindow();
                customFPS.Show();
            }
            else
            {
                MessageBox.Show("Please attach the exploit first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}
