using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class KhachHangFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<KhachHangFactory>();

        public KhachHangFactory()
        {
            logger.Debug("Initialized KhachHangFactory");
        }

        public DataTable DanhsachKhachHang(bool loai)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE LOAI_KH = @loai");
            cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;
            da.Execute(cmd);
            return da;
        }

        public DataTable TimHoTen(string hoten, bool loai)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE HO_TEN LIKE '%' + @hoten + '%' AND LOAI_KH = @loai");
            cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 100).Value = hoten;
            cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;

            da.Execute(cmd);
            return da;
        }

        public DataTable TimDiaChi(string diachi, bool loai)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE DIA_CHI LIKE '%' + @diachi + '%' AND LOAI_KH = @loai");
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar, 200).Value = diachi;
            cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;

            da.Execute(cmd);
            return da;
        }

        public DataTable DanhsachKhachHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG");
            da.Execute(cmd);
            return da;
        }

        public DataTable LayKhachHang(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACH_HANG WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;

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
