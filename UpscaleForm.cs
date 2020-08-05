using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shellUpscaler
{
    public partial class UpscaleForm : Form
    {
        public UpscaleForm ()
        {
            InitializeComponent();
        }

        private void UpscaleForm_Load (object sender, EventArgs e)
        {
            LoadModelList();
        }

        void LoadModelList ()
        {
            modelCombox.Items.Clear();
            string[] models = Directory.GetFiles(Path.Combine(Program.esrganPath, "models"));
            foreach(string modelPath in models)
            {
                string filename = Path.GetFileName(modelPath);
                if(filename.EndsWith(".pth"))
                    modelCombox.Items.Add(Path.GetFileNameWithoutExtension(modelPath));
            }
            modelCombox.SelectedIndex = 0;
        }

        private void runBtn_Click (object sender, EventArgs e)
        {
            //string 

            string cmd = "/k cd /D \"" + Program.esrganPath + "\" & ";
            cmd += "python esrlmain.py ";

            ProcessStartInfo psi;
            bool redirectStdOut = false;
            bool hideCmd = false;
            psi = new ProcessStartInfo { FileName = "cmd.exe", Arguments = cmd, UseShellExecute = !redirectStdOut, RedirectStandardOutput = redirectStdOut, CreateNoWindow = redirectStdOut };
            if(hideCmd) psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process proc = new Process { StartInfo = psi };
            proc.Start();
        }
    }
}
