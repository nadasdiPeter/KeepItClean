using System.IO;
using System.Text;

namespace KeepItClean.src
{
   class ChangeLog
   {
      public string FileDir { get; }
      public string FileName { get; } = "ChangeLog.txt";
      public string FilePath { get; }
      public string Text { get; set; } = "";

      public ChangeLog(string directory)
      {
         FileDir = directory;
         FilePath = Path.Combine(FileDir, FileName);
      }

      public void Add(string from, string to) => Text += from + ";" + to + "\n";

      public void Clear() => Text = "";

      public void Save()
      {
         if (!File.Exists(FilePath))
            File.WriteAllText(FilePath, Text, Encoding.UTF8);
         else
            File.AppendAllText(FilePath, Text, Encoding.UTF8);
      }
   }
}
