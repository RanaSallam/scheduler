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
    public partial class Form3 : Form
    {
        int count = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if (count < Scheduler.Form1.processes.Count())
            {
                Scheduler.Form1.processes[count - 1].addPriority(Convert.ToInt32(textBox1.Text));
                textBox1.Text = "";
            }
                
            else
            {
                Scheduler.Form1.processes[count -1].addPriority(Convert.ToInt32(textBox1.Text));
                //non preeptive [check example in notes]

                //assume all arrival time are different 
                //1st come process               
            restart:
                var list1 = Scheduler.Form1.processes.OrderBy(item => item.getarrival()).ToList();
                int P1 = list1[0].getarrival();
                int P2 = P1 + list1[0].getburst();
                MessageBox.Show(list1[0].getprocess() + "  From: " + P1 + 
                    "  To: " + P2 + " Priority: " +list1[0].getpriority());
                P1 = P2;
                list1.Remove(list1[0]);
                Scheduler.Form1.processes = list1;

                while (list1.Count()>0)
                {
                    if (list1[0].getarrival() == P2)
                    {
                        P2 = P1 + list1[0].getburst();
                        MessageBox.Show(list1[0].getprocess() + "  From: " + P1 +
                          "  To: " + P2 + " Priority: " + list1[0].getpriority());
                        P1 = P2;
                        list1.Remove(list1[0]);
                        Scheduler.Form1.processes = list1;
                    }

                    else if (list1[0].getarrival() < P2)// gom abl ma a5er process tseb l cpu
                    {
                        var list = list1.OrderBy(item => item.getpriority()).ToList();
                        if (list[0].getarrival() <= P2)
                        {
                            P2 = P1 + list[0].getburst();
                            MessageBox.Show(list[0].getprocess() + "  From: " + P1 +
                              "  To: " + P2 + " Priority: " + list[0].getpriority());
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

            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        

        
    }
}
