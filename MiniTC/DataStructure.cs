using System.IO;

namespace MiniTC
{
    public enum Type
    { 
        File,
        Directory
    }

    public class DataStructure
    {
        public string Path { get; }
        public string Name { get; set; }
        public Type Type { get; }

        public DataStructure(FileSystemInfo systemInfo)
        {
            if (systemInfo is DirectoryInfo)
            {
                Name = "<D>" + systemInfo.Name;
                Type = Type.Directory;
            }
            else
            {
                Name = systemInfo.Name;
                Type = Type.File;
            }
            Path = systemInfo.FullName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
