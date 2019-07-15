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
            DialogResult = DialogResult.OK;
            AdminTab adminTab = new AdminTab(passwordField.Text);
            if (adminTab.show)
            {
                adminTab.Show();
                adminTab.Focus();
            }
            else
            {
                adminTab.Close();
            }
            Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.passwordField.UseSystemPasswordChar = !this.checkBox1.Checked;
        }
    }
}
