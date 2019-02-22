namespace Demo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.monaco = new MonacoNET.Monaco();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMiniMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeReductionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontIncreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 70;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // monaco
            // 
            this.monaco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monaco.Location = new System.Drawing.Point(0, 25);
            this.monaco.MinimapEnabled = false;
            this.monaco.MinimumSize = new System.Drawing.Size(20, 20);
            this.monaco.Name = "monaco";
            this.monaco.ReadOnly = false;
            this.monaco.RenderWhitespace = "none";
            this.monaco.ScriptErrorsSuppressed = true;
            this.monaco.Size = new System.Drawing.Size(616, 505);
            this.monaco.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMiniMapToolStripMenuItem,
            this.setThemeToolStripMenuItem,
            this.fontSizeReductionToolStripMenuItem,
            this.fontIncreaseToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // showMiniMapToolStripMenuItem
            // 
            this.showMiniMapToolStripMenuItem.Name = "showMiniMapToolStripMenuItem";
            this.showMiniMapToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showMiniMapToolStripMenuItem.Text = "show miniMap";
            this.showMiniMapToolStripMenuItem.Click += new System.EventHandler(this.showMiniMapToolStripMenuItem_Click);
            // 
            // setThemeToolStripMenuItem
            // 
            this.setThemeToolStripMenuItem.Name = "setThemeToolStripMenuItem";
            this.setThemeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.setThemeToolStripMenuItem.Tag = "Dark";
            this.setThemeToolStripMenuItem.Text = "SetTheme";
            this.setThemeToolStripMenuItem.Click += new System.EventHandler(this.setThemeToolStripMenuItem_Click);
            // 
            // fontSizeReductionToolStripMenuItem
            // 
            this.fontSizeReductionToolStripMenuItem.Name = "fontSizeReductionToolStripMenuItem";
            this.fontSizeReductionToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.fontSizeReductionToolStripMenuItem.Text = "Font size reduction";
            this.fontSizeReductionToolStripMenuItem.ToolTipText = "Ctrl ++";
            // 
            // fontIncreaseToolStripMenuItem
            // 
            this.fontIncreaseToolStripMenuItem.Name = "fontIncreaseToolStripMenuItem";
            this.fontIncreaseToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.fontIncreaseToolStripMenuItem.Text = "Font increase";
            this.fontIncreaseToolStripMenuItem.ToolTipText = "Ctrl --";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 530);
            this.Controls.Add(this.monaco);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private MonacoNET.Monaco monaco;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMiniMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontSizeReductionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontIncreaseToolStripMenuItem;
    }
}

