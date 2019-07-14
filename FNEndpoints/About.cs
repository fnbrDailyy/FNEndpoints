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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void twitter_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/BRLeaks_");
        }

        private void instragram_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://instagram.com/fnbrDailyy");
        }

        private void twitter_support_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/FNEndpoints");
        }

        private void discord_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/fxDtfuN");
        }

        private void reddit_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.reddit.com/user/BRLeaks_/");
        }
    }
}
