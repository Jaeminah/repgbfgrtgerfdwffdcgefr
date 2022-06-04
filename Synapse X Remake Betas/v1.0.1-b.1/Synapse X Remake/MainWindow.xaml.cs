using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
using System.Threading;
using System.Timers;
using WeAreDevs_API;
using System.Diagnostics;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ExploitAPI module = new ExploitAPI();

        public MainWindow()
        {
            InitializeComponent();

            Monaco.LoadCompleted += Monaco_LoadCompleted;
        }

        private void Monaco_LoadCompleted(object sender, NavigationEventArgs e)
        {
            StreamReader streamReader = new StreamReader("./bin/ace/charlzk.txt");
            Monaco.InvokeScript("SetText", new object[]
            {
                streamReader.ReadToEnd()
            });
        }

        public void MEditor(System.Windows.Controls.WebBrowser wb)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                bool flag2 = registryKey.GetValue(friendlyName) == null;
                if (flag2)
                {
                    registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                }
                registryKey = null;
                friendlyName = null;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Text editor couldn't be initialized! Are you connected to wifi?", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            wb.Navigate(string.Format("file:///{0}/bin/editor.html", System.IO.Directory.GetCurrentDirectory()));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MEditor(Monaco);
            MEditor(Monaco2);
            MEditor(Monaco3);
            MEditor(Monaco4);
            MEditor(Monaco5);
            MEditor(Monaco6);

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

            DirectoryInfo directory = new DirectoryInfo("./Scripts");
            FileInfo[] file = directory.GetFiles("*.txt");
            foreach (FileInfo files in file)
            {
                ScriptBox.Items.Add(files.Name);
            }

            DirectoryInfo directory1 = new DirectoryInfo("./Scripts");
            FileInfo[] file1 = directory1.GetFiles("*.lua");
            foreach (FileInfo files1 in file1)
            {
                ScriptBox.Items.Add(files1.Name);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MiniButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedItem == editor1)
            {
                string scriptName = "GetText";
                object[] args = new string[0];
                object obj = Monaco.InvokeScript(scriptName, args);
                string script = obj.ToString();
                module.SendLimitedLuaScript(script);
            }   
            else if (tabControl.SelectedItem == editor2)
            {
                string scriptName = "GetText";
                object[] args = new string[0];
                object obj = Monaco2.InvokeScript(scriptName, args);
                string script = obj.ToString();
                module.SendLimitedLuaScript(script);
            }
            else if (tabControl.SelectedItem == editor3)
            {
                string scriptName = "GetText";
                object[] args = new string[0];
                object obj = Monaco3.InvokeScript(scriptName, args);
                string script = obj.ToString();
                module.SendLimitedLuaScript(script);
            }
            else if (tabControl.SelectedItem == editor4)
            {
                string scriptName = "GetText";
                object[] args = new string[0];
                object obj = Monaco4.InvokeScript(scriptName, args);
                string script = obj.ToString();
                module.SendLimitedLuaScript(script);
            }
            else if (tabControl.SelectedItem == editor5)
            {
                string scriptName = "GetText";
                object[] args = new string[0];
                object obj = Monaco5.InvokeScript(scriptName, args);
                string script = obj.ToString();
                module.SendLimitedLuaScript(script);
            }
            else if (tabControl.SelectedItem == editor6)
            {
                string scriptName = "GetText";
                object[] args = new string[0];
                object obj = Monaco6.InvokeScript(scriptName, args);
                string script = obj.ToString();
                module.SendLimitedLuaScript(script);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedItem == editor1)
            {
                Monaco.InvokeScript("SetText", new object[]
                {
                ""
                });
            }
            else if (tabControl.SelectedItem == editor2)
            {
                Monaco2.InvokeScript("SetText", new object[]
                {
                ""
                });
            }
            else if (tabControl.SelectedItem == editor3)
            {
                Monaco3.InvokeScript("SetText", new object[]
                {
                ""
                });
            }
            else if (tabControl.SelectedItem == editor4)
            {
                Monaco4.InvokeScript("SetText", new object[]
                {
                ""
                });
            }
            else if (tabControl.SelectedItem == editor5)
            {
                Monaco5.InvokeScript("SetText", new object[]
                {
                ""
                });
            }
            else if (tabControl.SelectedItem == editor6)
            {
                Monaco6.InvokeScript("SetText", new object[]
                {
                ""
                });
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedItem == editor1)
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    string mofd = File.ReadAllText(ofd.FileName);
                    Monaco.InvokeScript("SetText", new object[]
                    {
                    mofd
                    });
                }
            }
            else if (tabControl.SelectedItem == editor2)
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    string mofd = File.ReadAllText(ofd.FileName);
                    Monaco2.InvokeScript("SetText", new object[]
                    {
                    mofd
                    });
                }
            }
            else if (tabControl.SelectedItem == editor3)
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    string mofd = File.ReadAllText(ofd.FileName);
                    Monaco3.InvokeScript("SetText", new object[]
                    {
                    mofd
                    });
                }
            }
            else if (tabControl.SelectedItem == editor4)
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    string mofd = File.ReadAllText(ofd.FileName);
                    Monaco4.InvokeScript("SetText", new object[]
                    {
                    mofd
                    });
                }
            }
            else if (tabControl.SelectedItem == editor5)
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    string mofd = File.ReadAllText(ofd.FileName);
                    Monaco5.InvokeScript("SetText", new object[]
                    {
                    mofd
                    });
                }
            }
            else if (tabControl.SelectedItem == editor6)
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    string mofd = File.ReadAllText(ofd.FileName);
                    Monaco6.InvokeScript("SetText", new object[]
                    {
                    mofd
                    });
                }
            }
        }

        private void ExecuteFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ef = new OpenFileDialog();
            ef.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
            if (ef.ShowDialog() == true)
            {
                module.SendLimitedLuaScript(File.ReadAllText(ef.FileName));
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedItem == editor1)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    Stream s = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(Monaco.InvokeScript("GetText", new object[0]));
                    sw.Close();
                    s.Close();
                }
            }
            else if (tabControl.SelectedItem == editor2)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    Stream s = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(Monaco2.InvokeScript("GetText", new object[0]));
                    sw.Close();
                    s.Close();
                }
            }
            else if (tabControl.SelectedItem == editor3)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    Stream s = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(Monaco3.InvokeScript("GetText", new object[0]));
                    sw.Close();
                    s.Close();
                }
            }
            else if (tabControl.SelectedItem == editor4)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    Stream s = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(Monaco4.InvokeScript("GetText", new object[0]));
                    sw.Close();
                    s.Close();
                }
            }
            else if (tabControl.SelectedItem == editor5)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    Stream s = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(Monaco5.InvokeScript("GetText", new object[0]));
                    sw.Close();
                    s.Close();
                }
            }
            else if (tabControl.SelectedItem == editor6)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    Stream s = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(Monaco6.InvokeScript("GetText", new object[0]));
                    sw.Close();
                    s.Close();
                }
            }
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }

        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            if (module.isAPIAttached() == true)
            {
                MessageBox.Show("Already Attached", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (module.isAPIAttached() == false)
            {
                if (Process.GetProcessesByName("RobloxPlayerBeta").Length > 0)
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = "./finj.exe";
                        process.StartInfo.UseShellExecute = false;
                        process.Start();
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    MessageBox.Show("Roblox Player is not running!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {

            }
        }

        private void ScriptHubButton_Click(object sender, RoutedEventArgs e)
        {
            ScriptHubButton.Content = "Starting...";
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Start();
            timer.Tick += (obj, args) =>
            {
                timer.Stop();
                ScriptHubButton.Content = "Script Hub";
                ScriptHubWindow scriptHubWindow = new ScriptHubWindow();
                scriptHubWindow.ShowDialog();
            };
        }

        private void ExecuteItem_Click(object sender, RoutedEventArgs e)
        {
            if (this.ScriptBox.SelectedIndex != -1)
            {
                module.SendLimitedLuaScript(File.ReadAllText($"Scripts\\{ScriptBox.SelectedItem}"));
            }
        }

        private void LoadItem_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedItem == editor1)
            {
                if (ScriptBox.SelectedIndex != -1)
                {
                    Monaco.InvokeScript("SetText", new object[1]
                    {
                    File.ReadAllText($"./Scripts/{ScriptBox.SelectedItem}")
                    });
                }
            }
            else if (tabControl.SelectedItem == editor2)
            {
                if (ScriptBox.SelectedIndex != -1)
                {
                    Monaco2.InvokeScript("SetText", new object[1]
                    {
                    File.ReadAllText($"./Scripts/{ScriptBox.SelectedItem}")
                    });
                }
            }
            else if (tabControl.SelectedItem == editor3)
            {
                if (ScriptBox.SelectedIndex != -1)
                {
                    Monaco3.InvokeScript("SetText", new object[1]
                    {
                    File.ReadAllText($"./Scripts/{ScriptBox.SelectedItem}")
                    });
                }
            }
            else if (tabControl.SelectedItem == editor4)
            {
                if (ScriptBox.SelectedIndex != -1)
                {
                    Monaco4.InvokeScript("SetText", new object[1]
                    {
                    File.ReadAllText($"./Scripts/{ScriptBox.SelectedItem}")
                    });
                }
            }
            else if (tabControl.SelectedItem == editor5)
            {
                if (ScriptBox.SelectedIndex != -1)
                {
                    Monaco5.InvokeScript("SetText", new object[1]
                    {
                    File.ReadAllText($"./Scripts/{ScriptBox.SelectedItem}")
                    });
                }
            }
            else if (tabControl.SelectedItem == editor6)
            {
                if (ScriptBox.SelectedIndex != -1)
                {
                    Monaco6.InvokeScript("SetText", new object[1]
                    {
                    File.ReadAllText($"./Scripts/{ScriptBox.SelectedItem}")
                    });
                }
            }
        }

        private void RefreshItem_Click(object sender, RoutedEventArgs e)
        {
            ScriptBox.Items.Clear();

            DirectoryInfo directory = new DirectoryInfo("./Scripts");
            FileInfo[] file = directory.GetFiles("*.txt");
            foreach (FileInfo files in file)
            {
                ScriptBox.Items.Add(files.Name);
            }

            DirectoryInfo directory1 = new DirectoryInfo("./Scripts");
            FileInfo[] file1 = directory1.GetFiles("*.lua");
            foreach (FileInfo files1 in file1)
            {
                ScriptBox.Items.Add(files1.Name);
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
