using shellUpscaler.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shellUpscaler
{
    public partial class SetupForm : Form
    {
        public SetupForm ()
        {
            InitializeComponent();
        }

        private void SetupForm_Load (object sender, EventArgs e)
        {

        }

        private void regBtn_Click (object sender, EventArgs e)
        {
            string menuCommand = string.Format("\"{0}\" \"%L\"", Application.ExecutablePath);
            Console.WriteLine("menuCommand = " + menuCommand);
            string filetype = "image";
            ShellUtils.Register(filetype, "Shell Upscaler", "Upscale with ESRGAN", menuCommand);
            MessageBox.Show("Registered to \"" + filetype + "\" file type.", "Message");
        }

        private void unregBtn_Click (object sender, EventArgs e)
        {
            string filetype = "image";
            ShellUtils.Unregister(filetype, "Shell Upscaler");
            MessageBox.Show("Unregistered from \"" + filetype + "\" file type.", "Message");
        }

        private void installEsrganBtn_Click (object sender, EventArgs e)
        {
            string esrganPath = esrganPathTbox.Text.Trim();
            File.WriteAllBytes(Path.Combine(esrganPath, "esrlmain.py"), Resources.esrlmain);
            File.WriteAllBytes(Path.Combine(esrganPath, "esrlmodel.py"), Resources.esrlmodel);
            File.WriteAllBytes(Path.Combine(esrganPath, "esrlrrdbnet.py"), Resources.esrlrrdbnet);
            File.WriteAllBytes(Path.Combine(esrganPath, "esrlupscale.py"), Resources.esrlupscale);
            MessageBox.Show("Installed scripts to run ESRGAN.", "Message");
            File.WriteAllText(Path.Combine(IOUtils.GetAppDataDir(), "esrganpath.ini"), esrganPath);
        }

        private void uninstallEsrganBtn_Click (object sender, EventArgs e)
        {
            string esrganPath = esrganPathTbox.Text.Trim();
            File.Delete(Path.Combine(esrganPath, "esrlmain.py"));
            File.Delete(Path.Combine(esrganPath, "esrlmodel.py"));
            File.Delete(Path.Combine(esrganPath, "esrlrrdbnet.py"));
            File.Delete(Path.Combine(esrganPath, "esrlupscale.py"));
            MessageBox.Show("Removed scripts to run ESRGAN.", "Message");
        }
    }
}
