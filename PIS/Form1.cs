using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            textBox1.PasswordChar = '*';
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            String passUser = textBox1.Text;
            String loginUser = comboBox1.Text;
            String phoneUser = textBox2.Text;

            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM autorizathion WHERE role = @uR AND pass = @uP AND НомерТелефона = @uN", db.getConnection());
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
            command.Parameters.Add("@uR", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = phoneUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Program.ID = table.Rows[0]["ID"].ToString();
                Program.Name = table.Rows[0]["ФИО"].ToString();
                Program.Phone = table.Rows[0]["НомерТелефона"].ToString();
                Program.Zp = table.Rows[0]["Зарплата"].ToString();
                Program.Role = table.Rows[0]["role"].ToString();
                if (Program.Role == "HR")
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else if(Program.Role == "Менеджер")
                {
                    Form3 f3 = new Form3();
                    f3.Show();
                    this.Hide();
                }
                else if(Program.Role == "Администратор")
                {
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный номер телефона или пароль");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.WindowState = FormWindowState.Maximized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
