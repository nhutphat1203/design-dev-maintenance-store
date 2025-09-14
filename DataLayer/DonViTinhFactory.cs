using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CuahangNongduoc.DataAccess;
using System.Data.SqlClient;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class DonViTinhFactory
    {

        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<DonViTinhFactory>();
        public DonViTinhFactory()
        {
            logger.Debug("Initialized DonViTinhFactory");
        }

        public DataTable DanhsachDVT()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM DON_VI_TINH");

            da.Execute(cmd);

            return da;
        }


        public DataTable LayDVT(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DON_VI_TINH WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            da.Execute(cmd);
            return da;
        }
        public bool Save()
        {
            return da.ExecuteNoneQuery() > 0;
        }
    }
}
