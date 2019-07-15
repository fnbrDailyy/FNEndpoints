using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints
{
    public partial class ImageViewer : Form
    {
        string url;
        public ImageViewer(string url = "")
        {
            this.url = url;
            InitializeComponent();

            pictureBox1.Load(url);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = url.Split('/').Last();
            saveFileDialog1.Filter = "Image Files|*." + url.Split('.').Last();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFile(url, saveFileDialog1.FileName);
                }
            }
        }

        private void DragDropImage()
        {
            var filename = url.Split('/').Last();
            var path = Path.Combine(Path.GetTempPath(), filename);
            this.pictureBox1.Image.Save(path);
            var paths = new[] { path };
            this.pictureBox1.DoDragDrop(new DataObject(DataFormats.FileDrop, paths), DragDropEffects.Copy);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.DragDropImage();
        }
    }
}
