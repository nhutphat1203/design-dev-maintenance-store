using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CuahangNongduoc.Utils.Logger;
using CuahangNongduoc.DataAccess;
using System.Data.SqlClient;

namespace CuahangNongduoc.DataLayer
{
    public class NhaCungCapFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<NhaCungCapFactory>();

        public NhaCungCapFactory()
        {
            logger.Debug("Initialized NhaCungCapFactory");
        }


        public DataTable DanhsachNCC()
        {
            /* OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP");
             m_Ds.Load(cmd);

             return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM NHA_CUNG_CAP");
            da.Execute(cmd);
            return da;
        }
        public DataTable TimDiaChi(String diachi)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP WHERE DIA_CHI LIKE '%' + @diachi + '%' ");
            cmd.Parameters.Add("diachi", OleDbType.VarChar).Value = diachi;
            m_Ds.Load(cmd);

            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM NHA_CUNG_CAP WHERE DIA_CHI LIKE '%' + @diachi + '%'");
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar, 100).Value = diachi;
            da.Execute(cmd);
            return da;
        }
        public DataTable TimHoTen(String hoten)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP WHERE HO_TEN LIKE '%' + @hoten + '%' ");
            cmd.Parameters.Add("hoten", OleDbType.VarChar).Value = hoten;
            m_Ds.Load(cmd);

            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM NHA_CUNG_CAP WHERE HO_TEN LIKE '%' + @hoten + '%'");
            cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 100).Value = hoten;
            da.Execute(cmd);
            return da;
        }

        public DataTable LayNCC(String id)
        {
            /*OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;*/

            SqlCommand cmd = new SqlCommand("SELECT * FROM NHA_CUNG_CAP WHERE ID = @id");
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
