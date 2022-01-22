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
    public partial class Dialoge : Form
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();


        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=personal_pis");
        public Dialoge()
        {
            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Сотрудники по должности")
            {
                comboBox2.Visible = true;
                comboBox3.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                dataGridOtpusk.Visible = false;
                dataGridView1.Visible = true;
            }
            else if (comboBox1.Text == "График работы")
            {
                comboBox3.Visible = true;
                comboBox2.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                dataGridOtpusk.Visible = false;
                dataGridView1.Visible = true;
            }
            else if (comboBox1.Text == "Отпуска")
            {
                dataGridView1.Visible = false;
                dataGridOtpusk.Visible = true;
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;

                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command1 = new MySqlCommand("SELECT * FROM otpusk", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command1);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridOtpusk.DataSource = ds.Tables[0];
                }
            }
                else
                {
                comboBox3.Visible = false;
                comboBox2.Visible = false;
                }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "5/2")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, График FROM autorizathion Where График = '5/2' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if(comboBox3.Text == "2/2")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, График FROM autorizathion Where График = '2/2' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }    
            else if(comboBox3.Text == "Без выходных")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, График FROM autorizathion Where График = 'Без выходных' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox2.Text == "Директор")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, role as Должность FROM autorizathion Where role = 'Директор' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox2.Text == "HR")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, role as Должность FROM autorizathion Where role = 'HR' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox2.Text == "Кассир")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, role as Должность FROM autorizathion Where role = 'Кассир' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox2.Text == "Менеджер")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, role as Должность FROM autorizathion Where role = 'Менеджер' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox2.Text == "Продавец")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, role as Должность FROM autorizathion Where role = 'Продавец' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (comboBox2.Text == "Администратор")
            {
                DB db = new DB();
                {
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT ФИО, НомерТелефона, role as Должность FROM autorizathion Where role = 'Администратор' ", db.getConnection());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dialoge_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }
    }
}
