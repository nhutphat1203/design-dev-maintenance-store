using CuahangNongduoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Service.Role
{
    public interface IRoleService
    {
        IEnumerable<Entities.Role> getAll();
    }
}
