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

        public AdminTab(string password)
        {

            if(ComputeSha256Hash(password) == passwordHash)
            {
                InitializeComponent();
            } else
            {
                Close();
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
    }
}
