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
    public partial class Form7 : Form
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();

        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=root;database=personal_pis");

        public Form7()
        {
            InitializeComponent();

            DB db = new DB();
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM autorizathion", db.getConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = loadData("SELECT * FROM autorizathion", "autorizathion");
                dataGridView1.Columns["ID"].ReadOnly = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private BindingSource bindingSource = new BindingSource();
        private MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        private DataSet dataSet = new DataSet();
        string currentTableName;

        private BindingSource loadData(string query, string tableName)
        {
            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            dataAdapter.SelectCommand = command;
            currentTableName = tableName;

            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);

            dataAdapter.Fill(dataSet, tableName);
            dataAdapter.UpdateCommand = builder.GetUpdateCommand();
            bindingSource.DataSource = dataSet.Tables[currentTableName];

            db.closeConnection();

            return bindingSource;
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {

                dataAdapter.Update(dataSet, currentTableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
