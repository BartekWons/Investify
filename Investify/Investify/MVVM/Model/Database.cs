﻿using Dapper;
using Investify.MVVM.Model.Config;
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

        public static string GetPath()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string targetPath = Path.Combine(projectDirectory, "Config", "serverConfig.txt");
            return targetPath;
        }

        public static async Task<string> ReadServerData()
        {
            var text = await File.ReadAllTextAsync(_path);
            return text.ToString();
        }

        public static async Task AddUser(User user)
        {
            var connectionString = ConfigManager.GetConnectionString();
            using var connection = new MySqlConnection(connectionString);
            var sql = "INSERT INTO Users(firstname, lastname, login, email, password, salt, birthdate) " +
                "VALUES (@Firstname, @Lastname, @Login, @Email, @Password, @Salt, @BirthDate);";
            var rowsAffected = await connection.ExecuteAsync(sql, user);
        }

        public static async Task<IEnumerable<User>> GetUsers()
        {
            var connectionString = ConfigManager.GetConnectionString();
            using var connection = new MySqlConnection(connectionString);
            return await connection.QueryAsync<User>("SELECT * FROM users");
        }
    }
}
