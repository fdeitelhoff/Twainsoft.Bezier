using System;
<<<<<<< HEAD
using System.Windows.Forms;
using Twainsoft.Bezier.GUI;
=======
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
>>>>>>> c2967d79fbd7ea07666cb59e798110660dfeb685

namespace Twainsoft.Bezier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new FrmMain());
=======
            Application.Run(new Form1());
>>>>>>> c2967d79fbd7ea07666cb59e798110660dfeb685
        }
    }
}
