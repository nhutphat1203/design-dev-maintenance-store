using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace CuahangNongduoc.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppConnection") // trỏ tới connection string trong App.config
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
