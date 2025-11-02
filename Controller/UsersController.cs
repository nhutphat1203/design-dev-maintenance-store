using CuahangNongduoc.DataLayer;
using CuahangNongduoc.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Controller
{
    internal class UsersController
    {
        UsersFactory factory = new UsersFactory();
        private static readonly ILogger logger = new Logger<GiamGiaController>();

        public UsersController()
        {
            logger.Debug("Initialized GiamGiaController");
        }

        public DataTable LayUsers()
        {
            try
            {
                return factory.LayUsers();
            }
            catch (Exception ex)
            {
                logger.Error("LayUsers failed", ex);
                return null;
            }
        }
    }
}
