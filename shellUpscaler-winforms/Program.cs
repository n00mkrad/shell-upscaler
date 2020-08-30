using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shellUpscaler
{
    static class Program
    {
        public static string currentPath;
        public static string esrganPath;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
      {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GetEsrganPath();
            CheckArgs();
        }

        static void GetEsrganPath ()
        {
            string path = Path.Combine(IOUtils.GetAppDataDir(), "esrganpath.ini");
            if(File.Exists(path))
                esrganPath = File.ReadAllText(path);
        }

        static void CheckArgs ()
        {
            string[] args = Environment.GetCommandLineArgs();

            foreach(string arg in args)
            {
                Console.WriteLine("Arg: " + arg);
            }

            if(args.Length <= 1)
            {
                Application.Run(new SetupForm());
            }
            else
            {
                currentPath = args[1];
                Application.Run(new UpscaleForm());
            }
            Application.Exit();
        }
    }
}
