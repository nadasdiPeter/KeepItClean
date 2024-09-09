using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KeepItClean.src
{
   class IFile
   {
      public string Path { get; set; }
      public string Directory { get; set; }
      public string FileName { get; set; }
      public string Extension { get; set; }
      public DateTime CreationDate { get; set; }

      public IFile(string path)
      {
         Path = path;
         FileName = System.IO.Path.GetFileName(Path);
         Directory = System.IO.Path.GetDirectoryName(Path);
         Extension = System.IO.Path.GetExtension(Path).ToLower();
         GetDate(Path);
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
   }
}
