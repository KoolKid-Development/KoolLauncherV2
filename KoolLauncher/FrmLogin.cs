using CmlLib.Core.Auth;
using MySql.Data.MySqlClient;
using Salaros.Configuration;
using System;
using System.Configuration;
using System.Windows.Forms;


namespace KoolLauncherV2
{
    public partial class FrmLogin : Form
    {
        MySqlConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["Default Connection"].ToString());
        MySqlCommand cmd;
        MySqlDataReader dr;
        public FrmLogin()
        {
            InitializeComponent();
        }
        public string usernames;
        MLogin login = new MLogin();
        public static string accountname;
        private string appConfig = Application.StartupPath + @"\settings.ini";
        private void UpdateSession(MSession session)
        {
            accountname = txtusername.Text;
            var mainForm = new MainForm(session);
            mainForm.FormClosed += (s, e) => this.Close();
            mainForm.Show();
            this.Hide();
        }
        public void Alert(string msg, FrmAlert.enmType type)
        {
            FrmAlert frm = new FrmAlert();
            frm.showAlert(msg, type);
        }
        void LoadSettings()
        {
            var cfg = new ConfigParser(appConfig);
            var offlineusername = cfg.GetValue("CONFIG", "usr");

            txtofflineusername.Text = offlineusername;
            if (offlineusername == "")
            {
                guna2CheckBox1.Checked = false;
            }
            else
            {
                guna2CheckBox1.Checked = true;
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (settings.enablemysql == "1")
            {
                txtmode.Text = "1";
            }
            else if (settings.enablemysql == "0")
            {
                txtmode.Text = "0";
            }
            else
            {
                Alert("Ouch the launcher config is broken!", FrmAlert.enmType.Error);
            }


            label6.Text = settings.ServerName;
            Console.WriteLine("Done");
            if (txtmode.Text == "1")
            {
                Pages.SetPage(tabPage1);
            }
            else if (txtmode.Text == "0")
            {
                Pages.SetPage(tabPage2);
            }
            else
            {
                Alert("Ouch the launcher config is broken!", FrmAlert.enmType.Error);
            }
        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label5_Click_1(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settings.launcherregisterurl);
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {

            Console.WriteLine("Checking if the username textbox is clear");
            if (txtusername.Text == "")
            {
                Console.WriteLine("Error you need to fill in the username textbox!");
                Alert("You need to enter a username", FrmAlert.enmType.Error);
            }
            else
            {
                Console.WriteLine("Check done!");
                Console.WriteLine("Checking if the password textbox is clear");
                if (txtpassword.Text == "")
                {
                    Console.WriteLine("Error you need to fill in the password textbox!");
                    Alert("You need to enter a password", FrmAlert.enmType.Error);
                }
                else
                {
                    Console.WriteLine("Check done!");

                    string user = txtusername.Text;
                    string pass = txtpassword.Text;
                    cmd = new MySqlCommand();
                    Console.WriteLine("Trying to start the mysql connection!");
                    db.Open();
                    Console.WriteLine("Succes!");
                    cmd.Connection = db;
                    Console.WriteLine("Checking if the account is valid");
                    cmd.CommandText = "SELECT * FROM users where username='" + txtusername.Text + "' AND password='" + txtpassword.Text + "' AND banned= '" + textBox1.Text + "'";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Alert("Logged in as: " + txtusername.Text, FrmAlert.enmType.Succes);
                        UpdateSession(MSession.GetOfflineSession(txtusername.Text));
                    }
                    else
                    {
                        Alert("This account dose not exists!", FrmAlert.enmType.Error);
                    }
                    db.Close();

                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
                var cfg = new ConfigParser(appConfig);
                cfg.SetValue("CONFIG", "usr", txtofflineusername.Text);
                cfg.Save();
                UpdateSession(MSession.GetOfflineSession(txtofflineusername.Text));
            }
            else if (guna2CheckBox1.Checked == false)
            {

            }
            UpdateSession(MSession.GetOfflineSession(txtofflineusername.Text));

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
