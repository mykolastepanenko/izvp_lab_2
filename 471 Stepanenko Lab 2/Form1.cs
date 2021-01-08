using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _471_Stepanenko_Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            fileItem.DropDownItems.Add("Закрити");
            fileItem.DropDownItems[0].Click += aboutItem_Click;
            menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.DropDownItems.Add("Автор: Степаненко М.І. 471");
            menuStrip1.Items.Add(aboutItem);
        }

        private void aboutItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" && textBox2.Text == "" && dataGridView1.Columns.Count == 0)
            {
                MessageBox.Show("Ви не ввели X або У, отже було створено масив розміром 2х2.");
                dataGridView1.Columns.Add("one", "one");
                dataGridView1.Columns.Add("two", "two");
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
            }
            else
            {
                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    dataGridView1.Columns.Add("Column " + (i + 1).ToString(), "Column " + (i + 1).ToString());
                }
                for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                {
                    dataGridView1.Rows.Add("Column " + (i + 1).ToString(), "Column " + (i + 1).ToString());
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if(radioButton1.Checked == true)
            {
                //ввод з клавіатури
            }
            else if (radioButton2.Checked == true)
            {
                //ввод з файлу
            }
            else if (radioButton3.Checked == true)
            {
                //ввод рандомом
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++) 
                {
                    for(int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = random.Next(1, 11);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int dob = 1, count = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if(j > i)
                    {
                        dob *= Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        count++;
                    }
                }
            }
            MessageBox.Show("Добуток: " + dob.ToString() + "\nКількість: " + count.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
