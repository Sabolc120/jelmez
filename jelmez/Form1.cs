using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jelmez
{
    public partial class Form1 : Form
    {
        static String jelmez;
       static DateTime date = DateTime.Now;
       static DateTime newDate = date.AddHours(1);
       static TimeSpan time = new TimeSpan(1);
        Jelmez jelmez1 = new Jelmez("Tigriske", 4000, newDate, false);
        Jelmez jelmez2 = new Jelmez("Pókocska", 5000, newDate, false);
        Jelmez jelmez3 = new Jelmez("Libácska", 6000, newDate, false);
        public Form1()
        {
            InitializeComponent();
            label3.Visible = false;
            numericUpDown1.Visible = false;
            label5.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            label6.Visible = false;
            // hours, minutes, seconds

            dataGridView1.Rows.Add(jelmez1.CostumeName, jelmez1.CostumePrice, jelmez1.CostumeLimit);
            dataGridView1.Rows.Add(jelmez2.CostumeName, jelmez2.CostumePrice, jelmez2.CostumeLimit);
            dataGridView1.Rows.Add(jelmez3.CostumeName, jelmez3.CostumePrice, jelmez3.CostumeLimit);


            comboBox1.Text = "Választék";
            comboBox1.Items.Add(jelmez1.CostumeName);
            comboBox1.Items.Add(jelmez2.CostumeName);
            comboBox1.Items.Add(jelmez3.CostumeName);

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            jelmez = comboBox1.SelectedItem.ToString();
            label3.Text = "Választott jelmez: "+jelmez;
            switch (jelmez)
            {
                case "Tigriske":
                        label4.Text = "Fizetendő: (Ezresek száma) " + jelmez1.CostumePrice / 1000;
                    break;
                case "Pókocska":
                    label4.Text = "Fizetendő: (Ezresek száma) " + jelmez2.CostumePrice / 1000;
                    break;
                case "Libácska":
                    label4.Text = "Fizetendő: (Ezresek száma) " + jelmez3.CostumePrice / 1000;
                    break;
            }
            label4.Visible = true;
            numericUpDown1.Visible = true;
            label3.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            switch (jelmez)
            {
                case "Tigriske":
                    if (numericUpDown1.Value == jelmez1.CostumePrice / 1000)
                    {
                        label6.Text = "Köszönjük a vásárlást.";
                    }
                    else if (numericUpDown1.Value > jelmez1.CostumePrice / 1000)
                    {
                        label6.Text = "Túl sok money!!";
                    }
                    else
                    {
                        label6.Text = "Nem elegendő pénz.";
                    }
                    break;
                case "Pókocska":
                    label4.Text = "Fizetendő: (Ezresek száma) " + jelmez2.CostumePrice / 1000;
                    if (numericUpDown1.Value == jelmez2.CostumePrice / 1000)
                    {
                        label6.Text = "Köszönjük a vásárlást.";
                    }
                    else if (numericUpDown1.Value > jelmez2.CostumePrice / 1000)
                    {
                        label6.Text = "Túl sok money!!";
                    }
                    else
                    {
                        label6.Text = "Nem elegendő pénz.";
                    }
                    break;
                case "Libácska":
                    label4.Text = "Fizetendő: (Ezresek száma) " + jelmez3.CostumePrice / 1000;
                    if (numericUpDown1.Value == jelmez3.CostumePrice / 1000)
                    {
                        label6.Text = "Köszönjük a vásárlást.";
                    }
                    else if (numericUpDown1.Value > jelmez3.CostumePrice / 1000)
                    {
                        label6.Text = "Túl sok money!!";
                    }
                    else
                    {
                        label6.Text = "Nem elegendő pénz.";
                    }
                    break;
            }
        }
    }
}
