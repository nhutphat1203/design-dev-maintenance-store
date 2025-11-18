using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class PhieuNhapFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<PhieuNhapFactory>();

        public PhieuNhapFactory()
        {
            logger.Debug("Initialized PhieuNhapFactory");
        }

        public void LoadSchema()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_NHAP WHERE ID = '-1'");
            da.Execute(cmd);
        }

        public DataTable DanhsachPhieuNhap()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_NHAP");
            da.Execute(cmd);
            return da;
        }

        public DataTable TimPhieuNhap(string maNCC, DateTime dt)
        {
            string sql = "SELECT * FROM PHIEU_NHAP WHERE NGAY_NHAP = @ngay AND ID_NHA_CUNG_CAP = @ncc";
            SqlCommand cmd = new SqlCommand(sql);

            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@ncc", SqlDbType.VarChar).Value = maNCC;

            da.Execute(cmd);
            return da;
        }

        public DataTable LayPhieuNhap(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEU_NHAP WHERE ID = @id");
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
