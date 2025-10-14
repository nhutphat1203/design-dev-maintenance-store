using CuahangNongduoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Service.User
{
    public interface IUserService
    {

        IEnumerable<Entities.User> getAll();

        Entities.User getById(int id);

        void add(Entities.User user);

        void update(Entities.User user);

        void delete(int id);
    }
}
