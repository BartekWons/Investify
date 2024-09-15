using Dapper;
using MySql.Data.MySqlClient;
using System.IO;

namespace Investify.MVVM.Model
{
    public static class Database
    {
        private static string _path;

        static Database()
        {
            _path = GetPath();
        }

        private static string GetPath()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string targetPath = Path.Combine(projectDirectory, "Config", "serverConfig.txt");
            return targetPath;
        }

        public static async Task ChangeServerData(string server, string user, string password, string database)
        {
            string connectionString = $"server={server};user={user};pwd={password};database={database}";
            await File.WriteAllTextAsync(_path, connectionString);
        }

        private static async Task<string> ReadServerData()
        {
            var text = await File.ReadAllTextAsync(_path);
            return text.ToString();
        }

        public static async Task AddUser(User user)
        {
            var connectionString = await ReadServerData();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "INSERT INTO Users(firstname, lastname, login, email, password, salt, birthdate) " +
                    "VALUES (@Firstname, @Lastname, @Login, @Email, @Password, @Salt, @BirthDate);";
                var rowsAffected = await connection.ExecuteAsync(sql, user);
            }
        }

        public static async Task<IEnumerable<User>> GetUsers()
        {
            var connectionString = await ReadServerData();
            using (var connection = new MySqlConnection(connectionString))
            {
                return await connection.QueryAsync<User>("SELECT * FROM users");
            }
        }
    }
}
