using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInformLesson6._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            foreach (var item in this.Controls)
            {
                if(item is Label lb)
                {
                    lb.Font = fontDialog1.Font;
                    lb.ForeColor = fontDialog1.Color;
                }
                else if(item is Button bt)
                {
                    bt.Font = fontDialog1.Font;
                    bt.ForeColor = fontDialog1.Color;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files(*.*)|*.*|Text Files(*.txt)| *.txt || ";
            open.FilterIndex = 1;

            if (open.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader=new StreamReader(open.FileName))
                {
                    richTextBox1.Text = reader.ReadToEnd();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer=new StreamWriter(save.FileName))
                {
                    writer.Write(richTextBox1.Text);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //richTextBox1.Text = folderBrowserDialog1.SelectedPath;
                richTextBox1.Text = folderBrowserDialog1.RootFolder.ToString();
            }
        }
    }
}
