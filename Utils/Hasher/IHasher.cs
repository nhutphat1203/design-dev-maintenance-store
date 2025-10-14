using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Utils.Hasher
{
    internal interface IHasher
    {
        string hash(string src);
        bool verify(string hashed, string target);
    }
}
