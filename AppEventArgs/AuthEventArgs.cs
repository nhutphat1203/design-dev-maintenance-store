using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.AppEventArgs
{
    public class AuthEventArgs : EventArgs
    {
        public Entities.User User { get; private set; }

        public AuthEventArgs(Entities.User user)
        {
            User = user;
        }
    }
}
