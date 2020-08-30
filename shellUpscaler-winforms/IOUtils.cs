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
        public enum TempFolder { In, Out, Both }

        public static string GetAppDataDir ()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dir = Path.Combine(appDataDir, "ShellUpscaler");
            Directory.CreateDirectory(dir);
            return dir;
        }

        public static string GetTempDir (TempFolder folder)
        {
            string dir = Path.Combine(GetAppDataDir(), "temp");
            if(folder == TempFolder.In)
                dir = Path.Combine(GetAppDataDir(), "temp-in");
            if(folder == TempFolder.Out)
                dir = Path.Combine(GetAppDataDir(), "temp-out");
            Directory.CreateDirectory(dir);
            return dir;
        }

        public static void ClearTempDir (TempFolder folder)
        {
            if(folder == TempFolder.Both)
            {
                Directory.Delete(GetTempDir(TempFolder.In), true);
                Directory.Delete(GetTempDir(TempFolder.Out), true);
                Directory.CreateDirectory(GetTempDir(TempFolder.In));
                Directory.CreateDirectory(GetTempDir(TempFolder.Out));
                return;
            }
            Directory.Delete(GetTempDir(folder), true);
            Directory.CreateDirectory(GetTempDir(folder));
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

        public static void Copy (string sourceDirectoryName, string targetDirectoryName, bool move = false)
        {
            Directory.CreateDirectory(targetDirectoryName);

            DirectoryInfo source = new DirectoryInfo(sourceDirectoryName);
            DirectoryInfo target = new DirectoryInfo(targetDirectoryName);

            CopyWork(source, target, move);
        }

        private static void CopyWork (DirectoryInfo source, DirectoryInfo target, bool move)
        {
            foreach(DirectoryInfo dir in source.GetDirectories())
                CopyWork(dir, target.CreateSubdirectory(dir.Name), move);

            foreach(FileInfo file in source.GetFiles())
            {
                if(move)
                    file.MoveTo(Path.Combine(target.FullName, file.Name));
                else
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }
                
        }

        public static void ReplaceInFilenamesDir (string dir, string textToFind, string textToReplace, bool recursive = true, string wildcard = "*")
        {
            int counter = 1;
            DirectoryInfo d = new DirectoryInfo(dir);
            FileInfo[] files = null;
            if(recursive)
                files = d.GetFiles(wildcard, SearchOption.AllDirectories);
            else
                files = d.GetFiles(wildcard, SearchOption.TopDirectoryOnly);
            foreach(FileInfo file in files)
            {
                ReplaceInFilename(file.FullName, textToFind, textToReplace);
                counter++;
            }
        }

        public static void ReplaceInFilename (string path, string textToFind, string textToReplace)
        {
            string ext = Path.GetExtension(path);
            string newFilename = Path.GetFileNameWithoutExtension(path).Replace(textToFind, textToReplace);
            string targetPath = Path.Combine(Path.GetDirectoryName(path), newFilename + ext);
            if(File.Exists(targetPath))
            {
                //Program.Print("Skipped " + path + " because a file with the target name already exists.");
                return;
            }
            File.Move(path, targetPath);
        }
    }
}
