using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuahangNongduoc.BusinessObject;
using System.Drawing;

namespace CuahangNongduoc.DataLayer
{
    internal class PhuPhiFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<PhuPhiFactory>();

        public PhuPhiFactory()
        {
            logger.Debug("Initialized PhuPhiFactory");
        }

        public void LoadSchema()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_BAN_PHU_PHI WHERE ID = -1");
            da.Execute(cmd);
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM PHIEU_BAN_PHU_PHI WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            return da.ExecuteNoneQuery(cmd) > 0;
        }

        public bool Them(string idPhieuBan, string ten, decimal soTien, string ghiChu)
        {
            string sql = @"INSERT INTO PHIEU_BAN_PHU_PHI (ID_PHIEU_BAN, TEN, SO_TIEN, GHI_CHU)
                   VALUES (@idPhieuBan, @ten, @soTien, @ghiChu)"
            ;

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@idPhieuBan", SqlDbType.VarChar, 50).Value = idPhieuBan;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;
            cmd.Parameters.Add("@soTien", SqlDbType.Decimal).Value = soTien;
            cmd.Parameters.Add("@ghiChu", SqlDbType.NVarChar, 255).Value = ghiChu ?? (object)DBNull.Value;

            return da.ExecuteNoneQuery(cmd) > 0;
        }


        public bool Save()
        {
            return da.ExecuteNoneQuery() > 0;
        }

        public DataTable LayTheoPB(string idPhieuBan)
        {
            string sql = "SELECT ID, TEN, SO_TIEN, GHI_CHU FROM PHIEU_BAN_PHU_PHI WHERE ID_PHIEU_BAN = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            da.Execute(cmd);
            return da;
        }

        public decimal TongTien(string idPhieuBan)
        {
            string sql = "SELECT ISNULL(SUM(SO_TIEN), 0) FROM PHIEU_BAN_PHU_PHI WHERE ID_PHIEU_BAN = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            return da.ExecuteScalar<decimal>(cmd);
        }
    }
}
