using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PIS
{
    public partial class LoadScreen : Form
    {


        public LoadScreen()
        {
            InitializeComponent();

            Form1 f1 = new Form1();
            Timer t = new Timer();
            t.Interval = 10 * 600;
            t.Tick += delegate { this.Hide(); };
            t.Start();
            f1.Show();
        }

        private void LoadScreen_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
