using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace KeepItClean.src
{
   class FileReader
   {
      public FileReader(string path, bool recursiveSearch, string extensions, ref BackgroundWorker worker)
      {
         Worker = worker;
         Path = path;
         RecursiveSearch = recursiveSearch;
         if (!extensions.Equals(""))
            Extensions = extensions.Replace(" ", "").Split(',');
         else
            Extensions = null;
         Search(Path);
      }

      public string Path { get; set; }
      public bool RecursiveSearch { get; set; }
      public string[] Extensions { get; set; }
      public int progress { get; set; } = 0;

      public BackgroundWorker Worker { get; set; }

      private void Search(string path)
      {
         
         try
         {
            foreach (string f in Directory.GetFiles(path))
               if( Extensions == null || Extensions.Contains(System.IO.Path.GetExtension(f).ToLower()) )
               {
                  Database.Add(new IFile(f));
                  if( progress < 100) Worker.ReportProgress(++progress);
               }
                  

            if( RecursiveSearch )
               foreach (string d in Directory.GetDirectories(path))
                  Search(d);
         }
         catch (System.Exception excpt)
         {
            DebugFileWriter.Add_Exception(excpt.Message);
         }
      }
   }
}
