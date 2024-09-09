using System.IO;

namespace KeepItClean.src
{
   static class FileMover
   {
      public static void DeleteEmptyFolders(string startLocation)
      {
         foreach (var directory in Directory.GetDirectories(startLocation))
         {
            DeleteEmptyFolders(directory);
            if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
               Directory.Delete(directory, false);
         }
      }

      public static void RelocateFiles()
      {
         foreach (var f in Database.Files())
         {
            if (!Directory.Exists(f.NewPath_Directory()))
               Directory.CreateDirectory(f.NewPath_Directory());
            File.Move(f.Path, f.NewPath);
         }
      }
   }
}
