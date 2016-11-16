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
    public partial class Form1 : Form
    {
        int count;
        public static List<process> processes = new List<process>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if (count < numericUpDown1.Value)
            {
                process p = new process();
                p.addProcess(textBox1.Text);
                textBox1.Text = "";
                p.addArrival(Convert.ToInt32(textBox2.Text));
                textBox2.Text = "";
                p.addBurst(Convert.ToInt32(textBox3.Text));
                textBox3.Text = "";
                
                processes.Add(p);

            }
            else 
            {
                process p = new process();
                p.addProcess(textBox1.Text);
                p.addArrival(Convert.ToInt32(textBox2.Text));
                p.addBurst(Convert.ToInt32(textBox3.Text));
                processes.Add(p);
                Form2 f = new Form2();
                f.Show();
                this.Hide();
                count = 0;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }


       
    }
}

public class process
{
    public string name;
    public int arrival;
    public int burst;
    public int priority;
    public void addProcess(string n)
    { name = n; }
    public string getprocess()
    { return name; }
    public void addArrival(int a)
    { arrival = a; }
    public int getarrival()
    { return arrival; }
    public void addBurst(int b)
    { burst = b; }
    public int getburst()
    { return burst; }
    public void addPriority(int p)
    { priority = p; }
    public int getpriority()
    { return priority; }
};
