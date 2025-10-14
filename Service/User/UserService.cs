using CuahangNongduoc.Entities;
using CuahangNongduoc.Service.Auth;
using CuahangNongduoc.Utils.Hasher;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Service.User
{
    public class UserService : IUserService
    {
        private static UserService _instance = null;
        private static IHasher _hasher = PasswordHasher.Instance;
        private static AppDbContext _context = new AppDbContext();

        public static UserService Instance
        {
            get
            {
                return _instance ?? (_instance = new UserService());
            }
        }

        public void add(Entities.User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            _context.Users.Remove(getById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Entities.User> getAll()
        {
            return _context
                .Users
                .Include(r => r.Role)
                .Where(r => r.Role.Code != "ADMIN")
                .ToList();
        }

        public Entities.User getById(int id)
        {
            return _context
                .Users
                .Include(r => r.Role)
                .Where(r => r.ID == id)
                .First();
        }

        public void update(Entities.User user)
        {
            _context.Users.AddOrUpdate(user);
            _context.SaveChanges();
        }
    }
}
