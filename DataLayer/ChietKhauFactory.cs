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
    internal class ChietKhauFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<ChietKhauFactory>();

        public ChietKhauFactory()
        {
            logger.Debug("Initialized ChietKhauFactory");
        }

        public void LoadSchema()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CHIET_KHAU WHERE ID_KHACH_HANG = '-1'");
            da.Execute(cmd);
        }

        public decimal LayTheoKhachHang(string idKhachHang)
        {
            string sql = "SELECT ISNULL(GIA_TRI, 0) FROM CHIET_KHAU WHERE ID_KHACH_HANG = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idKhachHang;

            return da.ExecuteScalar<decimal>(cmd);
        }

        public DataTable LayChietKhau()
        {
            string sql = "SELECT * FROM CHIET_KHAU";
            SqlCommand cmd = new SqlCommand(sql);

            da.Execute(cmd);
            return da;
        }

        public bool CapNhat(string idKhachHang, decimal giaTri)
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM CHIET_KHAU WHERE ID_KHACH_HANG = @id)
                    UPDATE CHIET_KHAU SET GIA_TRI = @giaTri WHERE ID_KHACH_HANG = @id
                ELSE
                    INSERT INTO CHIET_KHAU (ID_KHACH_HANG, GIA_TRI) VALUES (@id, @giaTri)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idKhachHang;
            cmd.Parameters.Add("@giaTri", SqlDbType.Decimal).Value = giaTri;

            return da.ExecuteNoneQuery(cmd) > 0;
        }

        public bool Xoa(string idKhachHang)
        {
            string sql = "DELETE FROM CHIET_KHAU WHERE ID_KHACH_HANG = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idKhachHang;

            return da.ExecuteNoneQuery(cmd) > 0;
        }
    }
}
