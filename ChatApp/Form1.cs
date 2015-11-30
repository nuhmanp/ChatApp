
using Parse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ParseClient.Initialize("xKZ723Ld11AQvfu7jc6zDQ8cUbaZXBmI7U8Eiisg", "gPdAkumwGTKBB4E2fmKHIpJyWTQJZvgryKmx4YZk");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            textBox1.ForeColor = System.Drawing.Color.Pink;
            textBox1.Text = textBox1.Text + "\r\n" + name + ": " + textBox2.Text;
            textBox2.Text = "";
            var post = new ParseObject("Post");
            post["name"] = "Nuhman";
            post["message"] = "Hello Dear";
            // Save it to Parse
           post.SaveAsync();
        }
    }
}
