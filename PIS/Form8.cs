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
    public partial class Form8 : Form
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();

        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=personal_pis");

        public Form8()
        {
            InitializeComponent();

            DB db = new DB();
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `role` as 'Должность', `ФИО`, `НомерТелефона`, `Зарплата`, `График` FROM autorizathion", db.getConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["ID"].ReadOnly = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
