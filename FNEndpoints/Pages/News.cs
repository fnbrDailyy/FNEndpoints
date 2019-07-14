using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FNEndpoints.Pages
{
    public partial class News : UserControl
    {
        public News()
        {
            InitializeComponent();

            MyScintilla.ScintillaInstance(scintilla1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = Api.GetEndpoint("https://fortnitecontent-website-prod07.ol.epicgames.com/content/api/pages/fortnite-game", false, RestSharp.Method.GET);
            var obj = JsonConvert.DeserializeObject(response);
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            scintilla1.ReadOnly = false;
            scintilla1.Text = json;
            scintilla1.ReadOnly = true;
        }
    }
}
