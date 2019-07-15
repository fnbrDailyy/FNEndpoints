using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FNEndpoints.AdminTab
{
    public partial class AdminTab : Form
    {

        private string passwordHash = "5A984EE50B1DE2224BAA3407A4578E52A70275D9AB36DE7E682C124C6B294233";
        private string passwordHash2 = "312433C28349F63C4F387953FF337046E794BEA0F9B9EBFCB08E90046DED9C76";

        public bool show = true;

        public AdminTab(string password)
        {
            if (ComputeSha256Hash(password).ToLower() == passwordHash.ToLower() || ComputeSha256Hash(password).ToLower() == passwordHash2.ToLower())
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Wrong Password!");
                show = false;
            }

        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.consumer_key = consumer_key.Text;
            Properties.Settings.Default.consumer_secret = consumer_secret.Text;
            Properties.Settings.Default.access_token_key = access_token_key.Text;
            Properties.Settings.Default.access_token_secret = access_token_secret.Text;
        }

        private void AdminTab_Load(object sender, EventArgs e)
        {
            consumer_key.Text = Properties.Settings.Default.consumer_key;
            consumer_secret.Text = Properties.Settings.Default.consumer_secret;
            access_token_key.Text = Properties.Settings.Default.access_token_key;
            access_token_secret.Text = Properties.Settings.Default.access_token_secret;
        }
    }
}
