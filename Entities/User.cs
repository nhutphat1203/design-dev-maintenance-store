using CuahangNongduoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Entities
{
    public class User
    {
        public int ID {  get; set; }

        public string Account { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string PasswordHash {  get; set; }

        public int RoleID { get; set; }

        public string RoleName => Role.Name;

        public string RoleCode => Role.Code;

        public virtual Role Role { get; set; }
    }
}
