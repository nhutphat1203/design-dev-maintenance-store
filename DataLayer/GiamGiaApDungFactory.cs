using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class GiamGiaApDungFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<GiamGiaApDungFactory>();

        public GiamGiaApDungFactory()
        {
            logger.Debug("Initialized GiamGiaApDungFactory");
        }

        public DataTable DanhSach()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM GIAM_GIA_AP_DUNG");
            da.Execute(cmd);
            return da;
        }

        public DataTable LayTheoGiamGia(int idGiamGia)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM GIAM_GIA_AP_DUNG WHERE ID_GIAM_GIA = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idGiamGia;
            da.Execute(cmd);
            return da;
        }

        public DataTable LayTheoSanPham(string idSanPham)
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    G.ID,
                    G.TEN_GIAM_GIA,
                    G.GIA_TRI,
                    G.NGAY_BD,
                    G.NGAY_KT
                FROM GIAM_GIA G
                INNER JOIN GIAM_GIA_AP_DUNG GA ON G.ID = GA.ID_GIAM_GIA
                WHERE GA.ID_SAN_PHAM = @idsp
            ");
            cmd.Parameters.Add("@idsp", SqlDbType.VarChar, 50).Value = idSanPham;
            da.Execute(cmd);
            return da;
        }

        public bool XoaTheoSanPham(string idSanPham)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM GIAM_GIA_AP_DUNG WHERE ID_SAN_PHAM = @idsp");
            cmd.Parameters.Add("@idsp", SqlDbType.VarChar, 50).Value = idSanPham;
            return da.ExecuteNoneQuery(cmd) > 0;
        }

        public bool Them(int idgiamgia, string idsanpham)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO GIAM_GIA_AP_DUNG (ID_GIAM_GIA, ID_SAN_PHAM) VALUES (@idgg, @idsp)");
                cmd.Parameters.Add("@idgg", SqlDbType.Int).Value = idgiamgia;
                cmd.Parameters.Add("@idsp", SqlDbType.VarChar, 50).Value = idsanpham;

                return da.ExecuteNoneQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                logger.Error("Lỗi khi thêm GIAM_GIA_AP_DUNG", ex);
                return false;
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
