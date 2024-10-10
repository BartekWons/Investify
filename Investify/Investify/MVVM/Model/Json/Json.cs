using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace Investify.MVVM.Model.Json
{
    public static class Json
    {
        private static string _path;

        static Json()
        {
            _path = GetPath();
        }
        public static async Task SerializeToFile<T>(T data)
        {
            try
            {
                if (!File.Exists(_path))
                    return;
                JsonSerializerSettings settings = new()
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto,
                };
                string jsonSerialized = JsonConvert.SerializeObject(data, settings);
                await File.WriteAllTextAsync(_path, jsonSerialized);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static async Task<T> ReadFromFile<T>() where T : new()
        {
            try
            {
                if (!File.Exists(_path))
                    return new ();
                string json = await File.ReadAllTextAsync(_path);
                JsonSerializerSettings settings = new()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                };
                if (JsonConvert.DeserializeObject<T>(json, settings) is T result)
                    return result;
                return new();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new();
            }
        }

        private static string GetPath()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string targetPath = Path.Combine(projectDirectory, "Assets", "Data", "currencies_symbols_and_names.json");
            return targetPath;
        }
    }
}
