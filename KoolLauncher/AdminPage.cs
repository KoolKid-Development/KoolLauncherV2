using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoolLauncherV2
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + KoolLauncher.adminaccountname + "!";
            label6.Text = LauncherSettings.launchername;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            AdminShowUsers asu = new AdminShowUsers();
            asu.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AdminShowAdminUsers asua = new AdminShowAdminUsers();
            asua.Show();
        }
    }
}
