using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            update();
        }
        
        async public void update()
        {
            var currentVersion = Assembly.GetEntryAssembly().GetName().Version;
            string jsonReponse = await getNewestUpdateResponse();

            dynamic json = JsonConvert.DeserializeObject(jsonReponse);

            var newVersion = new Version(Convert.ToString(json.tag_name));
            if (newVersion > currentVersion)
            {
                DialogResult dialogResult = MessageBox.Show("Update available, \nDo you want to update? \n\nYou have version " + currentVersion.ToString() + " and newest version is " + newVersion.ToString(), "Update available", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowUpdateForm(Convert.ToString(json.assets[0].browser_download_url));


                }
            }

        }

        public static void ShowUpdateForm(string url)
        {
            var updateForm = new DownloadUpdateDialog(url);
            if (updateForm.ShowDialog().Equals(DialogResult.OK))
            {
                Application.Exit();
            }
        }

        async public Task<string> getNewestUpdateResponse()
        {

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");
            return await httpClient.GetStringAsync("https://api.github.com/repos/fnbrDailyy/FNEndpoints/releases/latest");
        }

    }
}
