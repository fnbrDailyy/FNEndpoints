using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace FNEndpoints.Pages
{
    public partial class AesKeys : UserControl
    {
        public AesKeys()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scintilla1.ReadOnly = false;
            scintilla1.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(Api.GetAesKeys()), Formatting.Indented);
            scintilla1.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("http://benbotfn.tk:8080/api/aes");
        }
    }
}
