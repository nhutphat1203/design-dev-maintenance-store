using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CuahangNongduoc.DataAccess
{
    public static class Connection
    {
        public static readonly string ConnectionString;
        private static readonly string EnvKey = "DbConnection";

        static Connection()
        {
            ConnectionString = ConfigurationManager.AppSettings[EnvKey];
        }
    }
}
