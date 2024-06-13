using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service
{
    internal class Hashing
    {
        public static string Hash(string input)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(input, salt);
        }

        public static bool Verify(string input, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }
    }
}
