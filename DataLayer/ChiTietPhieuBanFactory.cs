using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;
using System.Data.SqlClient;

namespace CuahangNongduoc.DataLayer
{
    public class ChiTietPhieuBanFactory
    {
        //DataService m_Ds = new DataService();

        private readonly DataAccessObj da = new DataAccessObj();

        public DataTable LayChiTietPhieuBan(String idPhieuBan)
        {
            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_BAN WHERE ID_PHIEU_BAN = @id");
            //cmd.Parameters.Add("id", OleDbType.VarChar , 50).Value = idPhieuBan;
            //m_Ds.Load(cmd);
            //return m_Ds;

            SqlCommand cmd = new SqlCommand(@"
              SELECT *
              FROM CHI_TIET_PHIEU_BAN
              WHERE ID_PHIEU_BAN = @id
            ");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = idPhieuBan;
            da.Execute(cmd);
            return da;
        }

        public DataTable LayChiTietPhieuBan(DateTime dtNgayBan)
        {
            //OleDbCommand cmd = new OleDbCommand("SELECT CT.* FROM CHI_TIET_PHIEU_BAN CT INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID " +
            //        " WHERE PB.NGAY_BAN = @ngayban");
            //cmd.Parameters.Add("ngayban", OleDbType.Date).Value = dtNgayBan;
            //m_Ds.Load(cmd);
            //return m_Ds;

            SqlCommand cmd = new SqlCommand(@"
                SELECT CT.* 
                FROM CHI_TIET_PHIEU_BAN CT 
                INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID 
                WHERE PB.NGAY_BAN = @ngayban");

            cmd.Parameters.Add("@ngayban", SqlDbType.DateTime).Value = dtNgayBan;
            da.Execute(cmd);
            return da;
        }

        public DataTable LayChiTietPhieuBan(int thang, int nam)
        {
            //OleDbCommand cmd = new OleDbCommand("SELECT CT.* FROM CHI_TIET_PHIEU_BAN CT INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID " +
            //        " WHERE MONTH(PB.NGAY_BAN) = @thang AND YEAR(PB.NGAY_BAN)= @nam");
            //cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            //cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;
            //m_Ds.Load(cmd);
            //return m_Ds;

            SqlCommand cmd = new SqlCommand(@"
                SELECT CT.* 
                FROM CHI_TIET_PHIEU_BAN CT 
                INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID 
                WHERE MONTH(PB.NGAY_BAN) = @thang AND YEAR(PB.NGAY_BAN) = @nam");

            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;
            da.Execute(cmd);
            return da;
        }

        
        
        public DataRow NewRow()
        {
            //return m_Ds.NewRow();
            return da.NewRow();
        }
        public void Add(DataRow row)
        {
            //m_Ds.Rows.Add(row);
            da.Rows.Add(row);
        }
       public bool Save()
        {
            //return m_Ds.ExecuteNoneQuery() > 0;

            return da.ExecuteNoneQuery() > 0;
        }
    }
}
