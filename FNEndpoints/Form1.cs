using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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

            openPage(null);
        }
        
        async public void update()
        {
            var currentVersion = Assembly.GetEntryAssembly().GetName().Version;
            string jsonReponse = await getNewestUpdateResponse();
            if(jsonReponse != "")
            {
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
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");
                return await httpClient.GetStringAsync("https://api.github.com/repos/fnbrDailyy/FNEndpoints/releases/latest");
            } catch(HttpRequestException)
            {
                return "";
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings();
            if (Application.OpenForms[settingsForm.Name] == null)
            {
                settingsForm.Show();
            }
            else
            {
                Application.OpenForms[settingsForm.Name].Focus();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openPage(UserControl form)
        {
            timeline1.Visible = form == timeline1 ? true : false;
            ltm1.Visible = form == ltm1 ? true : false;
            news1.Visible = form == news1 ? true : false;
            aesKeys1.Visible = form == aesKeys1 ? true : false;
        }

        private void timeline_button_Click(object sender, EventArgs e)
        {
            openPage(timeline1);
        }

        private void ltm_button_Click(object sender, EventArgs e)
        {
            openPage(ltm1);
        }

        private void news_button_Click(object sender, EventArgs e)
        {
            openPage(news1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openPage(aesKeys1);
        }
    }
}
