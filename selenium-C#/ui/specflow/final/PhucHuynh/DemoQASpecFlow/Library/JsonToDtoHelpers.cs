using Newtonsoft.Json;
using System;
using System.IO;

namespace DemoQASpecFlow.Library
{
    public class JsonToDtoHelpers
    {
        public static string ReadJsonFile(string path)
        {
            if (!(Directory.Exists(path)))
            {
                path = Path.Combine(DirectoryHelpers.GetCurrentDirectoryPath(), path);
                if (!File.Exists(path))
                {
                    throw new Exception("Can't find file" + path);
                }
            }
            return File.ReadAllText(path);

        }
        public static T ReadAndParse<T>(string path) where T : class
        {
            var jsonContent = ReadJsonFile(path);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
    }