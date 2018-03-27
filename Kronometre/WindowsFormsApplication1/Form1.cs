using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            int saniye = Convert.ToInt16(label3.Text);
            int dakika = Convert.ToInt16(label2.Text);
            int saat = Convert.ToInt16(label1.Text);
            saniye++;
            label3.Text = Convert.ToString(saniye);

            if (saniye == 59) {
                label3.Text = "0";
                dakika++;
                label2.Text = Convert.ToString(dakika);
                if (dakika == 59)
                {
                    label3.Text = "0";
                    label2.Text = "0";
                    saat++;
                    label1.Text = Convert.ToString(saat);
                }
                                      } 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            listBox1.Items.Add(label1.Text+":"+label2.Text+":"+label3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int onceki = 0;
            int i;
            for (i = 0; i < listBox1.Items.Count; i++)
            {
                string x = listBox1.Items[i].ToString();
                MessageBox.Show((i + 1) + ". SATIR = " + x);
                int pozisyon1 = x.IndexOf(":");
                int pozisyon2 = x.LastIndexOf(":");
                String saat = x.Substring(0, pozisyon1);
                String dakika = x.Substring(pozisyon1 + 1, pozisyon2- (pozisyon1+1));
                String saniye = x.Substring(pozisyon2 + 1);
                int sure = 360 * Convert.ToInt16(saat) + 60 * Convert.ToInt16(dakika) + Convert.ToInt16(saniye);
                int fark = sure - onceki;
                listBox2.Items.Add(fark);
                onceki = sure;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            foreach (var item in listBox2.Items)
            {
                list.Add(item);
            }
            list.Sort();
            listBox2.Items.Clear();
            foreach (var item in list)
            {
                listBox2.Items.Add(item);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        

        
    }
}