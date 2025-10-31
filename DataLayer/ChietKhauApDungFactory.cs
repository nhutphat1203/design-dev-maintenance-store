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
    internal class ChietKhauApDungFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<ChietKhauApDungFactory>();

        public ChietKhauApDungFactory()
        {
            logger.Debug("Initialized ChietKhauApDungFactory");
        }

        public void LoadSchema()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CHIET_KHAU_AP_DUNG WHERE ID_PHIEU_BAN = '-1'");
            da.Execute(cmd);
        }

        public decimal LayTheoPhieuBan(string idPhieuBan)
        {
            string sql = "SELECT ISNULL(GIA_TRI_GIAM, 0) FROM CHIET_KHAU_AP_DUNG WHERE ID_PHIEU_BAN = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            return da.ExecuteScalar<decimal>(cmd);
        }

        public bool CapNhat(string idPhieuBan, decimal giaTriGiam)
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM CHIET_KHAU_AP_DUNG WHERE ID_PHIEU_BAN = @id)
                    UPDATE CHIET_KHAU_AP_DUNG SET GIA_TRI_GIAM = @giaTriGiam WHERE ID_PHIEU_BAN = @id
                ELSE
                    INSERT INTO CHIET_KHAU_AP_DUNG (ID_PHIEU_BAN, GIA_TRI_GIAM)
                    VALUES (@id, @giaTriGiam)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;
            cmd.Parameters.Add("@giaTriGiam", SqlDbType.Decimal).Value = giaTriGiam;

            return da.ExecuteNoneQuery(cmd) > 0;
        }

        public bool Xoa(string idPhieuBan)
        {
            string sql = "DELETE FROM CHIET_KHAU_AP_DUNG WHERE ID_PHIEU_BAN = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            return da.ExecuteNoneQuery(cmd) > 0;
        }
    }
}
