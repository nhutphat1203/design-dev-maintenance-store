using CuahangNongduoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Entities
{
    public class UserSession
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public DateTime TimeAccess {  get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
