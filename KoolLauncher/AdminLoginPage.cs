using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace KoolLauncherV2
{
    public partial class KoolLauncher : Form
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        public static string adminaccountname;
        public KoolLauncher()
        {            
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            MySqlConnection db = new MySqlConnection("Server=" + LauncherSettings.mdbsvip + ";" + "Database=" + LauncherSettings.mdbname + ";" + "Uid=" + LauncherSettings.mdbuser + ";" + "Pwd=" + LauncherSettings.mdbpassword + ";");
            string user = txtusername.Text;
            string pass = txtpassword.Text;
            cmd = new MySqlCommand();
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "SELECT * FROM adminusers where username='" + txtusername.Text + "' or email='"+ txtusername.Text +"' AND password='" + txtpassword.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                adminaccountname = txtusername.Text;
                AdminPage succes = new AdminPage();
                succes.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("This account dose not exists!", "Login Faild");
            }
            db.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AdminLoginPage_Load(object sender, EventArgs e)
        {
            label6.Text = LauncherSettings.launchername;
        }
    }
}
