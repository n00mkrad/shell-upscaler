using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using System.Reflection;

namespace shellUpscaler
{
    class ImageProcessing
    {
        public enum Format { PngOpti, PngFast, JpegHigh, JpegMed, WeppyHigh, WeppyLow, BMP, TGA, DDS }

        public static Button upscaleBtn;

        public static async void ChangeOutputExtensions (string newExtension)
        {
            string path = IOUtils.GetTempDir(IOUtils.TempFolder.Out);
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
            foreach(FileInfo file in files)     // Remove PNG extensions
            {
                file.MoveTo(file.FullName.Substring(0, file.FullName.Length - 4));
            }
            foreach(FileInfo file in files)
            {
                file.MoveTo(Path.ChangeExtension(file.FullName, newExtension));
            }
        }

        public static async void ConvertImagesToOriginalFormat ()
        {
            string path = IOUtils.GetTempDir(IOUtils.TempFolder.Out);
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
            foreach(FileInfo file in files)     // Remove PNG extensions
            {
                file.MoveTo(file.FullName.Substring(0, file.FullName.Length - 4));
            }

            foreach(FileInfo file in files)
            {
                Format format = Format.PngOpti;

                if(GetTrimmedExtension(file) == "jpg" || GetTrimmedExtension(file) == "jpeg")
                    format = Format.JpegHigh;

                if(GetTrimmedExtension(file) == "webp")
                    format = Format.WeppyHigh;

                if(GetTrimmedExtension(file) == "bmp")
                    format = Format.BMP;

                if(GetTrimmedExtension(file) == "tga")
                    format = Format.TGA;

                if(GetTrimmedExtension(file) == "dds")
                    format = Format.DDS;

                ConvertImage(file.FullName, format, false, false);
            }
        }

        static string GetTrimmedExtension (FileInfo file)
        {
            return file.Extension.ToLower().Replace(".", "");
        }

        public static async void ConvertImages (Format format, bool preprocess = false, bool appendExtension = false, bool delSource = true)
        {
            string path = IOUtils.GetTempDir(IOUtils.TempFolder.Out);
            if(preprocess)
                path = IOUtils.GetTempDir(IOUtils.TempFolder.In);
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
            foreach(FileInfo file in files)
            {
                //if(preprocess && GetTrimmedExtension(file) == "png") return;       // Don't pre-process if the image is already a PNG

                if(preprocess)
                    upscaleBtn.Text = "Preprocessing " + file.Name + "...";
                else
                    upscaleBtn.Text = "Postprocessing " + file.Name + "...";

                Console.WriteLine("Converting " + file.Name + ", appendExtension = " + appendExtension);

                ConvertImage(file.FullName, format, appendExtension, delSource);
            }
        }

        public static void ConvertImage (string path, Format format, bool appendExtension, bool deleteSource = true)
        {
            MagickImage img = new MagickImage(path);
            Console.WriteLine("Converting: " + img.ToString() + " - Target Format: " + format.ToString() + " - DeleteSource: " + deleteSource);
            string ext = "png";

            if(format == Format.PngOpti)
            {
                img.Format = MagickFormat.Png;
                img.Quality = 80;
            }
            if(format == Format.PngFast)
            {
                img.Format = MagickFormat.Png;
                img.Quality = 20;
            }
            if(format == Format.JpegHigh)
            {
                img.Format = MagickFormat.Jpeg;
                img.Quality = 95;
                ext = "jpg";
            }
            if(format == Format.JpegMed)
            {
                img.Format = MagickFormat.Jpeg;
                img.Quality = 80;
                ext = "jpg";
            }
            if(format == Format.WeppyHigh)
            {
                img.Format = MagickFormat.WebP;
                img.Quality = 92;
                ext = "webp";
            }
            if(format == Format.WeppyLow)
            {
                img.Format = MagickFormat.WebP;
                img.Quality = 80;
                ext = "webp";
            }
            if(format == Format.BMP)
            {
                img.Format = MagickFormat.Bmp;
                ext = "bmp";
            }
            if(format == Format.TGA)
            {
                img.Format = MagickFormat.Tga;
                ext = "tga";
            }
            if(format == Format.DDS)
            {
                img.Format = MagickFormat.Dds;
                ext = "dds";
            }

            if(appendExtension)
            {
                string oldExt = Path.GetExtension(path);
                Console.WriteLine("Appending old extension; writing image to " + Path.ChangeExtension(path, null) + oldExt + "." + ext);
                img.Write(Path.ChangeExtension(path, null) + oldExt + "." + ext);
            }
            else
            {
                img.Write(Path.ChangeExtension(path, ext));
                Console.WriteLine("Writing image to " + Path.ChangeExtension(path, ext));
            }

            if(deleteSource)
            {
                if(Path.GetExtension(path).Replace(".", "") == ext.Replace(".", ""))
                    return;     // Return if source and target extensions match
                Console.WriteLine("Deleting source file: " + path);
                File.Delete(path);
            }
        }
    }
}
