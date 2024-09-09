using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItClean.src
{
   static class Database
   {
      static List<IFile> files = new List<IFile>();

      public static void Add(IFile file) => files.Add(file);
      public static void Clear(IFile file) => new List<IFile>();

      public static List<IFile> Files() => files;
   }
}
