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
    public partial class Load1 : Form
    {
        public Load1()
        {
            InitializeComponent();
        }

        private void Load1_Load(object sender, EventArgs e)
        {
            AdminShowUsers x = new AdminShowUsers();
            x.Show();
            this.Close();
        }
    }
}
