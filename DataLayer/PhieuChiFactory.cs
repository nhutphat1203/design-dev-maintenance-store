using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;
using CuahangNongduoc.BusinessObject;
using System.Data.SqlClient;

namespace CuahangNongduoc.DataLayer
{
    public class PhieuChiFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<PhieuChiFactory>();

        public PhieuChiFactory()
        {
            logger.Debug("Initialized PhieuChiFactory");
        }

        public DataTable TimPhieuChi(int lydo, DateTime ngay)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_CHI WHERE ID_LY_DO_CHI = @lydo AND NGAY_CHI = @ngay");
            cmd.Parameters.Add("lydo", OleDbType.Integer).Value = lydo;
            cmd.Parameters.Add("ngay", OleDbType.Date).Value = ngay;

            m_Ds.Load(cmd);

            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_CHI WHERE ID_LY_DO_CHI = @lydo AND NGAY_CHI = @ngay");
            cmd.Parameters.Add("@lydo", SqlDbType.Int).Value = lydo;
            cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = ngay;

            da.Execute(cmd);
            return da;
        }

        public DataTable DanhsachPhieuChi()
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_CHI ");
            m_Ds.Load(cmd);

            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_CHI");
            da.Execute(cmd);
            return da;
        }
      
        public DataTable LayPhieuChi(String id)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_CHI WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_CHI WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;

            da.Execute(cmd);
            return da;
        }


        public static long LayTongTien(String lydo, int thang, int nam)
        {
            /*DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(TONG_TIEN) FROM PHIEU_CHI WHERE ID_LY_DO_CHI = @lydo AND MONTH(NGAY_CHI)=@thang AND YEAR(NGAY_CHI)= @nam");
            cmd.Parameters.Add("lydo", OleDbType.VarChar, 50).Value = lydo;
            cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;

            object obj = ds.ExecuteScalar(cmd);
            
            if (obj == null)
                return 0;
            else
                return Convert.ToInt64(obj);*/

            DataAccessObj da = new DataAccessObj();
            SqlCommand cmd = new SqlCommand(@"SELECT SUM(TONG_TIEN) FROM PHIEU_CHI WHERE ID_LY_DO_CHI = @lydo AND MONTH(NGAY_CHI) = @thang AND YEAR(NGAY_CHI) = @nam");

            cmd.Parameters.Add("@lydo", SqlDbType.VarChar, 50).Value = lydo;
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            long result = da.ExecuteScalar<long>(cmd);
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
