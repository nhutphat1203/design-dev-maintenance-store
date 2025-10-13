namespace CuahangNongduoc.Migrations
{
    using CuahangNongduoc.Utils.Hasher;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<CuahangNongduoc.Entities.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CuahangNongduoc.Entities.AppDbContext context)
        {

            if (!context.Roles.Any()) {
                context.Roles.Add(new Entities.Role
                {
                    Name = "Chủ cửa hàng",
                    Code = "ADMIN"
                });
                context.Roles.Add(new Entities.Role
                {
                    Name = "Nhân viên nhập kho",
                    Code = "NVNK"
                });
                context.Roles.Add(new Entities.Role
                {
                    Name = "Nhân viên bán hàng",
                    Code = "NVBH"
                });
                context.SaveChanges();
            }

            if (!context.Users.Any(u => u.Role.Code == "ADMIN"))
            {
                var hasher = PasswordHasher.Instance;
                Entities.Role adminRole = context.Roles.First(r => r.Code == "ADMIN");
                context.Users.Add(new Entities.User
                {
                    Account = "adminbtpm",
                    PasswordHash = hasher.hash("admin123456"),
                    RoleID = adminRole.ID,
                    Name = "Siêu cấp admin",
                    PhoneNumber = "0922889911",
                });

                context.SaveChanges();
            }
        }
    }
}
