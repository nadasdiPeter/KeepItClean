using System.ComponentModel;
using System.IO;
using System.Linq;

namespace KeepItClean.src
{
   class FileReader
   {
      public string Path { get; set; }
      public bool RecursiveSearch { get; set; }
      public string[] Extensions { get; set; }
      public int Progress { get; set; } = 0;
      public double ProgressStep { get; set; } = 0;
      public int FileCount { get; set; } = 0;
      public BackgroundWorker Worker { get; set; }

      public FileReader(string path, bool recursiveSearch, string extensions, ref BackgroundWorker worker)
      {
         Worker = worker;
         Path = path;
         RecursiveSearch = recursiveSearch;

         if (!extensions.Equals(""))
            Extensions = extensions.Replace(" ", "").Split(',');
         else
            Extensions = null;

         CountFiles(Path);
         ProgressStep = FileCount / 100.0;

         Search(Path);
      }

      private void CountFiles(string path)
      {
         FileCount += Directory.GetFiles(path).Count();
         if (RecursiveSearch)
            foreach (string d in Directory.GetDirectories(path))
               CountFiles(d);
      }

      private void Search(string path)
      {
         double cntr = 0;
         try
         {
            foreach (string f in Directory.GetFiles(path))
               if (Extensions == null || Extensions.Contains(System.IO.Path.GetExtension(f).ToLower()))
               {
                  Database.Add(new IFile(f));
                  cntr++;
                  if( cntr >= ProgressStep)
                  {
                     Progress += (int)(cntr / ProgressStep);
                     Worker.ReportProgress((Progress > 100) ? 100 : Progress);
                     cntr = 0;
                     
                  }
               }
            if (RecursiveSearch)
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
