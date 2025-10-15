using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;
using System.Data.SqlClient;
using CuahangNongduoc.BusinessObject;

namespace CuahangNongduoc.DataLayer
{
    public class PhieuBanFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<PhieuBanFactory>();

        public PhieuBanFactory()
        {
            logger.Debug("Initialized PhieuBanFactory");
        }

        public DataTable TimPhieuBan(String idKh, DateTime dt)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE NGAY_BAN = @ngay AND ID_KHACH_HANG=@kh");
            cmd.Parameters.Add("ngay", OleDbType.Date).Value = dt;
            cmd.Parameters.Add("kh", OleDbType.VarChar).Value = idKh;

            m_Ds.Load(cmd);

            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_BAN WHERE NGAY_BAN = @ngay AND ID_KHACH_HANG = @kh");
            cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = dt;
            cmd.Parameters.Add("@kh", SqlDbType.VarChar, 50).Value = idKh;

            da.Execute(cmd);
            return da;
        }

        public DataTable DanhsachPhieuBanLe()
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=FALSE");
            m_Ds.Load(cmd);

            return m_Ds;*/

            SqlCommand cmd = new SqlCommand(@"SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG = KH.ID WHERE KH.LOAI_KH = 0");
            da.Execute(cmd);
            return da;
        }
        public DataTable DanhsachPhieuBanSi()
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=TRUE");
            m_Ds.Load(cmd);

            return m_Ds;*/

            SqlCommand cmd = new SqlCommand(@"SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG = KH.ID WHERE KH.LOAI_KH = 1");
            da.Execute(cmd);
            return da;
        }


        public DataTable LayPhieuBan(String id)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_BAN WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;

            da.Execute(cmd);
            return da;
        }


        public DataTable LayChiTietPhieuBan(String idPhieuBan)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_BAN WHERE ID_PHIEU_BAN = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = idPhieuBan;
            m_Ds.Load(cmd);
            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM CHI_TIET_PHIEU_BAN WHERE ID_PHIEU_BAN = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;

            da.Execute(cmd);
            return da;
        }

        public static long LayConNo(String kh, int thang, int nam)
        {
            /*DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(CON_NO) FROM PHIEU_BAN WHERE ID_KHACH_HANG = @kh AND MONTH(NGAY_BAN)=@thang AND YEAR(NGAY_BAN)= @nam");
            cmd.Parameters.Add("kh", OleDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;

            object obj = ds.ExecuteScalar(cmd);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt64(obj);*/

            DataAccessObj da = new DataAccessObj();
            SqlCommand cmd = new SqlCommand(@"SELECT SUM(CON_NO) FROM PHIEU_BAN WHERE ID_KHACH_HANG = @kh AND MONTH(NGAY_BAN) = @thang AND YEAR(NGAY_BAN) = @nam");

            cmd.Parameters.Add("@kh", SqlDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            long result = da.ExecuteScalar<long>(cmd);
            return result;
        }

        public static int LaySoPhieu()
        {
            /*DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM PHIEU_BAN");
            
            object obj = ds.ExecuteScalar(cmd);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);*/

            DataAccessObj da = new DataAccessObj();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PHIEU_BAN");

            int result = da.ExecuteScalar<int>(cmd);
            return result;
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
