using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Installer;
using CmlLib.Core.Files;
using CmlLib.Core.Downloader;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using KoolLauncherV2;

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

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            var defaultPath = new MinecraftPath(MinecraftPath.GetOSDefaultPath());
            await initializeLauncher(defaultPath);
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
                MessageBox.Show("Oops, we could not verify your session.");
                Console.WriteLine("Oops, we could not verify your session");
                return;
            }

            if (cbVersion.Text == "")
            {
                MessageBox.Show("You need to select a version first.");
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
                    ServerIp = LauncherSettings.mcserverip,
                };
                Console.WriteLine("Setting the ram to: " + TxtXmx.Text);
                Console.WriteLine("Setting your session to: " + this.session);
                Console.WriteLine("Setting you autojoinserver ip to: " + LauncherSettings.mcserverip);
                

                if (!useMJava)
                    launchOption.JavaPath = javaPath;

                if (!string.IsNullOrEmpty(txtXms.Text))
                    launchOption.MinimumRamMb = int.Parse(txtXms.Text);

                if (!string.IsNullOrEmpty(LauncherSettings.mcserverport))
                    launchOption.ServerPort = int.Parse(LauncherSettings.mcserverport);
                Console.WriteLine("Setting the port to" + LauncherSettings.mcserverport);
                Console.WriteLine("New autojoinserver ip is "+ LauncherSettings.mcserverip + LauncherSettings.mcserverport);

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
                MessageBox.Show("Failed to create MLaunchOption\n\n" + fex);
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
                MessageBox.Show(wex + "\n\nOops, we found a problem in your Java.");
                Console.WriteLine("Oops, we found a problem in your Java.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            Console.WriteLine("Done!");
            txtpls.Text = LauncherSettings.elinks;
            if(txtpls.Text == "0")
            {
                portallinks.Hide();
                username.Text = FrmLogin.accountname;
                label17.Text = LauncherSettings.launchername;
                panel2.Hide();
            }
            else
            {
                portallinks.Show();
                username.Text = FrmLogin.accountname + "!";
                label17.Text = LauncherSettings.launchername;
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
            System.Diagnostics.Process.Start(LauncherSettings.forumurl);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(LauncherSettings.storeurl);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(LauncherSettings.voteurl);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(LauncherSettings.discordurl);
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            pages.SetPage(MainPage);
            settingsbtn1.Show();
            homebtn.Hide();
            
        }

        private void bunifuHSlider1_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {
            if (bunifuHSlider1.Value == 0)
            {
                MessageBox.Show("You need some ram to start minecraft!");
                bunifuHSlider1.Value = 15;
                TxtXmx.Text = "2048";
                RamText.Text = "2GB";
            }
            else if (bunifuHSlider1.Value == 15)
            {
                TxtXmx.Text = "2048";
                RamText.Text = "2GB";
            }
            else if (bunifuHSlider1.Value == 25)
            {
                TxtXmx.Text = "6144";
                RamText.Text = "6GB";
            }
            else if (bunifuHSlider1.Value == 35)
            {
                TxtXmx.Text = "8192";
                RamText.Text = "8GB";
            }
            else if (bunifuHSlider1.Value == 45)
            {
                TxtXmx.Text = "12288";
                RamText.Text = "12GB";
            }
            else if (bunifuHSlider1.Value == 50)
            {
                MessageBox.Show("Mincraft dose not need more then 12gb ram");
                bunifuHSlider1.Value = 45;
                RamText.Text = "12GB";
                TxtXmx.Text = "12288";
            }
        }

        private void SettingsPage_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void devmode_Click(object sender, EventArgs e)
        {
            
        }

        private void devmode_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void MainPage_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            usernamechange.Show();
            this.Hide();
        }

        private void portallinks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void header_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            KoolLauncher x = new KoolLauncher();
            x.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            panel2.Show();
        }
    }
}
