﻿using System;
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
        public Settings()
        {
            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.EpicEmail;
            textBox2.Text = Properties.Settings.Default.EpicPassword;
            LanguageComboBox.Text = Properties.Settings.Default.Language;
            textBox3.Text = Properties.Settings.Default.pakPath;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EpicEmail = textBox1.Text;
            Properties.Settings.Default.EpicPassword = textBox2.Text;
            Properties.Settings.Default.Language = LanguageComboBox.Text;
            Properties.Settings.Default.pakPath = textBox3.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
