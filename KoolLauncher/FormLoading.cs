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
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 100)
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
            Console.WriteLine("Loading debug tools...");
            Console.WriteLine("Done");

        }
    }
}
