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
    public partial class Form6 : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=personal_pis");

        public Form6()
        {
            InitializeComponent();

            DB db = new DB();
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM autorizathion", db.getConnection());
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    comboBox2.Items.Add(dataReader["ФИО"]);
                }
                dataReader.Close();
                db.closeConnection();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dialoge dForm = new Dialoge();
            dForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO otpusk (FIO, NachaloOptuska, KonecOtpuska) VALUES (@fio, @nach, @kon)", db.getConnection());

            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = comboBox2.Text;
            command.Parameters.Add("@nach", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@kon", MySqlDbType.VarChar).Value = textBox1.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Отпуск успешно назначен");
            else
                MessageBox.Show("Неверно введены данные");


            db.closeConnection();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }
    }
}
