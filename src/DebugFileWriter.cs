using System;
using System.IO;
using System.Text;

namespace KeepItClean.src
{
   public static class DebugFileWriter
   {
      public static string FileName { get; set; } = "Log.txt";
      public static string FileDir { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
      public static string FilePath { get; set; } = Path.Combine(FileDir, FileName);
      public static string Text { get; set; } = "";

      public static void Add_Info(string m) => Text += "[INFO] " + m + "\n";
      public static void Add_Exception(string m) => Text += "[EXCEPTION] " + m + "\n";
      public static void Add_Error(string m) => Text += "[ERROR] " + m + "\n";
      public static void Add_Time() => Text += "\n[START] " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n";
      public static void Clear() => Text = "[CLEAR] " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

      public static void Save()
      {
         if (!File.Exists(FilePath))
            File.WriteAllText(FilePath, Text, Encoding.UTF8);
         else
            File.AppendAllText(FilePath, Text, Encoding.UTF8);
      }
   }
}
