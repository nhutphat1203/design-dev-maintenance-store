using CuahangNongduoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.DTO
{
    internal class AuthInfo
    {
        public User User { get; set; }
        public AuthStatus AuthStatus { get; set; }
    }

    internal enum AuthStatus
    {
        Success,
        WrongPassword,
        NoExistent,
    }
}
