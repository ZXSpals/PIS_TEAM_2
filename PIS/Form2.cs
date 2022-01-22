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
    public partial class Form2 : Form
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();

        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=personal_pis");


        public Form2()
        {
            InitializeComponent();

            name.Text = Program.Name;
            phone.Text = Program.Phone;
            role.Text = Program.Role;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(name.Text);
            f5.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
