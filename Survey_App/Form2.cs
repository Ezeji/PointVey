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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OpenFileDialog fb = new OpenFileDialog();
            fb.Title = "Insert A Text File";
            fb.Filter = "Text Files|*.txt";
            fb.ShowDialog();

            if (fb.ShowDialog() == DialogResult.Cancel)

            {

                this.Hide();
                 
            }

            else
            {
                
                Form3.bucket = fb.FileName;
            }
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {

            Form3 user3 = new Form3();
            this.Hide();
            user3.Show();
        }


        double Bearing = 0;
        double Bearing_Radians;
        double distance = 0;
        double DeltaEastings;
        double DeltaNorthings;
        double Eastings;
        double Northings;
        double Ref_BBrg_Value = 0;
        double D_Angle = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            distance = double.Parse(richTextBox9.Text);

            Traverse Stns = new Traverse();

            try

            { 

            Ref_BBrg_Value = Stns.Final_WCB_Bck_Brg(double.Parse(richTextBox2.Text), double.Parse(richTextBox3.Text), double.Parse(richTextBox4.Text), double.Parse(richTextBox5.Text));

            }

            catch (Exception ex) 
            
            {
                MessageBox.Show(ex.Message);
            }

            try

            { 

            D_Angle = Stns.Convert_Angles(int.Parse(richTextBox6.Text), int.Parse(richTextBox7.Text), double.Parse(richTextBox8.Text));
            
            }

            catch (Exception excep)

            {
                MessageBox.Show(excep.Message);
            }

            Bearing = Ref_BBrg_Value + D_Angle;

            if (Bearing > 360)
            {
                Bearing = Bearing - 360;

            }

            Bearing_Radians = Bearing * (Math.PI / 180);
            DeltaNorthings = distance * Math.Cos(Bearing_Radians);
            DeltaEastings = distance * Math.Sin(Bearing_Radians);
            Northings = Convert.ToDouble(richTextBox4.Text) + DeltaNorthings;
            Eastings = Convert.ToDouble(richTextBox5.Text) + DeltaEastings;


            StreamWriter file = new StreamWriter(Form3.bucket, true);
            file.WriteLine("TRAVERSE INFORMATION TEXT FILE");
            file.WriteLine("");
            file.WriteLine("Bearing:" + Bearing);
            file.WriteLine("DN:" + DeltaNorthings);
            file.WriteLine("DE:" + DeltaEastings);
            file.WriteLine("Northings:" + Northings);
            file.WriteLine("Eastings:" + Eastings);
            file.WriteLine("");
            file.Close();

            Ref_BBrg_Value = 0;
            D_Angle = 0;
        }

        double CollectorN1 = 0;
        double CollectorE1 = 0;
        double CollectorN2 = 0;
        double CollectorE2 = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox6.Clear();
            richTextBox7.Clear();
            richTextBox8.Clear();
            richTextBox9.Clear();

            CollectorN1 = Convert.ToDouble(richTextBox4.Text);
            CollectorE1 = Convert.ToDouble(richTextBox5.Text);
            CollectorN2 = Northings;
            CollectorE2 = Eastings;

            richTextBox2.Text = CollectorN1.ToString();
            richTextBox3.Text = CollectorE1.ToString();
            richTextBox4.Text = CollectorN2.ToString();
            richTextBox5.Text = CollectorE2.ToString();

            CollectorN1 = 0;
            CollectorE1 = 0;
            CollectorN2 = 0;
            CollectorE2 = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Do you really want to leave the form?", "Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            
            {
                e.Cancel = false;
            }

            else

            {
                e.Cancel = true;
            }
        }

     
    }
}
