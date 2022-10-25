using System;
using System.Net;
using System.IO.Compression;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WeAreDevs_API;
using System.IO;
using System.Threading.Tasks;

namespace Synapse_X_Remake
{
    /// <summary>
    /// Interaction logic for LoaderWindow.xaml
    /// </summary>
    public partial class LoaderWindow : Window
    {

        DispatcherTimer Timer = new DispatcherTimer();
        ExploitAPI exploit = new ExploitAPI();

        public string binFileUrl = "https://github.com/Charlzk05/Synapse-X-Remake-Synapse-X-Free-Version/files/9843577/bin.zip";
        public string ScriptsFileUrl = "https://github.com/Charlzk05/Synapse-X-Remake-Synapse-X-Free-Version/files/9843565/Scripts.zip";

        public LoaderWindow()
        {
            InitializeComponent();

            try
            {
                CheckNDownload();
            }
            catch (Exception error)
            {
                var option = MessageBox.Show($"{error.Message}\n\nDo you still want to continue?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (option == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void CheckNDownload()
        {
            if (exploit.IsUpdated() == true)
            {

                if (Directory.Exists("./bin") && Directory.Exists("./Scripts"))
                {
                    StatusBox.Content = "Done!";
                    ProgressBox.Value = 100;

                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadProgressChanged += binFileDownloadProgress;
                            client.DownloadFileCompleted += binFileDownloadComplete;
                            client.DownloadFileAsync(new Uri(binFileUrl), "./bin.zip");
                        }
                    }
                    catch (Exception error)
                    {
                        var option = MessageBox.Show($"{error.Message}\n\nDo you still want to continue?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                        if (option == MessageBoxResult.No)
                        {
                            Application.Current.Shutdown();
                        }
                    }
                }
            }
            else
            {
                var msgbox = MessageBox.Show("WeAreDevs is not yet updated, Are you sure you want continue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Error);

                if (msgbox == MessageBoxResult.Yes)
                {
                    if (Directory.Exists("./bin") && Directory.Exists("./Scripts"))
                    {
                        StatusBox.Content = "Done!";
                        ProgressBox.Value = 100;

                        this.Hide();
                        MainWindow main = new MainWindow();
                        main.Show();
                    }
                    else
                    {
                        try
                        {
                            using (var client = new WebClient())
                            {
                                client.DownloadProgressChanged += binFileDownloadProgress;
                                client.DownloadFileCompleted += binFileDownloadComplete;
                                client.DownloadFileAsync(new Uri(binFileUrl), "./bin.zip");
                            }
                        }
                        catch (Exception error)
                        {
                            var option = MessageBox.Show($"{error.Message}\n\nDo you still want to continue?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                            if (option == MessageBoxResult.No)
                            {
                                Application.Current.Shutdown();
                            }
                        }
                    }
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void binFileDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            StatusBox.Content = $"Downloading Bin ... {e.ProgressPercentage}%";
            ProgressBox.Value = e.ProgressPercentage;
        }

        private void binFileDownloadComplete(object sender, EventArgs e)
        {
            try
            {
                StatusBox.Content = "Done!";
                string bin = "./bin";

                if (Directory.Exists(bin))
                {
                    DirectoryInfo directory = new DirectoryInfo(bin);

                    foreach (var file in directory.GetFiles())
                    {
                        file.Delete();
                    }

                    foreach (var subDir in directory.GetDirectories())
                    {
                        subDir.Delete(true);
                    }

                    ZipFile.ExtractToDirectory("./bin.zip", "./");
                    File.Delete("./bin.zip");

                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += scriptsFileDownloadProgress;
                        client.DownloadFileCompleted += scriptsFileDownloadCompleted;
                        client.DownloadFileAsync(new Uri(ScriptsFileUrl), "./Scripts.zip");
                    }
                }
                else
                {
                    ZipFile.ExtractToDirectory("./bin.zip", "./");
                    File.Delete("./bin.zip");

                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += scriptsFileDownloadProgress;
                        client.DownloadFileCompleted += scriptsFileDownloadCompleted;
                        client.DownloadFileAsync(new Uri(ScriptsFileUrl), "./Scripts.zip");
                    }
                }
            }
            catch (Exception error)
            {
                var option = MessageBox.Show($"{error.Message}\n\nDo you still want to continue?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (option == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void scriptsFileDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            StatusBox.Content = $"Downloading Scripts ... {e.ProgressPercentage}%";
            ProgressBox.Value = e.ProgressPercentage;
        }

        private void scriptsFileDownloadCompleted(object sender, EventArgs e)
        {
            try
            {
                StatusBox.Content = "Done!";
                string scripts = "./Scripts";

                if (Directory.Exists(scripts))
                {
                    DirectoryInfo directory = new DirectoryInfo(scripts);

                    foreach (var file in directory.GetFiles())
                    {
                        file.Delete();
                    }

                    foreach (var subDir in directory.GetDirectories())
                    {
                        subDir.Delete(true);
                    }

                    ZipFile.ExtractToDirectory("./Scripts.zip", "./");
                    File.Delete("./Scripts.zip");

                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    ZipFile.ExtractToDirectory("./Scripts.zip", "./");
                    File.Delete("./Scripts.zip");

                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
            }
            catch (Exception error)
            {
                var option = MessageBox.Show($"{error.Message}\n\nDo you still want to continue?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (option == MessageBoxResult.No)
                {
                    Application.Current.Shutdown();
                }
            }
        }
    }
}
