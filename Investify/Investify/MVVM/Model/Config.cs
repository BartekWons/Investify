using System.IO;
using System.Xml;

namespace Investify.MVVM.Model
{
    public class Config
    {
        private string _path;

        public Server Server { get; set; }
        public string ApiKey { get; set; }

        public Config()
        {
            _path = GetPath();
        }

        public static string GetPath()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string targetPath = Path.Combine(projectDirectory, "Config", "config.xml");
            return targetPath;
        }

        public async Task SaveServerDataAsync()
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                Async = true
            };

            using (var fileStream = new FileStream(
                _path,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 4096,
                useAsync: true))
            using (XmlWriter writer = XmlWriter.Create(fileStream, settings))
            {
                await writer.WriteStartDocumentAsync();

                await writer.WriteStartElementAsync(null, "ServerConnection", null);

                await writer.WriteElementStringAsync(null, "ServerName", null, Server.ServerName);
                await writer.WriteElementStringAsync(null, "UserName", null, Server.UserName);
                await writer.WriteElementStringAsync(null, "Password", null, Server.Password);
                await writer.WriteElementStringAsync(null, "DatabaseName", null, Server.DatabaseName);

                await writer.WriteEndElementAsync();
                await writer.WriteEndDocumentAsync();

                await writer.FlushAsync();
            }
        }

        public async Task<string> ReadServerDataAsync()
        {
            Server server = new Server();

            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = true
            };

            using (var fileStream = new FileStream(
                _path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 4096,
                useAsync: true))
            using (XmlReader reader = XmlReader.Create(fileStream, settings))
            {
                while (await reader.ReadAsync())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "ServerName":
                                server.ServerName = await reader.ReadElementContentAsStringAsync();
                                break;
                            case "UserName":
                                server.UserName = await reader.ReadElementContentAsStringAsync();
                                break;
                            case "Password":
                                server.Password = await reader.ReadElementContentAsStringAsync();
                                break;
                            case "DatabaseName":
                                server.DatabaseName = await reader.ReadElementContentAsStringAsync();
                                break;
                        }
                    }
                }
            }
            return $"server={server.ServerName};user={server.UserName};pwd={server.Password};database={server.DatabaseName}";
        }

        public async Task SaveApiKeyAsync()
        {
            XmlDocument doc = new XmlDocument();
            await Task.Run(() => doc.Load(_path));


            if (doc.DocumentElement.Name != null && doc.DocumentElement.Name != "ApiConfiguration")
            {
                XmlElement newDoc = doc.CreateElement("ApiConfiguration");

                XmlNode oldDoc = doc.DocumentElement;
                doc.RemoveChild(oldDoc);
                newDoc.AppendChild(oldDoc);
                doc.AppendChild(newDoc);
            }
            XmlElement apiConfig = doc.CreateElement("ApiConfig");
            XmlElement apiKey = doc.CreateElement("ApiKey");
            apiConfig.AppendChild(apiKey);

            doc.DocumentElement.AppendChild(apiConfig);
            await Task.Run(() => doc.Save(_path));
        }

        public async Task<string> ReadApiKeyAsync()
        {
            XmlDocument doc = new XmlDocument();
            await Task.Run(() => doc.Load(_path));

            XmlNode apiKeyNode = doc.SelectSingleNode("//ApiConfiguration/ApiConfig/ApiKey");

            return (apiKeyNode != null) ? apiKeyNode.InnerText : null;
        }
    }
}
