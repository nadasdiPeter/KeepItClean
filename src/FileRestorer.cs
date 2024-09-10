using System.Collections.Generic;
using System.IO;

namespace KeepItClean.src
{
   class FileRestorer
   {
      public string FilePath { get; }

      public FileRestorer(string filePath) => FilePath = filePath;

      public bool Start()
      {
         if (File.Exists(FilePath))
         {
            List<string> lines = new List<string>(System.IO.File.ReadAllLines(FilePath));
            foreach(string line in lines)
            {
               string[] paths = line.Split(';');
               if (File.Exists(paths[1]))
               {
                  if (!Directory.Exists(System.IO.Path.GetDirectoryName(paths[0])))
                     Directory.CreateDirectory(System.IO.Path.GetDirectoryName(paths[0]));
                  File.Move(paths[1], paths[0]);
               }
               else
                  return false;
            }
            return true;
         }
         else
            return false;
      }
   }
}
