
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
            ParseClient.Initialize("xKZ723Ld11AQvfu7jc6zDQ8cUbaZXBmI7U8Eiisg", "gPdAkumwGTKBB4E2fmKHIpJyWTQJZvgryKmx4YZk");
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
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Post");
            IEnumerable<ParseObject> horses = await query.FindAsync();
            textBox1.ForeColor = System.Drawing.Color.Pink;
            textBox1.ReadOnly = true;
            foreach (ParseObject horse in horses)
            {
                string name = horse.Get<string>("name");
                string message = horse.Get<string>("message");
                //count++;
                //Debug.WriteLine("Horse: " + name);
                textBox1.Text = textBox1.Text + "\r\n" + name + ": " + message;
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
