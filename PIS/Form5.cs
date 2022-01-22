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
    public partial class Form5 : Form
    {
        public Form5(string qs)
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO autorizathion (pass, role, ФИО, НомерТелефона, График, Зарплата) VALUES (@pass,@role, @fio, @phone, @graphik, @zp)", db.getConnection());

            command.Parameters.Add("@role", MySqlDbType.VarChar).Value = comboBox2.Text;
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@graphik", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@zp", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = "";

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Сотрудник успешно добавлен");
            else
                MessageBox.Show("Неверно введены данные");


            db.closeConnection();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
