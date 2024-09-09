using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KeepItClean.src
{
   static class Database
   {
      static List<IFile> files = new List<IFile>();

      public static void Add(IFile file) => files.Add(file);

      public static void Clear() => new List<IFile>();
      
      public static List<IFile> Files() => files;

      public static int FileCount() => files.Count();

      
      
      /* Action */

      public static void AssigneNewPaths(string target, bool separateImageErrors)
      {
         var years = files.Select(x => x.Year()).Distinct().ToList();
         foreach (string year in years)
         {
            var months = files.Select(x => x.Month_MM()).Distinct().ToList();
            foreach (var month in months)
            {
               var l = files.Where(x => (year == x.Year() && month == x.Month_MM())).ToList();
               int counter = 0;
               foreach (var f in l)
               {
                  string newFileName = f.Year() + "-" + f.Month_MM() + "-" + f.Day() + "__" + (++counter) + f.Extension;

                  if( separateImageErrors )
                     f.NewPath = (f.DateError) ? Path.Combine(target, "DateError", newFileName) : Path.Combine(target, f.Year(), f.Month(), newFileName);
                  else
                     f.NewPath = Path.Combine(target, f.Year(), f.Month(), newFileName);
               }
            }
         }
      }
   }
}
