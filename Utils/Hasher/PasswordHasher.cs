using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Utils.Hasher
{
    internal class PasswordHasher : IHasher
    {
        private static PasswordHasher _instance = null; 
        public static PasswordHasher Instance { 
            get 
            {
                return _instance ?? (_instance = new PasswordHasher());
            } 
        }
        private PasswordHasher()
        {

        }
        public string hash(string src)
        {
            string ns = BCrypt.Net.BCrypt.HashPassword(src);
            return ns;
        }

        public bool verify(string hashed, string target)
        {
            bool isValid = BCrypt.Net.BCrypt.Verify(target, hashed);
            return isValid;
        }
    }
}
