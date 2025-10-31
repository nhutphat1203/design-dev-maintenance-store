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
    internal class GGApDungTrenPBFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<GGApDungTrenPBFactory>();

        public GGApDungTrenPBFactory()
        {
            logger.Debug("Initialized GGApDungTrenPBFactory");
        }

        public void LoadSchema()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM GG_AP_DUNG_TREN_PB WHERE ID_PHIEU_BAN = '-1'");
            da.Execute(cmd);
        }

        public decimal LayTheoPhieuBan(string idPhieuBan)
        {
            string sql = "SELECT ISNULL(GIA_TRI_GIAM, 0) FROM GG_AP_DUNG_TREN_PB WHERE ID_PHIEU_BAN = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            return da.ExecuteScalar<decimal>(cmd);
        }

        public bool LayLoaiTheoPhieuBan(string idPhieuBan)
        {
            string sql = "SELECT ISNULL(LOAI_GIAM, false) FROM GG_AP_DUNG_TREN_PB WHERE ID_PHIEU_BAN = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            return da.ExecuteScalar<bool>(cmd);
        }

        public bool CapNhat(string idPhieuBan, bool loai, decimal giaTriGiam)
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM GG_AP_DUNG_TREN_PB WHERE ID_PHIEU_BAN = @id)
                    UPDATE GG_AP_DUNG_TREN_PB SET GIA_TRI_GIAM = @giaTriGiam, LOAI_GIAM = @loai WHERE ID_PHIEU_BAN = @id
                ELSE
                    INSERT INTO GG_AP_DUNG_TREN_PB (ID_PHIEU_BAN, LOAI_GIAM, GIA_TRI_GIAM)
                    VALUES (@id, @loai, @giaTriGiam)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;
            cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;
            cmd.Parameters.Add("@giaTriGiam", SqlDbType.Decimal).Value = giaTriGiam;

            return da.ExecuteNoneQuery(cmd) > 0;
        }

        public bool Xoa(string idPhieuBan)
        {
            string sql = "DELETE FROM GG_AP_DUNG_TREN_PB WHERE ID_PHIEU_BAN = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            return da.ExecuteNoneQuery(cmd) > 0;
        }
    }
}
