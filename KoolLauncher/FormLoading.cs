using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace KoolLauncherV2
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }
        MySqlConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["Default Connection"].ToString());
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Alert(string msg, FrmAlert.enmType type)
        {
            FrmAlert frm = new FrmAlert();
            frm.showAlert(msg, type);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 600)
            {
                timer1.Stop();
                Console.WriteLine("Starting login form..");
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Hide();
            txtversion.Hide();
            label1.Text = ProductVersion;
            txtlaunchername.Text = settings.ServerName;
            MySqlCommand command = db.CreateCommand();
            MySqlDataReader myReader;

            //Checks if the launcher version is the same as the database version!
            if (txtversion.Text == label1.Text)
            {
                MySqlCommand command2 = db.CreateCommand();
                MySqlDataReader myReader2;

                command2.CommandText = "SELECT stats FROM `status`";
                try
                {
                    db.Open();
                    myReader2 = command2.ExecuteReader();

                    while (myReader2.Read())
                    {
                        bunifuTextBox1.Text = myReader2[0].ToString();

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                db.Close();
                if (bunifuTextBox1.Text == "online")
                {
                    timer1.Enabled = true;
                }
                else
                {
                    Alert("Check our website:", FrmAlert.enmType.Error);
                    Alert("The launcher is offline!", FrmAlert.enmType.Error);
                    System.Diagnostics.Process.Start(settings.websitelink);
                    Application.Exit();
                }

            }
            else
            {
                Alert("You need to update the launcher", FrmAlert.enmType.Error);
                System.Diagnostics.Process.Start(settings.launcherdownloadlink);
                Application.Exit();
            }

            Console.WriteLine("Loading debug tools...");
            Console.WriteLine("Done");

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
