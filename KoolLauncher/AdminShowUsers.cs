﻿using MySql.Data.MySqlClient;
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
    public partial class AdminShowUsers : Form
    {

       

        public AdminShowUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AdminShowUsers_Load(object sender, EventArgs e)
        {
            label6.Text = LauncherSettings.launchername;
            MySqlConnection db = new MySqlConnection("Server=" + LauncherSettings.mdbsvip + ";" + "Database=" + LauncherSettings.mdbname + ";" + "Uid=" + LauncherSettings.mdbuser + ";" + "Pwd=" + LauncherSettings.mdbpassword + ";");
            db.Open();
            MySqlCommand komut = new MySqlCommand("SELECT * from users", db);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            MySqlConnection db = new MySqlConnection("Server=" + LauncherSettings.mdbsvip + ";" + "Database=" + LauncherSettings.mdbname + ";" + "Uid=" + LauncherSettings.mdbuser + ";" + "Pwd=" + LauncherSettings.mdbpassword + ";");
            db.Open();
            MySqlCommand cmdadd = new MySqlCommand("INSERT INTO `users` (`id`, `username`, `email`, `password`) VALUES ('" + newid.Text + "', '" + newuser.Text + "', '" + newemail.Text + "', '" + newpassword.Text + "');", db);
            MySqlDataAdapter da = new MySqlDataAdapter(cmdadd);
            MySqlCommand komut1 = new MySqlCommand("SELECT * from users", db);
            MySqlDataAdapter da1 = new MySqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            db.Close();
            Load1 x = new Load1();
            x.Show();
            this.Hide();
        }

        private void btnuserdelete_Click(object sender, EventArgs e)
        {
            MySqlConnection db = new MySqlConnection("Server=" + LauncherSettings.mdbsvip + ";" + "Database=" + LauncherSettings.mdbname + ";" + "Uid=" + LauncherSettings.mdbuser + ";" + "Pwd=" + LauncherSettings.mdbpassword + ";");
            db.Open();
            MySqlCommand cmddelete = new MySqlCommand("DELETE FROM `users` WHERE `users`.`id` = '" + txtdeleteuserid.Text + "'", db);
            MySqlDataAdapter da = new MySqlDataAdapter(cmddelete);
            MySqlCommand komut1 = new MySqlCommand("SELECT * from users", db);
            MySqlDataAdapter da1 = new MySqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            db.Close();
            Load1 x = new Load1();
            x.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MySqlConnection db = new MySqlConnection("Server=" + LauncherSettings.mdbsvip + ";" + "Database=" + LauncherSettings.mdbname + ";" + "Uid=" + LauncherSettings.mdbuser + ";" + "Pwd=" + LauncherSettings.mdbpassword + ";");
            db.Open();
            MySqlCommand komut = new MySqlCommand("SELECT * from users", db);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            db.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(deleteuser);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(adduser);
        }
    }
}