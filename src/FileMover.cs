using System.ComponentModel;
using System.IO;

namespace KeepItClean.src
{
   class FileMover
   {
      public string SourceFolder { get; set; }
      public string TargetFolder { get; set; }
      public BackgroundWorker Worker { get; }
      public int Progress { get; set; } = 0;
      public double ProgressStep { get; set; } = 0;

      public FileMover(string source, string target, ref BackgroundWorker worker)
      {
         SourceFolder = source;
         TargetFolder = target;
         Worker = worker;
         ProgressStep = Database.FileCount() / 100.0;
      }

      public void DeleteEmptyFolders(string startLocation)
      {
         foreach (var directory in Directory.GetDirectories(startLocation))
         {
            DeleteEmptyFolders(directory);
            if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
               Directory.Delete(directory, false);
         }
      }

      public void RelocateFiles()
      {
         double progress_counter = 0;
         ChangeLog logger = new ChangeLog(TargetFolder);

         foreach (var f in Database.Files())
         {
            if (!Directory.Exists(f.NewPath_Directory()))
               Directory.CreateDirectory(f.NewPath_Directory());
            File.Move(f.Path, f.NewPath);
            progress_counter = ReportProgress(progress_counter);
            logger.Add(f.Path, f.NewPath);
         }

         logger.Save();
      }

      private double ReportProgress(double counter)
      {
         counter++;
         if (counter >= ProgressStep)
         {
            Progress += (int)(counter / ProgressStep);
            Worker.ReportProgress((Progress > 100) ? 100 : Progress);
            counter = 0;
         }
         return counter;
      }
   }
}
