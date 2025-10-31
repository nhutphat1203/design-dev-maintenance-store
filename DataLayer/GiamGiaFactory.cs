using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class GiamGiaFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<GiamGiaFactory>();

        public GiamGiaFactory()
        {
            logger.Debug("Initialized GiamGiaFactory");
        }

        public DataTable DanhSach()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM GIAM_GIA");
            da.Execute(cmd);
            return da;
        }

        public DataTable LayTheoID(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM GIAM_GIA WHERE ID = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            da.Execute(cmd);
            return da;
        }

        public DataTable TimTheoTen(string ten)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM GIAM_GIA WHERE TEN_GIAM_GIA LIKE '%' + @ten + '%'");
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;
            da.Execute(cmd);
            return da;
        }

        public bool Them(string tenGiamGia, DateTime ngayBD, DateTime ngayKT, decimal? giaTri)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO GIAM_GIA (TEN_GIAM_GIA, GIA_TRI, NGAY_BD, NGAY_KT,)
                    VALUES (@ten, @giaTri, @ngayBD, @ngayKT)
                ");

                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenGiamGia;
                cmd.Parameters.Add("@ngayBD", SqlDbType.Date).Value = ngayBD;
                cmd.Parameters.Add("@ngayKT", SqlDbType.Date).Value = ngayKT;
                cmd.Parameters.Add("@giaTri", SqlDbType.Decimal).Value = (object)giaTri ?? DBNull.Value;

                int rows = da.ExecuteNoneQuery(cmd);
                logger.Info($"Thêm giảm giá '{tenGiamGia}' thành công ({rows} dòng).");
                return rows > 0;
            }
            catch (Exception ex)
            {
                logger.Error("Lỗi khi thêm giảm giá mới", ex);
                return false;
            }
        }

        public bool CapNhat(int id, string tenGiamGia, DateTime ngayBD, DateTime ngayKT, decimal? giaTri)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE GIAM_GIA
                    SET TEN_GIAM_GIA = @ten,
                        NGAY_BD = @ngayBD,
                        NGAY_KT = @ngayKT,
                        GIA_TRI = @giaTri
                    WHERE ID = @id
                ");

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenGiamGia;
                cmd.Parameters.Add("@ngayBD", SqlDbType.Date).Value = ngayBD;
                cmd.Parameters.Add("@ngayKT", SqlDbType.Date).Value = ngayKT;
                cmd.Parameters.Add("@giaTri", SqlDbType.Decimal).Value = (object)giaTri ?? DBNull.Value;

                int rows = da.ExecuteNoneQuery(cmd);
                logger.Info($"Cập nhật giảm giá ID={id} thành công ({rows} dòng).");
                return rows > 0;
            }
            catch (Exception ex)
            {
                logger.Error("Lỗi khi cập nhật giảm giá", ex);
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
