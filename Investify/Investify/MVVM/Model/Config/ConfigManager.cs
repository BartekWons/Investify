using System.IO;
using System.Xml.Serialization;

namespace Investify.MVVM.Model.Config
{
    public static class ConfigManager
    {
        private static string _path;

        static ConfigManager()
        {
            _path = GetPath(); 
        }

        public static void SaveXML(Config config)
        {
            var serializer = new XmlSerializer(typeof(Config));
            using var writer = new StreamWriter(_path);
            serializer.Serialize(writer, config);
        }

        public static string GetConnectionString()
        {
            Config config = ReadXML();
            ServerConfig server = config.ServerConfig;
            return $"server={server.ServerName};user={server.UserName};pwd={server.Password};database={server.DatabaseName}";
        }

        public static Config ReadXML()
        {
            var serializer = new XmlSerializer(typeof(Config));
            Config config;
            using (var reader = new StreamReader(_path))
            {
                if (serializer.Deserialize(reader) is Config cfg)
                    config = cfg;
                else
                    config = new Config();
            }
            return config;
        }

        private static string GetPath()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string targetPath = Path.Combine(projectDirectory, "Config", "config.xml");
            return targetPath;
        }
    }
}
