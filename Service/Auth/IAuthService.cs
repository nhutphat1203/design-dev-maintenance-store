using CuahangNongduoc.DTO;
using CuahangNongduoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Service.Auth
{
    internal interface IAuthService
    {
        AuthInfo Login(string username, string password);
    }
}
