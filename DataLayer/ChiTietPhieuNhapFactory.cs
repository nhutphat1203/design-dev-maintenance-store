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
    public class ChiTietPhieuNhapFactory
    {
        //DataService m_Ds = new DataService();

        private readonly DataAccessObj da = new DataAccessObj();

        public void LoadSchema()
        {
            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP = '-1'");
            //m_Ds.Load(cmd);

            SqlCommand cmd = new SqlCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP = '-1'");
            da.Execute(cmd);
        }

        public DataTable LayChiTietPhieuNhap(String id)
        {
            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP = @id");
            //cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            //m_Ds.Load(cmd);
            //return m_Ds;

            SqlCommand cmd = new SqlCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;
            da.Execute(cmd);
            return da;
        }

        public int XoaChiTietPhieuNhap(String id)
        {
            //OleDbCommand cmd = new OleDbCommand("DELETE FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP = @id");
            //cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            //return m_Ds.ExecuteNoneQuery(cmd);

            SqlCommand cmd = new SqlCommand("DELETE FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP = @id");
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;
            return da.ExecuteNoneQuery(cmd);
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
