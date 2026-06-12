using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace InventoryManagement.Application.Utils
{
    public static class PasswordHasher
    {
        //password  hash meethod 
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //database  hash and login matching 
        public static bool VerifyPassword(string password, string storedHash)
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput == storedHash;
        }
    }
}

