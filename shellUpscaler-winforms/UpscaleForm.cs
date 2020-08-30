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
            InitCombox(overwriteCombox, 0);
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
            IOUtils.ClearTempDir(IOUtils.TempFolder.Both);

            string inpath = "\"" + IOUtils.GetTempDir(IOUtils.TempFolder.In) + "\"";
            string outpath = "\"" + IOUtils.GetTempDir(IOUtils.TempFolder.Out) + "\"";

            bool overwrite = overwriteCombox.SelectedIndex == 1;

            if(singleImage)
                CopyImageToTemp(overwrite);
            else
                CopyAllImagesToTemp(overwrite);

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
            DisableGUI();
            esrganProcess.BeginOutputReadLine();
            esrganProcess.BeginErrorReadLine();
            esrganProcess.WaitForExit();
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

        void DisableGUI ()
        {
            runBtn.Enabled = false;
            modeCombox.Enabled = false;
            modelCombox.Enabled = false;
            tilesizeCombox.Enabled = false;
            overwriteCombox.Enabled = false;
        }

        void CopyImageToTemp (bool moveInsteadOfCopy = false)
        {
            IOUtils.ClearTempDir(IOUtils.TempFolder.In);
            if(moveInsteadOfCopy)
                File.Move(Program.currentPath, Path.Combine(IOUtils.GetTempDir(IOUtils.TempFolder.In), Path.GetFileName(Program.currentPath)));
            else
                File.Copy(Program.currentPath, Path.Combine(IOUtils.GetTempDir(IOUtils.TempFolder.In), Path.GetFileName(Program.currentPath)));
        }

        void CopyAllImagesToTemp (bool moveInsteadOfCopy = false)
        {
            IOUtils.ClearTempDir(IOUtils.TempFolder.In);
            IOUtils.Copy(Path.GetDirectoryName(Program.currentPath), IOUtils.GetTempDir(IOUtils.TempFolder.In), moveInsteadOfCopy);
        }

        void CopyImagesToOriginalLocation ()
        {
            if(overwriteCombox.SelectedIndex == 1)
            {
                Console.WriteLine("Overwrite mode - removing suffix from filenames");
                IOUtils.ReplaceInFilenamesDir(IOUtils.GetTempDir(IOUtils.TempFolder.Out), "-" + modelCombox.Text.Trim(), "");
            }
            IOUtils.Copy(IOUtils.GetTempDir(IOUtils.TempFolder.Out), Path.GetDirectoryName(Program.currentPath));
            IOUtils.ClearTempDir(IOUtils.TempFolder.Out);
        }

        private void modeCombox_SelectedIndexChanged (object sender, EventArgs e)
        {
            singleImage = modeCombox.SelectedIndex == 0;
        }
    }
}
