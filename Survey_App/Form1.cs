using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Survey_App
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void SplashScreen()
        {
            try

            { 
           
                Application.Run(new Form4());

            }

            catch (Exception exception)

            {
                MessageBox.Show(exception.Message);
            }
        }

        

        private void traverseComputationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 user2 = new Form2();
            user2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
