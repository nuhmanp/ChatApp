
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ChatApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// ParseObject gameScore = new ParseObject("GameScore");
        /// 
        
        //ParseObject gameScore = new ParseObject("GameScore");
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //ParseClient.Initialize("YOUR APPLICATION ID", "YOUR .NET KEY");
        }
    }
}
