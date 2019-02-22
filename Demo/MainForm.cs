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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //string s = System.IO.File.ReadAllText(@"E:\fengxinxin\RTGUIBuilder\RTGUIBuilder\bin\Debug\ProjectName19\ProjectName19\keyboard\keyboard.js");
        }

        private void addFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.MdiParent = this;
            fm1.Show();

        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
