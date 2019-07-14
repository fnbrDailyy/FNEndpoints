namespace FNEndpoints
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.news_button = new System.Windows.Forms.Button();
            this.ltm_button = new System.Windows.Forms.Button();
            this.timeline_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.aesKeys1 = new FNEndpoints.Pages.AesKeys();
            this.news1 = new FNEndpoints.Pages.News();
            this.ltm1 = new FNEndpoints.Pages.LTM();
            this.timeline1 = new FNEndpoints.Pages.Timeline();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1191, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.news_button);
            this.panel1.Controls.Add(this.ltm_button);
            this.panel1.Controls.Add(this.timeline_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 681);
            this.panel1.TabIndex = 1;
            // 
            // news_button
            // 
            this.news_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.news_button.Location = new System.Drawing.Point(0, 89);
            this.news_button.Name = "news_button";
            this.news_button.Size = new System.Drawing.Size(200, 91);
            this.news_button.TabIndex = 2;
            this.news_button.Text = "News";
            this.news_button.UseVisualStyleBackColor = true;
            this.news_button.Click += new System.EventHandler(this.news_button_Click);
            // 
            // ltm_button
            // 
            this.ltm_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltm_button.Location = new System.Drawing.Point(0, 267);
            this.ltm_button.Name = "ltm_button";
            this.ltm_button.Size = new System.Drawing.Size(200, 91);
            this.ltm_button.TabIndex = 1;
            this.ltm_button.Text = "LTM";
            this.ltm_button.UseVisualStyleBackColor = true;
            this.ltm_button.Enabled = false;
            this.ltm_button.Click += new System.EventHandler(this.ltm_button_Click);
            // 
            // timeline_button
            // 
            this.timeline_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeline_button.Location = new System.Drawing.Point(0, 0);
            this.timeline_button.Name = "timeline_button";
            this.timeline_button.Size = new System.Drawing.Size(200, 91);
            this.timeline_button.TabIndex = 0;
            this.timeline_button.Text = "Timeline";
            this.timeline_button.UseVisualStyleBackColor = true;
            this.timeline_button.Click += new System.EventHandler(this.timeline_button_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 91);
            this.button1.TabIndex = 3;
            this.button1.Text = "AesKeys";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // aesKeys1
            // 
            this.aesKeys1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aesKeys1.Location = new System.Drawing.Point(200, 24);
            this.aesKeys1.Name = "aesKeys1";
            this.aesKeys1.Size = new System.Drawing.Size(991, 681);
            this.aesKeys1.TabIndex = 4;
            // 
            // news1
            // 
            this.news1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.news1.Location = new System.Drawing.Point(200, 24);
            this.news1.Name = "news1";
            this.news1.Size = new System.Drawing.Size(991, 681);
            this.news1.TabIndex = 3;
            // 
            // ltm1
            // 
            this.ltm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltm1.Location = new System.Drawing.Point(200, 24);
            this.ltm1.Name = "ltm1";
            this.ltm1.Size = new System.Drawing.Size(991, 681);
            this.ltm1.TabIndex = 2;
            // 
            // timeline1
            // 
            this.timeline1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeline1.Location = new System.Drawing.Point(200, 24);
            this.timeline1.Name = "timeline1";
            this.timeline1.Size = new System.Drawing.Size(991, 681);
            this.timeline1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 705);
            this.Controls.Add(this.aesKeys1);
            this.Controls.Add(this.news1);
            this.Controls.Add(this.ltm1);
            this.Controls.Add(this.timeline1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "FNEndpoints";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button timeline_button;
        private Pages.Timeline timeline1;
        private System.Windows.Forms.Button ltm_button;
        private Pages.LTM ltm1;
        private System.Windows.Forms.Button news_button;
        private Pages.News news1;
        private System.Windows.Forms.Button button1;
        private Pages.AesKeys aesKeys1;
    }
}

