﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using FNEndpoints.Properties;

namespace FNEndpoints.Pages
{
    public partial class Store : UserControl
    {
        public Store()
        {
            InitializeComponent();
        }

        public void updateSettings()
        {
            this.button1.Image = (Properties.Settings.Default.Images) ? (Resources.load) : null;
            this.button1.Text = (Properties.Settings.Default.Images) ? "" : "Load";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myScintilla1.setText(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(Api.GetEndpoint("https://fortnite-public-service-prod11.ol.epicgames.com/fortnite/api/storefront/v2/catalog", true, Method.GET)), Formatting.Indented));
        }
    }
}
