using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRC_Utility_Software
{
    static class Program
    {
        public static MainProject mainProjectInstance;
        
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainProjectInstance = new MainProject();
            Application.Run(mainProjectInstance);

        }
    }
}
