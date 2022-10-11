using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projekt
{
    public partial class Form1 : Form
    {
        static int jelmezAr;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "Választék";
            comboBox1.Items.Add("Tigriske");
            comboBox1.Items.Add("Pókocska");
            comboBox1.Items.Add("Libácska");
            holder1.Visible = false;
            holder2.Visible = false;
            holder3.Visible = false;
            ID.Visible = false;
            holder4.Visible = false;
            LoadData();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=jelmez.db;Version=3;New=False;Compress=True;");
        }
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from jelmezek";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String jelmezNev = comboBox1.SelectedItem.ToString();
            int napokSzama = Convert.ToInt32(numericUpDown1.Value);
            switch (jelmezNev)
            {
                case "Pókocska":
                    label2.Text = "Választott jelmez: " + jelmezNev;
                    label5.Text = "Jelmez ára: " + napokSzama * 2500;
                    label4.Text = "Napok száma: " + napokSzama;
                    holder1.Text = jelmezNev;
                    holder2.Value = napokSzama * 2500;
                    holder3.Value = napokSzama;
                    holder4.Text = textBox1.Text;
                    ID.Value = 1;

                    break;
                case "Libácska":
                    label2.Text = "Választott jelmez: " + jelmezNev;
                    label5.Text = "Jelmez ára: " + napokSzama * 3500;
                    label4.Text = "Napok száma: " + napokSzama;
                    holder1.Text = jelmezNev;
                    holder2.Value = napokSzama * 3500;
                    holder3.Value = napokSzama;
                    ID.Value = 2;
                    holder4.Text = textBox1.Text;

                    break;
                case "Tigriske":
                    label2.Text = "Választott jelmez: " + jelmezNev;
                    label5.Text = "Jelmez ára: " + napokSzama * 5500;
                    label4.Text = "Napok száma: " + napokSzama;
                    holder1.Text = jelmezNev;
                    holder2.Value = napokSzama * 5500;
                    holder3.Value = napokSzama;
                    ID.Value = 3;
                    

                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Helytelen telefonszám");
            }
            else
            {
                holder4.Text = textBox1.Text;
                insertOrderDetails();
            }
        }
        private void insertOrderDetails()
        {
            string txtQuery = $"INSERT INTO orders (days, phoneNumber, costumeId) VALUES ('{holder3.Value}', '{holder4.Text}', '{ID.Value}');";
            ExecuteQuery(txtQuery);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 opform = new Form2();
            opform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 opForm = new Form3();
            opForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
