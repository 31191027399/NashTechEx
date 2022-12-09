using System.IO;
using System.Reflection;

namespace DemoQASpecFlow.Library
{
    public class DirectoryHelpers
    {
        public static void CreateDirectoryIfNotExisted(string path)
        {
            if (!(Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);

            }
        }
        public static string GetCurrentDirectoryPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}