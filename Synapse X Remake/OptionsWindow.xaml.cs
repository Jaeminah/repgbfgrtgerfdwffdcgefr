using Synapse_X_Remake.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

            UnlockBox.IsChecked = Settings.Default.UnlockFps;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void UnlockBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UnlockFps = UnlockBox.IsChecked.HasValue ? UnlockBox.IsChecked.Value : true;
            Settings.Default.Save();

            Process[] dunlockfps = Process.GetProcessesByName("FpsUnlocker");
            if (dunlockfps.Length > 0)
            {
                foreach (var killunfps in Process.GetProcessesByName("FpsUnlocker"))
                {
                    killunfps.Kill();
                }

                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = "./bin/FpsUnlocker.exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.Start();
                }
            }
            else
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = "./bin/FpsUnlocker.exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.Start();
                }
            }
        }

        private void UnlockBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UnlockFps = UnlockBox.IsChecked.HasValue ? UnlockBox.IsChecked.Value : false;
            Settings.Default.Save();

            foreach (var killunfps in Process.GetProcessesByName("FpsUnlocker"))
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
