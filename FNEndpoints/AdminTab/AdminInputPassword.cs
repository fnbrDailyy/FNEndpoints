using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints.AdminTab
{
    public partial class AdminInputPassword : Form
    {
        public AdminInputPassword()
        {
            InitializeComponent();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.passwordField.UseSystemPasswordChar = !this.checkBox1.Checked;
        }
    }
}
