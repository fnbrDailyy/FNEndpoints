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
    public partial class Timeline : UserControl
    {
        public Timeline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = Api.GetEndpoint("https://fortnite-public-service-prod11.ol.epicgames.com/fortnite/api/calendar/v1/timeline", true, RestSharp.Method.GET);
            var json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(response), Formatting.Indented);

            scintilla1.ReadOnly = false;
            scintilla1.Text = json;
            scintilla1.ReadOnly = true;

        }
    }
}
