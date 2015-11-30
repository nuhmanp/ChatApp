
using Parse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        //int count = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Hide();
            textBox2.Hide();
            button1.Hide();
            ParseClient.Initialize("HvXyE56N4LRgo2b18YDdwmtrunSzoFGKhnn4Mu95", "HBYqK80yKhFnx6BNSxo668uijMIppMRXV3DgmwdJ");
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();


            t.Interval = 4000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            
            //textBox1.Text = textBox1.Text + "\r\n" + name + ": " + textBox2.Text;
            //textBox2.Text = "";
            var post = new ParseObject("ChatData");
            post["userName"] = textBox3.Text;
            post["chat"] = textBox2.Text;
            textBox2.Text = "";
            // Save it to Parse
           post.SaveAsync();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uname = textBox3.Text;
            if (uname != "")
            {
                label1.Hide();
                textBox3.Hide();
                button2.Hide();
                textBox1.Show();
                textBox2.Show();
                button1.Show();
            }
        }
        public async void updateText()
        {
            //textBox1.Text = textBox1.Text + "xcvbxcb";
            ParseQuery<ParseObject> query = ParseObject.GetQuery("ChatData");
            IEnumerable<ParseObject> horses = await query.FindAsync();
            textBox1.ForeColor = System.Drawing.Color.Pink;
            textBox1.ReadOnly = true;
            foreach (ParseObject horse in horses)
            {
                try
                {
                    string name = horse.Get<string>("userName");
                    string message = horse.Get<string>("chat");
                    textBox1.Text = textBox1.Text + "\r\n" + name + ": " + message;
                }
                catch (Exception e)
                {

                }

                //count++;
                //Debug.WriteLine("Horse: " + name);
               
            }
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
            //textBox1.Text = ""+count;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            updateText();
        }
    }
}
