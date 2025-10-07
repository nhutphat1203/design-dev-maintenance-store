using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class SanPhamFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<SanPhamFactory>();

        public SanPhamFactory()
        {
            logger.Debug("Initialized SanPhamFactory");
        }

        public DataTable DanhsachSanPham()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SAN_PHAM");
            da.Execute(cmd);
            return da;
        }

        public DataTable TimMaSanPham(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SAN_PHAM WHERE ID LIKE '%' + @id + '%'");
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

            da.Execute(cmd);
            return da;
        }

        public DataTable TimTenSanPham(string ten)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SAN_PHAM WHERE TEN_SAN_PHAM LIKE '%' + @ten + '%'");
            cmd.Parameters.Add("@ten", SqlDbType.VarChar).Value = ten;

            da.Execute(cmd);
            return da;
        }

        public DataTable LaySanPham(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SAN_PHAM WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;

            da.Execute(cmd);
            return da;
        }

        public DataTable LaySoLuongTon()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT SP.ID, SP.TEN_SAN_PHAM, SP.DON_GIA_NHAP, SP.GIA_BAN_SI, SP.GIA_BAN_LE, SP.ID_DON_VI_TINH, SP.SO_LUONG, " +
                "SUM(MA.SO_LUONG) AS SO_LUONG_TON " +
                "FROM SAN_PHAM SP " +
                "INNER JOIN MA_SAN_PHAM MA ON SP.ID = MA.ID_SAN_PHAM " +
                "GROUP BY SP.ID, SP.TEN_SAN_PHAM, SP.DON_GIA_NHAP, SP.GIA_BAN_SI, SP.GIA_BAN_LE, SP.ID_DON_VI_TINH, SP.SO_LUONG"
            );

            da.Execute(cmd);
            return da;
        }

        public DataRow NewRow()
        {
            return da.NewRow();
        }

        public void Add(DataRow row)
        {
            da.Rows.Add(row);
        }

        public bool Save()
        {
            return da.ExecuteNoneQuery() > 0;
        }
    }
}
