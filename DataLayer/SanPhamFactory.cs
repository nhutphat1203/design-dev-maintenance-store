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
               "SELECT " +
               "SP.ID, " +
               "SP.TEN_SAN_PHAM, " +
               "SP.DON_GIA_NHAP, " +
               "SP.GIA_BAN_SI, " +
               "SP.GIA_BAN_LE, " +
               "SP.ID_DON_VI_TINH, " +
               "SP.SO_LUONG, " +
               "SP.SO_LUONG - ISNULL(SUM(BAN.SO_LUONG), 0) AS SO_LUONG_TON " +
               "FROM SAN_PHAM SP " +
               "LEFT JOIN MA_SAN_PHAM MA ON SP.ID = MA.ID_SAN_PHAM " +
               "LEFT JOIN CHI_TIET_PHIEU_BAN BAN ON MA.ID = BAN.ID_MA_SAN_PHAM " +
               "GROUP BY " +
               "SP.ID, SP.TEN_SAN_PHAM, SP.DON_GIA_NHAP, " +
               "SP.GIA_BAN_SI, SP.GIA_BAN_LE, SP.ID_DON_VI_TINH, SP.SO_LUONG"
            );

            da.Execute(cmd);
            return da;
        }

        public DataTable LayNhieuLoHangFIFO(string idSanPham)
        {
            using (DataAccessObj da = new DataAccessObj())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT MA.ID AS ID_MA_SAN_PHAM, 
                           MA.ID_SAN_PHAM, 
                           TON.SO_LUONG_TON, 
                           MA.NGAY_NHAP
                    FROM MA_SAN_PHAM MA
                    INNER JOIN SO_LUONG_TON_LO TON ON MA.ID = TON.ID_MA_SAN_PHAM
                    WHERE MA.ID_SAN_PHAM = @idSanPham AND TON.SO_LUONG_TON > 0
                    ORDER BY MA.NGAY_HET_HAN ASC
                    ");
                cmd.Parameters.Add("@idSanPham", SqlDbType.VarChar, 50).Value = idSanPham;

                da.Execute(cmd);
                return da;
            }
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
