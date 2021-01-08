using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.GetType().ToString());
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
                    dataGridView1.Rows.Add("");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if(radioButton1.Checked == true)
            {
                //ввод з клавіатури
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = false;
                    }
                }
            }
            else if (radioButton2.Checked == true)
            {
                //ввод з файлу
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
                using (StreamReader reader = new StreamReader(@"..\..\..\input.txt"))
                {
                    string line;
                    string[] words = new string[] { };
                    int count = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        words = line.Split(new char[] { ' ' });
                        for(int i = count; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = Convert.ToInt32(words[j]);
                            }
                        }
                        count++;
                    }
                }
            }
            else if (radioButton3.Checked == true)
            {
                //ввод рандомом
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++) 
                {
                    for(int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = random.Next(1, 11);
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
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
                    if(dataGridView1.Rows[i].Cells[j].Value.GetType().ToString() != typeof(int).ToString())
                    {
                        MessageBox.Show("Для виконання завдання потрібно щоб всі числа були типу int", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    if(j > i)
                    {
                        dob *= Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        count++;
                    }
                }
            }
            MessageBox.Show("Добуток: " + dob.ToString() + "\nКількість: " + count.ToString());
            //вивід у файл
            if (checkBox1.Checked == true)
            {
                string path = @"..\..\..\";
                string writePath = Path.Combine(Directory.GetCurrentDirectory(), path);
                try
                {
                    using (StreamWriter writer = new StreamWriter(@"..\..\..\RES.txt"))
                    {
                        writer.WriteLine("Добуток: {0}", dob);
                        writer.WriteLine("Кількість: {0}", count);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //ввод з клавіатури
            if(radioButton1.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }
    }
}
