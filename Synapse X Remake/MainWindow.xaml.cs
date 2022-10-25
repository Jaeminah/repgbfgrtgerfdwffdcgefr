using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WeAreDevs_API;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExploitAPI module = new ExploitAPI();

        string SelectedPath = "./Scripts";

        public MainWindow()
        {
            InitializeComponent();
            MEditor(Monaco);
            loadThemes();
            loadSettings();
            loadScriptBox();
        }

        private void loadSettings()
        {
            this.Topmost = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString());
        }

        private void loadScriptBox()
        {
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

        private void loadThemes()
        {
            BrushConverter converter = new BrushConverter();
            string ThemeFile = File.ReadAllText("./bin/Theme.json");
            JObject json = JObject.Parse(ThemeFile);

            var execute = json["Main"]["Execute"];
            ExecuteButton.Background = (Brush)converter.ConvertFrom(execute["Background"].ToString());
            ExecuteButton.Foreground = (Brush)converter.ConvertFrom(execute["Foreground"].ToString());

            var Clear = json["Main"]["Clear"];
            ClearButton.Background = (Brush)converter.ConvertFrom(Clear["Background"].ToString());
            ClearButton.Foreground = (Brush)converter.ConvertFrom(Clear["Foreground"].ToString());

            var Open = json["Main"]["Open"];
            OpenFileButton.Background = (Brush)converter.ConvertFrom(Open["Background"].ToString());
            OpenFileButton.Foreground = (Brush)converter.ConvertFrom(Open["Foreground"].ToString());

            var ExecuteFile = json["Main"]["ExecuteFile"];
            ExecuteFileButton.Background = (Brush)converter.ConvertFrom(ExecuteFile["Background"].ToString());
            ExecuteFileButton.Foreground = (Brush)converter.ConvertFrom(ExecuteFile["Foreground"].ToString());

            var Save = json["Main"]["Save"];
            SaveFileButton.Background = (Brush)converter.ConvertFrom(Save["Background"].ToString());
            SaveFileButton.Foreground = (Brush)converter.ConvertFrom(Save["Foreground"].ToString());

            var Options = json["Main"]["Options"];
            OptionsButton.Background = (Brush)converter.ConvertFrom(Options["Background"].ToString());
            OptionsButton.Foreground = (Brush)converter.ConvertFrom(Options["Foreground"].ToString());

            var Attach = json["Main"]["Attach"];
            AttachButton.Background = (Brush)converter.ConvertFrom(Attach["Background"].ToString());
            AttachButton.Foreground = (Brush)converter.ConvertFrom(Attach["Foreground"].ToString());

            var ScriptHub = json["Main"]["ScriptHub"];
            ScriptHubButton.Background = (Brush)converter.ConvertFrom(ScriptHub["Background"].ToString());
            ScriptHubButton.Foreground = (Brush)converter.ConvertFrom(ScriptHub["Foreground"].ToString());
        }

        private void MEditor(System.Windows.Controls.WebBrowser wb)
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
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            wb.Navigate(string.Format("file:///{0}/bin/editor.html", System.IO.Directory.GetCurrentDirectory()));
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = Monaco.InvokeScript(scriptName, args);
            string script = obj.ToString();
            module.SendLuaScript(script);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Monaco.InvokeScript("SetText", new object[]
            {
                ""
            });
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

            if (ofd.ShowDialog() == true)
            {
                string content = File.ReadAllText(ofd.FileName);
                Monaco.InvokeScript("SetText", new object[]
                {
                    content
                });
            }
        }

        private void ExecuteFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ef = new OpenFileDialog();
            ef.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
            if (ef.ShowDialog() == true)
            {
                module.SendLuaScript(File.ReadAllText(ef.FileName));
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, Monaco.InvokeScript("GetText", new object[0]).ToString());
            }
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }

        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            if (module.IsUpdated() == false)
            {
                var msgbox = MessageBox.Show("WeAreDevs is not yet updated, Are you sure you want continue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Error);

                if (msgbox == MessageBoxResult.Yes)
                {
                    if (module.isAPIAttached() == true)
                    {
                        MessageBox.Show("Already Attached", "Exploit is running", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        module.LegacyLaunchExploit();
                    }
                }
            }
            else
            {
                if (module.isAPIAttached() == true)
                {
                    MessageBox.Show("Already Attached", "Exploit is running", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    module.LegacyLaunchExploit();
                }
            }
        }

        private void ScriptHubButton_Click(object sender, RoutedEventArgs e)
        {
            ScriptHubWindow scriptHubWindow = new ScriptHubWindow();
            scriptHubWindow.ShowDialog();
        }

        private void ExecuteItem_Click(object sender, RoutedEventArgs e)
        {
            if (this.ScriptBox.SelectedIndex != -1)
            {
                module.SendLuaScript(File.ReadAllText($"{SelectedPath}/{ScriptBox.SelectedItem}"));
            }
        }

        private void LoadItem_Click(object sender, RoutedEventArgs e)
        {
            if (ScriptBox.SelectedIndex != -1)
            {
                Monaco.InvokeScript("SetText", new object[1]
                {
                    File.ReadAllText($"{SelectedPath}/{ScriptBox.SelectedItem}")
                });
            }
        }

        private void ChangeFolderItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedPath = folderBrowser.SelectedPath;

                DirectoryInfo directory = new DirectoryInfo(SelectedPath);
                FileInfo[] file = directory.GetFiles("*.txt");
                foreach (FileInfo files in file)
                {
                    ScriptBox.Items.Add(files.Name);
                }

                DirectoryInfo directory1 = new DirectoryInfo(SelectedPath);
                FileInfo[] file1 = directory1.GetFiles("*.lua");
                foreach (FileInfo files in file1)
                {
                    ScriptBox.Items.Add(files.Name);
                }
            }
        }

        private void RefreshItem_Click(object sender, RoutedEventArgs e)
        {
            ScriptBox.Items.Refresh();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MiniButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.S))
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllText(sfd.FileName, Monaco.InvokeScript("GetText", new object[0]).ToString());
                }
            }
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.F))
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    string content = File.ReadAllText(ofd.FileName);
                    Monaco.InvokeScript("SetText", new object[]
                    {
                        content
                    });
                }
            }
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.X))
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua";

                if (ofd.ShowDialog() == true)
                {
                    File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void Monaco_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Monaco.InvokeScript("SetText", new object[]
            {
                Properties.Settings.Default["EditorSave"].ToString()
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            object obj = Monaco.InvokeScript("GetText", new string[0]);
            Properties.Settings.Default["EditorSave"] = obj.ToString();
            Properties.Settings.Default.Save();
        }
    }
}