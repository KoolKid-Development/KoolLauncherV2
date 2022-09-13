using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Downloader;
using Salaros.Configuration;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoolLauncherV2
{
    public partial class MainForm : Form
    {
        public MainForm(MSession session)
        {
            this.session = session;
            InitializeComponent();
        }

        CMLauncher launcher;
        readonly MSession session;
        MinecraftPath gamePath;
        bool useMJava = true;
        string javaPath = "java.exe";
        FrmLogin usernamechange = new FrmLogin();
        private int uiThreadId = Thread.CurrentThread.ManagedThreadId;
        private string appConfig = Application.StartupPath + @"\settings.ini";
        void LoadSettings()
        {
            var cfg = new ConfigParser(appConfig);
            var cfgrambinary = cfg.GetValue("CONFIG", "rambinary");
            var cfgramnonbinary = cfg.GetValue("CONFIG", "ramnonbinary");
            var cfgskiphas = cfg.GetValue("CONFIG", "skiphash");
            var cfgskipassets = cfg.GetValue("CONFIG", "skiphash");

            RamText.Text = cfgramnonbinary;
            TxtXmx.Text = cfgrambinary;
            if (cfgskiphas == "true")
            {
                cbSkipHashCheck.Checked = true;
            }
            else if (cfgskiphas == "false")
            {
                cbSkipHashCheck.Checked = false;
            }
            else
            {
                Alert("Some of the config got corupted!", FrmAlert.enmType.Warning);
            }
            
            
            if (cfgskipassets == "true")
            {
                cbSkipAssets.Checked = true;
            }
            else if (cfgskipassets == "false")
            {
                cbSkipAssets.Checked = false;
            }
            else
            {
                Alert("Some of the config got corupted!", FrmAlert.enmType.Warning);
            }

        }
        private async void MainForm_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            var defaultPath = new MinecraftPath(MinecraftPath.GetOSDefaultPath());
            await initializeLauncher(defaultPath);
        }
        public void Alert(string msg, FrmAlert.enmType type)
        {
            FrmAlert frm = new FrmAlert();
            frm.showAlert(msg, type);
        }

        private async Task initializeLauncher(MinecraftPath path)
        {
            txtPath.Text = path.BasePath;
            this.gamePath = path;

            if (useMJava)
                lbJavaPath.Text = path.Runtime;

            launcher = new CMLauncher(path);
            launcher.FileChanged += Launcher_FileChanged;
            launcher.ProgressChanged += Launcher_ProgressChanged;
            await refreshVersions(null);
        }

        private void Launcher_FileChanged(DownloadFileChangedEventArgs e)
        {
            if (Thread.CurrentThread.ManagedThreadId != uiThreadId)
            {
                Debug.WriteLine(e);
            }
            Pb_Progress.Maximum = e.TotalFileCount;
            Pb_Progress.Value = e.ProgressedFileCount;
            Console.WriteLine(e.TotalFileCount +
                e.ProgressedFileCount);
        }

        private void Launcher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Thread.CurrentThread.ManagedThreadId != uiThreadId)
            {
                Debug.WriteLine(e);
            }
            Pb_Progress.Maximum = 100;
            Pb_Progress.Value = e.ProgressPercentage;
        }

        private void setUIEnabled(bool value)
        {
            header.Enabled = value;
            panel1.Enabled = value;
            pages.Enabled = value;
            Console.WriteLine("The launcher ui is now on: " + value);
        }

        private void StartProcess(Process process)
        {
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.EnableRaisingEvents = true;
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
        }

        private void btnSetLastVersion_Click(object sender, EventArgs e)
        {
            cbVersion.Text = launcher.Versions.LatestReleaseVersion?.Name;
        }

        private async void btnRefreshVersion_Click(object sender, EventArgs e)
        {
            await refreshVersions(null);
        }

        private async Task refreshVersions(string showVersion)
        {
            cbVersion.Items.Clear();

            var versions = await launcher.GetAllVersionsAsync();

            bool showVersionExist = false;
            foreach (var item in versions)
            {
                if (showVersion != null && item.Name == showVersion)
                    showVersionExist = true;
                cbVersion.Items.Add(item.Name);
            }

            if (showVersion == null || !showVersionExist)
                btnSetLastVersion_Click(null, null);
            else
                cbVersion.Text = showVersion;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void Btn_Launch_Click_1(object sender, EventArgs e)
        {
            if (session == null)
            {
                Alert("Oops, we could not verify your session", FrmAlert.enmType.Error);
                Console.WriteLine("Oops, we could not verify your session");
                return;
            }

            if (cbVersion.Text == "")
            {

                Alert("You need to select a version first", FrmAlert.enmType.Warning);
                Console.WriteLine("You need to select a version first.");
                return;
            }

            setUIEnabled(false);
            Console.WriteLine("The ui is now disabled");
            try
            {
                var launchOption = new MLaunchOption()
                {

                    MaximumRamMb = int.Parse(TxtXmx.Text),
                    Session = this.session,
                    ServerIp = settings.serverip,
                };
                Console.WriteLine("Setting the ram to: " + TxtXmx.Text);
                Console.WriteLine("Setting your session to: " + this.session);
                Console.WriteLine("Setting you autojoinserver ip to: " + settings.serverip);


                if (!useMJava)
                    launchOption.JavaPath = javaPath;

                if (!string.IsNullOrEmpty(txtXms.Text))
                    launchOption.MinimumRamMb = int.Parse(txtXms.Text);

                if (!string.IsNullOrEmpty(settings.serverport))
                    launchOption.ServerPort = int.Parse(settings.serverport);
                Console.WriteLine("Setting the port to" + settings.serverport);
                Console.WriteLine("New autojoinserver ip is " + settings.serverip + settings.serverport);

                if (rbParallelDownload.Checked)
                {
                    System.Net.ServicePointManager.DefaultConnectionLimit = 256;
                    launcher.FileDownloader = new AsyncParallelDownloader();
                }
                else
                    launcher.FileDownloader = new SequenceDownloader();

                launcher.GameFileCheckers.AssetFileChecker.CheckHash = cbSkipHashCheck.Checked;
                launcher.GameFileCheckers.ClientFileChecker.CheckHash = cbSkipHashCheck.Checked;
                launcher.GameFileCheckers.LibraryFileChecker.CheckHash = cbSkipHashCheck.Checked;

                if (cbSkipAssets.Checked)
                    launcher.GameFileCheckers.AssetFileChecker = null;

                var process = await launcher.CreateProcessAsync(cbVersion.Text, launchOption);


                StartProcess(process);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Failed to create MLaunchOption\n\n" + fex);
                Alert("Faild to start" + fex, FrmAlert.enmType.Error);
            }
            catch (MDownloadFileException mex)
            {
                Console.WriteLine(
                    $"FileName : {mex.ExceptionFile.Name}\n" +
                    $"FilePath : {mex.ExceptionFile.Path}\n" +
                    $"FileUrl : {mex.ExceptionFile.Url}\n" +
                    $"FileType : {mex.ExceptionFile.Type}\n\n" +
                    mex.ToString());
                MessageBox.Show(
                    $"FileName : {mex.ExceptionFile.Name}\n" +
                    $"FilePath : {mex.ExceptionFile.Path}\n" +
                    $"FileUrl : {mex.ExceptionFile.Url}\n" +
                    $"FileType : {mex.ExceptionFile.Type}\n\n" +
                    mex.ToString());
            }
            catch (Win32Exception wex)
            {
                Alert(wex + "Oops, we found a problem in your Java.\n\n", FrmAlert.enmType.Error);
                Console.WriteLine("Oops, we found a problem in your Java.");
            }
            catch (Exception ex)
            {
                Alert(ex.ToString(), FrmAlert.enmType.Error);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                setUIEnabled(true);
                Console.WriteLine("Setting ui to enabled!");
                Console.WriteLine("Done!");
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {//loadform
            LoadSettings();
            Console.WriteLine("Done!");
            txtpls.Text = settings.launcherlinks;
            if (txtpls.Text == "0")
            {
                portallinks.Hide();
                username.Text = FrmLogin.accountname;
                label17.Text = settings.ServerName;
                panel2.Hide();
            }
            else
            {
                portallinks.Show();
                username.Text = FrmLogin.accountname + "!";
                label17.Text = settings.ServerName;
                panel2.Hide();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pages.SetPage(SettingsPage);
            settingsbtn1.Hide();
            homebtn.Show();


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settings.forumlink);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settings.storelink);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settings.votelink);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settings.discordlink);
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            pages.SetPage(MainPage);
            settingsbtn1.Show();
            homebtn.Hide();

        }

        private void bunifuHSlider1_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {

            var cfg = new ConfigParser(appConfig);


            //if (bunifuHSlider1.Value == 0)
            //{
            //    Alert("You need to have at least 1GB ram for minecraft", FrmAlert.enmType.Warning);
            //    bunifuHSlider1.Value = 15;
            //    TxtXmx.Text = "2048";

            //    RamText.Text = "2GB";


            //}
            //else if (bunifuHSlider1.Value == 15)
            //{
            //    TxtXmx.Text = "2048";
            //    RamText.Text = "2GB";
            //}
            //else if (bunifuHSlider1.Value == 25)
            //{
            //    TxtXmx.Text = "6144";
            //    RamText.Text = "6GB";
            //}
            //else if (bunifuHSlider1.Value == 35)
            //{
            //    TxtXmx.Text = "8192";
            //    RamText.Text = "8GB";
            //}
            //else if (bunifuHSlider1.Value == 45)
            //{
            //    TxtXmx.Text = "12288";
            //    RamText.Text = "12GB";
            //}
            //else if (bunifuHSlider1.Value == 50)
            //{
            //    Alert("Minecraft dose not need more then 12GB ram", FrmAlert.enmType.Warning);
            //    bunifuHSlider1.Value = 45;
            //    RamText.Text = "12GB";
            //    TxtXmx.Text = "12288";
            //}
            
        }   

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            usernamechange.Show();
            this.Hide();
        }


        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var cfg = new ConfigParser(appConfig);
            if (RamText.Text == "")
            {
                Alert("You need 1GB ram to launch minecraft", FrmAlert.enmType.Warning);
                RamText.Text = "1GB";
                TxtXmx.Text = "1024";
            }
            if (RamText.Text == "1GB")
            {
                RamText.Text = "1GB";
                TxtXmx.Text = "1024";
            }
            if (RamText.Text == "2GB")
            {
                RamText.Text = "2GB";
                TxtXmx.Text = "2048";
            }
            if (RamText.Text == "3GB")
            {
                TxtXmx.Text = "3072";
                RamText.Text = "3GB";
            }
            if (RamText.Text == "4GB")
            {
                TxtXmx.Text = "4096";
                RamText.Text = "4GB";
            }
            if (RamText.Text == "5GB")
            {
                TxtXmx.Text = "5120";
                RamText.Text = "5GB";
            }
            if (RamText.Text == "6GB")
            {
                RamText.Text = "6GB";
                TxtXmx.Text = "6144";
            }
            if (RamText.Text == "7GB")
            {
                RamText.Text = "7GB";
                TxtXmx.Text = "7168";
            }
            if (RamText.Text == "8GB")
            {
                RamText.Text = "8GB";
                TxtXmx.Text = "8192";
            }
            if (RamText.Text == "9GB")
            {
                RamText.Text = "9GB";
                TxtXmx.Text = "9216";
            }
            if (RamText.Text == "10GB")
            {
                RamText.Text = "10GB";
                TxtXmx.Text = "10240";
            }
            if (RamText.Text == "11GB")
            {
                RamText.Text = "11GB";
                TxtXmx.Text = "11264";
            }
            if (RamText.Text == "12GB")
            {
                RamText.Text = "12GB";
                TxtXmx.Text = "12288";
            }
            else
            {
                Alert("This is invalid use from 1GB to 12GB and add GB to end", FrmAlert.enmType.Warning);
            }
            cfg.SetValue("CONFIG", "rambinary", TxtXmx.Text);
            cfg.SetValue("CONFIG", "ramnonbinary", RamText.Text);
            cfg.Save();
        }

        private void cbSkipHashCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSkipHashCheck.Checked == true)
            {
                var cfg = new ConfigParser(appConfig);
                cfg.SetValue("CONFIG", "skiphash", "true");
                cfg.Save();

            }
            else if (cbSkipHashCheck.Checked == false)
            {
                var cfg = new ConfigParser(appConfig);
                cfg.SetValue("CONFIG", "skiphash", "false");
                cfg.Save();
            }
            
        }

        private void cbSkipAssets_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSkipAssets.Checked == true)
            {
                var cfg = new ConfigParser(appConfig);
                cfg.SetValue("CONFIG", "skipassets", "true");
                cfg.Save();
            }
            else if (cbSkipAssets.Checked == false)
            {
                var cfg = new ConfigParser(appConfig);
                cfg.SetValue("CONFIG", "skipassets", "false");
                cfg.Save();
            }
        }

        private void SettingsPage_Click(object sender, EventArgs e)
        {
            
        }
    }
}
