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

namespace Survey_App
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static string bucket;

        private void traverseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader ReadFile = new StreamReader(Form3.bucket);
            richTextBox1.Text = ReadFile.ReadToEnd();
            ReadFile.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 user2 = new Form2();
            this.Hide();
            user2.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
    }
}
