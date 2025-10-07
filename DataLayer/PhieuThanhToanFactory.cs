using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class PhieuThanhToanFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<PhieuThanhToanFactory>();

        public PhieuThanhToanFactory()
        {
            logger.Debug("Initialized PhieuThanhToanFactory");
        }

        public DataTable DanhsachPhieuThanhToan()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_THANH_TOAN");
            da.Execute(cmd);
            return da;
        }

        public DataTable TimPhieuThanhToan(string kh, DateTime ngay)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM PHIEU_THANH_TOAN WHERE ID_KHACH_HANG = @kh AND NGAY_THANH_TOAN = @ngay"
            );
            cmd.Parameters.Add("@kh", SqlDbType.VarChar).Value = kh;
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;

            da.Execute(cmd);
            return da;
        }

        public DataTable LayPhieuThanhToan(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_THANH_TOAN WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;

            da.Execute(cmd);
            return da;
        }

        public static long LayTongTien(string kh, int thang, int nam)
        {
            DataAccessObj ds = new DataAccessObj();
            SqlCommand cmd = new SqlCommand(
                "SELECT SUM(TONG_TIEN) FROM PHIEU_THANH_TOAN " +
                "WHERE ID_KHACH_HANG = @kh AND MONTH(NGAY_THANH_TOAN) = @thang AND YEAR(NGAY_THANH_TOAN) = @nam"
            );

            cmd.Parameters.Add("@kh", SqlDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            long obj = ds.ExecuteScalar<long>(cmd);
            return obj;
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
