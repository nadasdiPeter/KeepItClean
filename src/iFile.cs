using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KeepItClean.src
{
   class IFile
   {
      public string Path { get; }
      public string Directory { get; }
      public string FileName { get; }
      public string Extension { get; }
      public DateTime CreationDate { get; set; }
      public bool DateError { get; set; } = false;
      public string NewPath { get; set; }


      public IFile(string path)
      {
         Path = path;
         FileName = System.IO.Path.GetFileName(Path);
         Directory = System.IO.Path.GetDirectoryName(Path);
         Extension = System.IO.Path.GetExtension(Path).ToLower();
         GetDate(Path);
         NewPath = "";
      }

      private bool IsImage(string ext) => config.IMAGE_FORMATS.Contains(Extension);

      private void GetDate(string path)
      {
         if (IsImage(Extension))
         {
            Regex r = new Regex(":");
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (System.Drawing.Image myImage = System.Drawing.Image.FromStream(fs, false, false))
            {
               if (myImage.PropertyItems.Any(p => p.Id == 0x9003)) /* 0x9003: ExifDTOrig */
               {
                  PropertyItem propItem = myImage.GetPropertyItem(36867);
                  string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                  CreationDate = DateTime.Parse(dateTaken);
               }
               else
               {
                  DateError = true;
                  DebugFileWriter.Add_Info("[Image]: DateNotFound: " + path);
                  CreationDate = File.GetLastWriteTime(path);
               }
            }
         }
         else
         {
            CreationDate = File.GetLastWriteTime(path);
         }
      }


      /* Date */

      public string Year() => CreationDate.Year.ToString();

      public string Month() => config.MONTHS[CreationDate.Month - 1];

      public string Month_MM() => CreationDate.Month.ToString("00");

      public string Day() => CreationDate.Day.ToString("00");

      public string Date() => Year() + "-" + Month_MM() + "-" + Day();


      /* NewPath */

      public string NewPath_FileName() => System.IO.Path.GetFileName(NewPath);

      public string NewPath_Directory() => System.IO.Path.GetDirectoryName(NewPath);
   }
}
