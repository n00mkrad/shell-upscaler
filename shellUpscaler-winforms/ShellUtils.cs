using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shellUpscaler
{
    static class ShellUtils
    {
        public static void Register (string fileType, string shellKeyName, string menuText, string menuCommand)
        {
            // create path to registry location
            string regPath = "SOFTWARE\\Classes\\SystemFileAssociations\\" + fileType + "\\shell\\" + shellKeyName;

            // add context menu to the registry
            using(RegistryKey key = Registry.LocalMachine.CreateSubKey(regPath))
            {
                key.SetValue(null, menuText);
            }

            // add command that is invoked to the registry
            using(RegistryKey key = Registry.LocalMachine.CreateSubKey(string.Format(@"{0}\command", regPath)))
            {
                key.SetValue(null, menuCommand);
            }
        }

        public static void Unregister (string fileType, string shellKeyName)
        {
            Debug.Assert(!string.IsNullOrEmpty(fileType) && !string.IsNullOrEmpty(shellKeyName));

            // path to the registry location
            string regPath = "SOFTWARE\\Classes\\SystemFileAssociations\\" + fileType + "\\shell\\" + shellKeyName;

            // remove context menu from the registry
            Registry.LocalMachine.DeleteSubKeyTree(regPath);
        }
    }
}
