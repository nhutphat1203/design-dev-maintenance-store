using CuahangNongduoc.DTO;
using CuahangNongduoc.Entities;
using CuahangNongduoc.Utils.Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Service.Auth
{
    internal class AuthService : IAuthService
    {
        private static AuthService _instance = null;
        private static IHasher _hasher = PasswordHasher.Instance;
        private static AppDbContext _context = new AppDbContext();
        public static AuthService Instance
        {
            get
            {
                return _instance ?? (_instance = new AuthService());
            }
        }

        private AuthService() { }

        public AuthInfo Login(string username, string password)
        {
            var user = _context.Users.First(r => r.Account == username);
            var authInfo = new AuthInfo();
            if (user == null)
            {
                authInfo.AuthStatus = AuthStatus.NoExistent;
            }
            else if (!_hasher.verify(user.PasswordHash, password))
            {
                authInfo.AuthStatus = AuthStatus.WrongPassword;
            }
            else
            {
                authInfo.User = user;
                authInfo.AuthStatus = AuthStatus.Success;
            }
            return authInfo;
        }
    }
}
