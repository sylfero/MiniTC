using System.IO;

namespace MiniTC.DataOperations
{
    static class DataCopy
    {
        public static void CopyFile(string from, string to)
        {
            FileInfo From = new FileInfo(from);
            DirectoryInfo To = new DirectoryInfo(to);

            string path = To.FullName + "\\" + From.Name;
            int i = 2;

            while (File.Exists(path))
            {
                path = To.FullName + "\\" + From.Name.Replace(From.Extension, $"({i}){From.Extension}");
                i++;
            }

            File.Copy(From.FullName, path);
        }

        public static void CopyDirectory(string from, string to)
        {
            DirectoryInfo From = new DirectoryInfo(from);

            DirectoryInfo[] directories = From.GetDirectories();
            FileInfo[] files = From.GetFiles();

            string path = to + "\\" + From.Name;
            int i = 2;

            while (Directory.Exists(path))
            {
                path = $"{to}\\{From.Name} ({i})";
                i++;
            }

            Directory.CreateDirectory(path);

            foreach (FileInfo file in files)
            {
                File.Copy(file.FullName, path + "\\" + file.Name);
            }

            foreach (DirectoryInfo directory in directories)
            {
                CopyDirectory(directory.FullName, path);
            }
        }
    }
}
