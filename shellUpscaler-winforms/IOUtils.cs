using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shellUpscaler
{
    class IOUtils
    {
        public static string GetAppDataDir ()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dir = Path.Combine(appDataDir, "ShellUpscaler");
            Directory.CreateDirectory(dir);
            return dir;
        }

        public static string GetTempDir ()
        {
            string dir = Path.Combine(GetAppDataDir(), "temp");
            Directory.CreateDirectory(dir);
            return dir;
        }

        public static void ClearTempDir ()
        {
            Directory.Delete(GetTempDir(), true);
        }

        public static bool IsPathDirectory (string path)
        {
            if(path == null) throw new ArgumentNullException("path");
            path = path.Trim();

            if(Directory.Exists(path))
                return true;

            if(File.Exists(path))
                return false;

            // if has trailing slash then it's a directory
            if(new[] { "\\", "/" }.Any(x => path.EndsWith(x)))
                return true; // ends with slash

            // if has extension then its a file; directory otherwise
            return string.IsNullOrWhiteSpace(Path.GetExtension(path));
        }

        public static bool IsFileValid (string path)
        {
            if(path == null)
                return false;
            if(!File.Exists(path))
                return false;

            return true;
        }

        public static void Copy (string sourceDirectoryName, string targetDirectoryName)
        {
            Directory.CreateDirectory(targetDirectoryName);

            DirectoryInfo source = new DirectoryInfo(sourceDirectoryName);
            DirectoryInfo target = new DirectoryInfo(targetDirectoryName);

            CopyWork(source, target);
        }

        private static void CopyWork (DirectoryInfo source, DirectoryInfo target)
        {
            foreach(DirectoryInfo dir in source.GetDirectories())
                CopyWork(dir, target.CreateSubdirectory(dir.Name));

            foreach(FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }
    }
}
