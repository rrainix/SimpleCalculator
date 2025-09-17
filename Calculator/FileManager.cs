using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public static class FileManager
    {
        public static string AppDataPath { get; private set; }
        public static void Initialize()
        {
            AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public static void SaveString(string path, string text)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, text);
        }
        public static string LoadString(string path) => File.Exists(path) ? File.ReadAllText(path) : "";
    }
}
