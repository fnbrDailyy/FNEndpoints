using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints
{
    public partial class Settings : Form
    {
        Form1 mainForm;
        public Settings(Form1 form)
        {
            mainForm = form;

            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.EpicEmail;
            textBox2.Text = Properties.Settings.Default.EpicPassword;
            LanguageComboBox.Text = Properties.Settings.Default.Language;
            textBox3.Text = Properties.Settings.Default.pakPath;
            imagesCheckBox.Checked = Properties.Settings.Default.Images;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EpicEmail = textBox1.Text;
            Properties.Settings.Default.EpicPassword = textBox2.Text;
            Properties.Settings.Default.Language = LanguageComboBox.Text;
            Properties.Settings.Default.pakPath = textBox3.Text;
            Properties.Settings.Default.Images = imagesCheckBox.Checked;
            Properties.Settings.Default.Save();

            mainForm.updateSettings();

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = textBox3.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.UseSystemPasswordChar = !this.checkBox1.Checked;
        }
    }
}
