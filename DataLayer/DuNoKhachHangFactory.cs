using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class DuNoKhachHangFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<DuNoKhachHangFactory>();

        public DuNoKhachHangFactory()
        {
            logger.Debug("Initialized DuNoKhachHangFactory");
        }

        public void LoadSchema()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DU_NO_KH WHERE ID_KHACH_HANG='-1'");
            da.Execute(cmd);
        }

        public DataTable DanhsachDuNo(int thang, int nam)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DU_NO_KH WHERE THANG=@thang AND NAM=@nam");
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            da.Execute(cmd);
            return da;
        }

        public DataTable LayDuNoKhachHang(string kh, int thang, int nam)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DU_NO_KH WHERE ID_KHACH_HANG=@kh AND THANG=@thang AND NAM=@nam");
            cmd.Parameters.Add("@kh", SqlDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            da.Execute(cmd);
            return da;
        }

        public static long LayDuNo(string kh, int thang, int nam)
        {
            DataAccessObj ds = new DataAccessObj();
            SqlCommand cmd = new SqlCommand("SELECT CUOI_KY FROM DU_NO_KH WHERE ID_KHACH_HANG=@kh AND THANG=@thang AND NAM=@nam");
            cmd.Parameters.Add("@kh", SqlDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            long res = ds.ExecuteScalar<long>(cmd);
            return Convert.ToInt64(res);
        }

        public void Clear(int thang, int nam)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM DU_NO_KH WHERE THANG=@thang AND NAM=@nam");
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            da.ExecuteNoneQuery(cmd);
        }

        public bool Save()
        {
            return da.ExecuteNoneQuery() > 0;
        }
        public DataRow NewRow()
        {
            return da.NewRow();
        }

        public void Add(DataRow row)
        {
            da.Rows.Add(row);
        }
    }
}
