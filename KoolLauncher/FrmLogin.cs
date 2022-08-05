using CmlLib.Core.Auth;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KoolLauncherV2
{
    public partial class FrmLogin : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public FrmLogin()
        {
            InitializeComponent();
        }
        public string usernames;
        MLogin login = new MLogin();
        public static string accountname;
        private void UpdateSession(MSession session)
        {
            accountname = txtusername.Text;
            var mainForm = new MainForm(session);
            mainForm.FormClosed += (s, e) => this.Close();
            mainForm.Show();
            this.Hide();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            label6.Text = LauncherSettings.launchername;
            Console.WriteLine("Done");
        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void label5_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(LauncherSettings.launcherwebhookregisterpage);
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            MySqlConnection db = new MySqlConnection("Server=" + LauncherSettings.mdbsvip + ";" + "Database=" + LauncherSettings.mdbname + ";" + "Uid=" + LauncherSettings.mdbuser + ";" + "Pwd=" + LauncherSettings.mdbpassword + ";");
            Console.WriteLine("Checking if the username textbox is clear");
            if (txtusername.Text == "")
            {
                Console.WriteLine("Error you need to fill in the username textbox!");
                MessageBox.Show("You Need To Enter Your Username Here!");
            }
            else
            {
                Console.WriteLine("Check done!");
                Console.WriteLine("Checking if the password textbox is clear");
                if (txtpassword.Text == "")
                {
                    Console.WriteLine("Error you need to fill in the password textbox!");
                    MessageBox.Show("You need to enter a password!");
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
                    cmd.CommandText = "SELECT * FROM users where username='" + txtusername.Text + "' or email='" + txtusername.Text + "' AND password='" + txtpassword.Text + "'";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (txtusername.Text == "Fuck")
                        {
                            Console.WriteLine("Error This username is banned!");
                            MessageBox.Show("This Username Is Banned", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (txtusername.Text == "Cum")
                        {
                            Console.WriteLine("Error This username is banned!");
                            MessageBox.Show("This Username Is Banned", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (txtusername.Text == "Dick")
                        {
                            Console.WriteLine("Error This username is banned!");
                            MessageBox.Show("This Username Is Banned", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (txtusername.Text == "fuck")
                        {
                            Console.WriteLine("Error This username is banned!");
                            MessageBox.Show("This Username Is Banned", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (txtusername.Text == "cum")
                        {
                            Console.WriteLine("Error This username is banned!");
                            MessageBox.Show("This Username Is Banned", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (txtusername.Text == "dick")
                        {
                            Console.WriteLine("Error This username is banned!");
                            MessageBox.Show("This Username Is Banned", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            Console.WriteLine("Succes!");
                            Console.WriteLine("Starting main form!");
                            UpdateSession(MSession.GetOfflineSession(txtusername.Text));

                        }

                    }
                    else
                    {
                        Console.WriteLine("Faild to check the account the username or passowrd is incorect!");
                        MessageBox.Show("This account dose not exists!", "Login Faild");
                    }
                    db.Close();
                    Console.WriteLine("Closing connection!");
                }
            }
        }
    }
}
