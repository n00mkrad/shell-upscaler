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
        Process currentProcess;
        public bool singleImage;
        //public bool recursive;

        public UpscaleForm ()
        {
            InitializeComponent();
        }

        private void UpscaleForm_Load (object sender, EventArgs e)
        {
            modeCombox_SelectedIndexChanged(null, null);
            CenterToScreen();
            InitCombox(modeCombox, 0);
            InitCombox(tilesizeCombox, 2);
            LoadModelList();
        }

        void InitCombox (ComboBox box, int index)
        {
            box.SelectedIndex = index;
            box.Text = box.Items[index].ToString();
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
            InitCombox(modelCombox, 0);
        }

        private void runBtn_Click (object sender, EventArgs e)
        {
            IOUtils.ClearTempDir();

            string inpath = "\"" + Path.GetDirectoryName(Program.currentPath) + "\"";
            string outpath = "\"" + IOUtils.GetTempDir() + "\"";

            if(singleImage)
            {
                CopyImageToTempLocation();
                inpath = "\"" + IOUtils.GetTempDir() + "\"";
                outpath = "\"" + Path.GetDirectoryName(Program.currentPath) + "\"";
            }

            string cmd = "/C cd /D \"" + Program.esrganPath + "\" & ";
            cmd += "python esrlmain.py " + inpath + " " + outpath + " --tilesize " + tilesizeCombox.Text.Trim()
                + " --model models/" + modelCombox.Text.Trim() + ".pth";

            Console.WriteLine("CMD: " + cmd);
            Process esrganProcess = new Process();
            esrganProcess.StartInfo.UseShellExecute = false;
            esrganProcess.StartInfo.RedirectStandardOutput = true;
            esrganProcess.StartInfo.RedirectStandardError = true;
            esrganProcess.StartInfo.CreateNoWindow = true;
            esrganProcess.StartInfo.FileName = "cmd.exe";
            esrganProcess.StartInfo.Arguments = cmd;
            esrganProcess.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            esrganProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            esrganProcess.Start();
            runBtn.Enabled = false;
            esrganProcess.BeginOutputReadLine();
            esrganProcess.BeginErrorReadLine();
            esrganProcess.WaitForExit();
            if(!singleImage)
                CopyImagesToOriginalLocation();
            Close();
        }

        void OutputHandler (object sendingProcess, DataReceivedEventArgs output)
        {
            if(output == null || output.Data == null) return;
            string outStr = output.Data;
            Console.WriteLine(outStr);
            runBtn.Text = outStr.Replace("\n", " ").Replace("\r", " ");
            if(outStr.Contains("RuntimeError"))
            {
                if(currentProcess != null && !currentProcess.HasExited)
                    currentProcess.Kill();
                MessageBox.Show("Error occurred: \n\n" + outStr + "\n\nThe ESRGAN process was killed to avoid lock-ups.", "Error");
            }
            if(outStr.Contains("out of memory"))
                MessageBox.Show("ESRGAN ran out of memory. Try reducing the tile size and avoid running programs in the background (especially games) that take up your VRAM.", "Error");
        }

        void CopyImageToTempLocation ()
        {
            IOUtils.ClearTempDir();
            File.Copy(Program.currentPath, Path.Combine(IOUtils.GetTempDir(), Path.GetFileName(Program.currentPath)));
        }

        void CopyImagesToOriginalLocation ()
        {
            IOUtils.Copy(IOUtils.GetTempDir(), Path.GetDirectoryName(Program.currentPath));
            IOUtils.ClearTempDir();
        }

        private void modeCombox_SelectedIndexChanged (object sender, EventArgs e)
        {
            singleImage = modeCombox.SelectedIndex == 0;
        }
    }
}
