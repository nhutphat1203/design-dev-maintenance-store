using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.DataLayer
{
    internal class UsersFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<ChietKhauFactory>();

        public UsersFactory()
        {
            logger.Debug("Initialized ChietKhauFactory");
        }

        public DataTable LayUsers()
        {
            string sql = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(sql);

            da.Execute(cmd);
            return da;
        }
    }
}
