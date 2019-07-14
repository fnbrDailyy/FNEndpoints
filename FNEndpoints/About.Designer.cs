namespace FNEndpoints
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.footer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.twitter_button = new System.Windows.Forms.Button();
            this.instragram_button = new System.Windows.Forms.Button();
            this.twitter_support_button = new System.Windows.Forms.Button();
            this.discord_button = new System.Windows.Forms.Button();
            this.reddit_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.footer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 25);
            this.panel1.TabIndex = 0;
            // 
            // footer
            // 
            this.footer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footer.Location = new System.Drawing.Point(0, 0);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(280, 25);
            this.footer.TabIndex = 0;
            this.footer.Text = "Copyright 2019 © Joel. S";
            this.footer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 396);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.reddit_button, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.discord_button, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.twitter_support_button, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.instragram_button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.twitter_button, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // twitter_button
            // 
            this.twitter_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twitter_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twitter_button.Image = global::FNEndpoints.Properties.Resources.twitter;
            this.twitter_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.twitter_button.Location = new System.Drawing.Point(0, 0);
            this.twitter_button.Margin = new System.Windows.Forms.Padding(0);
            this.twitter_button.Name = "twitter_button";
            this.twitter_button.Size = new System.Drawing.Size(280, 79);
            this.twitter_button.TabIndex = 0;
            this.twitter_button.Text = "Twitter";
            this.twitter_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.twitter_button.UseVisualStyleBackColor = true;
            this.twitter_button.Click += new System.EventHandler(this.twitter_button_Click);
            // 
            // instragram_button
            // 
            this.instragram_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instragram_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instragram_button.Image = global::FNEndpoints.Properties.Resources.instagram;
            this.instragram_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.instragram_button.Location = new System.Drawing.Point(0, 79);
            this.instragram_button.Margin = new System.Windows.Forms.Padding(0);
            this.instragram_button.Name = "instragram_button";
            this.instragram_button.Size = new System.Drawing.Size(280, 79);
            this.instragram_button.TabIndex = 1;
            this.instragram_button.Text = "Instagram";
            this.instragram_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.instragram_button.UseVisualStyleBackColor = true;
            this.instragram_button.Click += new System.EventHandler(this.instragram_button_Click);
            // 
            // twitter_support_button
            // 
            this.twitter_support_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twitter_support_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twitter_support_button.Image = global::FNEndpoints.Properties.Resources.support;
            this.twitter_support_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.twitter_support_button.Location = new System.Drawing.Point(0, 158);
            this.twitter_support_button.Margin = new System.Windows.Forms.Padding(0);
            this.twitter_support_button.Name = "twitter_support_button";
            this.twitter_support_button.Size = new System.Drawing.Size(280, 79);
            this.twitter_support_button.TabIndex = 2;
            this.twitter_support_button.Text = "Twitter Support";
            this.twitter_support_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.twitter_support_button.UseVisualStyleBackColor = true;
            this.twitter_support_button.Click += new System.EventHandler(this.twitter_support_button_Click);
            // 
            // discord_button
            // 
            this.discord_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discord_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discord_button.Image = global::FNEndpoints.Properties.Resources.discord;
            this.discord_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.discord_button.Location = new System.Drawing.Point(0, 237);
            this.discord_button.Margin = new System.Windows.Forms.Padding(0);
            this.discord_button.Name = "discord_button";
            this.discord_button.Size = new System.Drawing.Size(280, 79);
            this.discord_button.TabIndex = 3;
            this.discord_button.Text = "Discord";
            this.discord_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.discord_button.UseVisualStyleBackColor = true;
            this.discord_button.Click += new System.EventHandler(this.discord_button_Click);
            // 
            // reddit_button
            // 
            this.reddit_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reddit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reddit_button.Image = global::FNEndpoints.Properties.Resources.reddit;
            this.reddit_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.reddit_button.Location = new System.Drawing.Point(0, 316);
            this.reddit_button.Margin = new System.Windows.Forms.Padding(0);
            this.reddit_button.Name = "reddit_button";
            this.reddit_button.Size = new System.Drawing.Size(280, 80);
            this.reddit_button.TabIndex = 4;
            this.reddit_button.Text = "Reddit";
            this.reddit_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.reddit_button.UseVisualStyleBackColor = true;
            this.reddit_button.Click += new System.EventHandler(this.reddit_button_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 421);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "About";
            this.ShowIcon = false;
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label footer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button twitter_button;
        private System.Windows.Forms.Button reddit_button;
        private System.Windows.Forms.Button discord_button;
        private System.Windows.Forms.Button twitter_support_button;
        private System.Windows.Forms.Button instragram_button;
    }
}