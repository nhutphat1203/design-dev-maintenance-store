using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class LyDoChiFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<LyDoChiFactory>();

        public LyDoChiFactory()
        {
            logger.Debug("Initialized LyDoChiFactory");
        }

        public DataTable DanhsachLyDo()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM LY_DO_CHI");
            da.Execute(cmd);
            return da;
        }

        public DataTable LayLyDoChi(long id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM LY_DO_CHI WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

            da.Execute(cmd);
            return da;
        }

        public bool Save()
        {
            return da.ExecuteNoneQuery() > 0;
        }
    }
}
