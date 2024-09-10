using System.IO;

namespace KeepItClean.src
{
   class FileMover
   {
      public string SourceFolder { get; set; }
      public string TargetFolder { get; set; }

      public FileMover(string source, string target)
      {
         SourceFolder = source;
         TargetFolder = target;
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
         ChangeLog logger = new ChangeLog(TargetFolder);

         foreach (var f in Database.Files())
         {
            if (!Directory.Exists(f.NewPath_Directory()))
               Directory.CreateDirectory(f.NewPath_Directory());
            File.Move(f.Path, f.NewPath);
            logger.Add(f.Path, f.NewPath);
         }

         logger.Save();
      }
   }
}
