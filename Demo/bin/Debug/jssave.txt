using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MonacoNET;

namespace Demo
{
    public partial class Form1 : Form
    {
        private string FilePath = "jssave.txt";

        public Form1()
        {
            InitializeComponent();
            monaco.PreviewKeyDown += Form1_PreviewKeyDown;
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
        }

        void Save(string savepath = "")
        {
            string getSrc = monaco.GetText();
            System.IO.File.WriteAllText(string.IsNullOrEmpty(savepath) ? FilePath : savepath, getSrc.Replace("`", "\\`"), Encoding.UTF8);
        }

        private void LoadJs()
        {
            try
            {
                string coderec = System.IO.File.ReadAllText(FilePath, Encoding.UTF8).Replace(@"\", @"\\").Replace("`", @"\`");
                monaco.SetText(coderec);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LoadJs();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = ".TXT|*.txt|ALL|*.*", Multiselect = false };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
                LoadJs();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = ".txt|*.txt" };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Save(saveFileDialog.FileName);
            }
        }

        private void showMiniMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monaco.MinimapEnabled = !showMiniMapToolStripMenuItem.Checked;
            showMiniMapToolStripMenuItem.Checked = !showMiniMapToolStripMenuItem.Checked;
        }

        private void setThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setThemeToolStripMenuItem.Tag.ToString() == "Dark")
            {
                setThemeToolStripMenuItem.Tag = "Light";
                monaco.SetTheme(MonacoTheme.Light);
            }
            else
            {
                setThemeToolStripMenuItem.Tag = "Dark";
                monaco.SetTheme(MonacoTheme.Dark);
            }
        }
    }
}
