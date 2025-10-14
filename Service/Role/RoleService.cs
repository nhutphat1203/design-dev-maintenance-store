using CuahangNongduoc.Entities;
using CuahangNongduoc.Service.User;
using CuahangNongduoc.Utils.Hasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Service.Role
{
    public class RoleService : IRoleService
    {
        private static RoleService _instance = null;
        private static AppDbContext _context = new AppDbContext();

        public static RoleService Instance
        {
            get
            {
                return _instance ?? (_instance = new RoleService());
            }
        }
        public IEnumerable<Entities.Role> getAll()
        {
            return _context.Roles.Where(r => r.Code != "ADMIN").ToList();
        }
    }
}
