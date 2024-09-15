using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;

namespace Investify.MVVM.Model
{
    public class User
    {
        public int User_id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime BirthDate { get; set; }

        public static string GetSalt(int size)
        {
            var buffer = new byte[size];
            RandomNumberGenerator.Create().GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        public static string SHA512Hashing(string password, string salt)
        {
            SHA512 sha = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sha.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public override string ToString()
        {
            return $"UserId: {User_id}\n" +
                   $"Firstname: {Firstname}\n" +
                   $"Lastname: {Lastname}\n" +
                   $"Login: {Login}\n" +
                   $"Email: {Email}\n" +
                   $"Password: {Password}\n" +
                   $"Salt: {Salt}\n" +
                   $"BirthDate: {BirthDate.ToString("yyyy-MM-dd")}\n";
        }
    }
}
