using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PIS
{
    public partial class Form3 : Form
    {

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();

        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=personal_pis");
        public Form3()
        {
            InitializeComponent();

            name.Text = Program.Name;
            phone.Text = Program.Phone;
            role.Text = Program.Role;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dialoge df = new Dialoge();
            df.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
