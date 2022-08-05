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
    public partial class Load2 : Form
    {
        public Load2()
        {
            InitializeComponent();
        }

        private void Load2_Load(object sender, EventArgs e)
        {
            AdminShowAdminUsers x = new AdminShowAdminUsers();
            x.Show();
            this.Close();
        }
    }
}
