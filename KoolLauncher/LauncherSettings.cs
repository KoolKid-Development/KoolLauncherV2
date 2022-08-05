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
    public partial class LauncherSettings : Form
    {
        public LauncherSettings()
        {
            InitializeComponent();
        }
        public static string mdbsvip; //MySqlServerDataBaseIp
        public static string mdbname; //MySqlDataBaseName
        public static string mdbuser; //MySqlDataBaseUserName
        public static string mdbpassword; //MysqlDatabasePassword
        public static string elinks; //portal page links!
        public static string launcherwebhookregisterpage; //The launcher register page!
        public static string forumurl; //The forum page off your mc server
        public static string storeurl; //The store page off your my server
        public static string discordurl;
        public static string voteurl;
        public static string mcserverip;
        public static string mcserverport;
        public static string launchername;
        private void MySqlConnector_Load(object sender, EventArgs e)
        {          
            
            if(elinksvalue.Text == "0")
            {
                hideme(true);
                mdbsvip = mysqlhost.Text;
                mdbname = mysqldatabasename.Text;
                mdbuser = mysqlusername.Text;
                mdbpassword = mysqlpassword.Text;
                elinks = elinksvalue.Text;
                launcherwebhookregisterpage = txtlauncherregsiterpage.Text;
                mcserverip = txtsvip.Text;
                mcserverport = txtsvport.Text;
                forumurl = txtforumurl.Text;
                storeurl = txtstoreurl.Text;
                discordurl = txtdiscordurl.Text;
                voteurl = txtvoteurl.Text;
                launchername = txtlaunchername.Text;   
                this.Hide();
            }
            else if(elinksvalue.Text == "1")
            {
                hideme(true);
                mdbsvip = mysqlhost.Text;
                mdbname = mysqldatabasename.Text;
                mdbuser = mysqlusername.Text;
                mdbpassword = mysqlpassword.Text;
                elinks = elinksvalue.Text;
                launcherwebhookregisterpage = txtlauncherregsiterpage.Text;
                mcserverip = txtsvip.Text;
                mcserverport = txtsvport.Text;
                forumurl = txtforumurl.Text;
                storeurl = txtstoreurl.Text;
                discordurl = txtdiscordurl.Text;
                voteurl = txtvoteurl.Text;
                launchername = txtlaunchername.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("You can only use 0 and 1 for the portal links option "+
                    "1 = true 0 = false");
                Application.Exit();
            }
            
        }

        private void dbname_TextChanged(object sender, EventArgs e)
        {

        }
        private void hideme(bool value)
        {
            mysqlhost.UseSystemPasswordChar = value;
            mysqldatabasename.UseSystemPasswordChar = value;
            mysqldatabasename.UseSystemPasswordChar = value;
            mysqlpassword.UseSystemPasswordChar = value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void elinksvalue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
