using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using WeAreDevs_API;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for ScriptHubWindow.xaml
    /// </summary>
    public partial class ScriptHubWindow : Window
    {
        public static string json = File.ReadAllText("./bin/ScriptHub.json");
        JObject keyValue = JObject.Parse(json);

        ExploitAPI module = new ExploitAPI();

        public ScriptHubWindow()
        {
            InitializeComponent();

            this.Topmost = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString());

            foreach (var i in keyValue["Scripts"])
            {
                ScriptBox.Items.Add(i["Title"]);
            }
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ScriptBox.SelectedIndex != -1)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string content = client.DownloadString(keyValue["Scripts"][ScriptBox.SelectedIndex]["Content"].ToString());
                        module.SendLuaScript(content);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ScriptBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (keyValue["Scripts"][ScriptBox.SelectedIndex]["Img"].ToString() == "")
            {
                Uri uri = new Uri("https://i.imgur.com/ArxGPeM.png");
                var BitmapImage = new BitmapImage();
                BitmapImage.DownloadProgress += BitmapImage_DownloadProgress;
                BitmapImage.DownloadCompleted += BitmapImage_DownloadCompleted;

                DescriptionBox.Text = keyValue["Scripts"][ScriptBox.SelectedIndex]["Description"].ToString();
                BitmapImage.BeginInit();
                BitmapImage.UriSource = uri;
                BitmapImage.EndInit();

                ImageBox.Source = BitmapImage;
            }
            else
            {
                var BitmapImage = new BitmapImage();
                BitmapImage.DownloadProgress += BitmapImage_DownloadProgress;
                BitmapImage.DownloadCompleted += BitmapImage_DownloadCompleted;

                DescriptionBox.Text = keyValue["Scripts"][ScriptBox.SelectedIndex]["Description"].ToString();
                BitmapImage.BeginInit();
                BitmapImage.UriSource = new Uri(keyValue["Scripts"][ScriptBox.SelectedIndex]["Img"].ToString());
                BitmapImage.EndInit();

                ImageBox.Source = BitmapImage;
            }
        }

        private void BitmapImage_DownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            ProgressText.Opacity = 1;
            ProgressText.Text = $"{e.Progress}%";
        }

        private void BitmapImage_DownloadCompleted(object sender, EventArgs e)
        {
            ProgressText.Opacity = 0;
        }
    }
}
