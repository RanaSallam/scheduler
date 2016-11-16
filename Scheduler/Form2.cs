using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Scheduler
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FCFS
            if (radioButton1.Checked)
            {
                var list = Scheduler.Form1.processes.OrderBy(item => item.getarrival()).ToList();
            restart:
                int P1 = list[0].getarrival();
                int P2 = P1 + list[0].getburst();
                MessageBox.Show(list[0].getprocess() + "  From: " + P1 + "  To: " + P2);
                P1 = P2;
                list.Remove(list[0]);

                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i].getarrival() <= P2)
                    {
                        P2 = P1 + list[i].getburst();
                        MessageBox.Show(list[i].getprocess() + "  From: " + P1 + "  To: " + P2);
                        P1 = P2;
                        list.Remove(list[0]);
                    }
                    else
                        goto restart;
                }
                
            }

            //SJF
            if (radioButton2.Checked)
            {
                if (nonpreemptiveButton.Checked)
                {
                restart:
                    var list1 = Scheduler.Form1.processes.OrderBy(item => item.getarrival()).ToList();
                    int P1 = list1[0].getarrival();
                    int P2 = P1 + list1[0].getburst();
                    MessageBox.Show(list1[0].getprocess() + "  From: " + P1 +
                        "  To: " + P2 );
                    P1 = P2;
                    list1.Remove(list1[0]);
                    Scheduler.Form1.processes = list1;

                    while (list1.Count() > 0)
                    {
                        if (list1[0].getarrival() == P2)
                        {
                            P2 = P1 + list1[0].getburst();
                            MessageBox.Show(list1[0].getprocess() + "  From: " + P1 +
                              "  To: " + P2 );
                            P1 = P2;
                            list1.Remove(list1[0]);
                            Scheduler.Form1.processes = list1;
                        }

                        else if (list1[0].getarrival() < P2)// gom abl ma a5er process tseb l cpu
                        {
                            var list = list1.OrderBy(item => item.getburst()).ToList();
                            if (list[0].getarrival() <= P2)
                            {
                                P2 = P1 + list[0].getburst();
                                MessageBox.Show(list[0].getprocess() + "  From: " + P1 +
                                  "  To: " + P2);
                                P1 = P2;
                                list.Remove(list[0]);
                                list1 = list;
                                Scheduler.Form1.processes = list1;

                            }
                            else
                                goto restart;

                        }
                        else
                            goto restart;

                    }
                }
                else if (preemptiveButton.Checked)
                {
                    MessageBox.Show("Not Supported");
                }
            }




            //Priority
            if (radioButton3.Checked)
            {
                if (nonpreemptiveButton.Checked)
                {
                    Form3 f = new Form3();
                    f.Show();
                    this.Hide();
                }
                else if (preemptiveButton.Checked)
                {
                    MessageBox.Show("Not Supported");
                }
                
            }

            //RR
            if (radioButton4.Checked)
            { }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void nonpreemptiveButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void preemptiveButton_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
