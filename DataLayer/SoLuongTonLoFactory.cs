using System;
using System.Data;
using System.Data.SqlClient;
using CuahangNongduoc.DataAccess;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.DataLayer
{
    public class SoLuongTonLoFactory
    {
        private readonly DataAccessObj da = new DataAccessObj();
        private static readonly ILogger logger = new Logger<SoLuongTonLoFactory>();

        public SoLuongTonLoFactory()
        {
            logger.Debug("Initialized SoLuongTonLoFactory");
        }

        private bool KiemTraTonTai(string idMaSanPham)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM SO_LUONG_TON_LO WHERE ID_MA_SAN_PHAM = @idMaSanPham");
            cmd.Parameters.Add("@idMaSanPham", SqlDbType.NVarChar, 50).Value = idMaSanPham;

            int count = da.ExecuteScalar<int>(cmd);
            return count > 0;
        }

        public int LaySoLuongTon(string idMaSanPham)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT SO_LUONG_TON FROM SO_LUONG_TON_LO WHERE ID_MA_SAN_PHAM = @idMaSanPham");
            cmd.Parameters.Add("@idMaSanPham", SqlDbType.NVarChar, 50).Value = idMaSanPham;

            int ton = da.ExecuteScalar<int>(cmd);
            return ton;
        }

        public void TangSoLuongTon(string idMaSanPham, int soLuongThem)
        {
            try
            {
                bool tonTai = KiemTraTonTai(idMaSanPham);

                SqlCommand cmd;
                if (!tonTai)
                {
                    cmd = new SqlCommand(@"
                        INSERT INTO SO_LUONG_TON_LO (ID_MA_SAN_PHAM, ID_SAN_PHAM, SO_LUONG_TON)
                        VALUES (@idMaSanPham, @idSanPham, @soLuongThem)");
                }
                else
                {
                    cmd = new SqlCommand(@"
                        UPDATE SO_LUONG_TON_LO
                        SET SO_LUONG_TON = SO_LUONG_TON + @soLuongThem
                        WHERE ID_MA_SAN_PHAM = @idMaSanPham");
                }

                cmd.Parameters.AddWithValue("@idMaSanPham", idMaSanPham);
                cmd.Parameters.AddWithValue("@soLuongThem", soLuongThem);

                da.ExecuteNoneQuery(cmd);
                logger.Info($"Đã tăng {soLuongThem} cho lô {idMaSanPham}");
            }
            catch (Exception ex)
            {
                logger.Error("Lỗi khi tăng số lượng tồn", ex);
                throw;
            }
        }

        public bool GiamSoLuongTon(string idMaSanPham, int soLuongGiam)
        {
            try
            {
                int tonHienTai = LaySoLuongTon(idMaSanPham);

                if (tonHienTai < soLuongGiam)
                {
                    logger.Info($"Không đủ hàng tồn (hiện có {tonHienTai}, cần {soLuongGiam}) cho lô {idMaSanPham}");
                    return false;
                }

                SqlCommand cmd = new SqlCommand(@"
                    UPDATE SO_LUONG_TON_LO
                    SET SO_LUONG_TON = SO_LUONG_TON - @soLuongGiam
                    WHERE ID_MA_SAN_PHAM = @idMaSanPham");

                cmd.Parameters.AddWithValue("@idMaSanPham", idMaSanPham);
                cmd.Parameters.AddWithValue("@soLuongGiam", soLuongGiam);

                da.ExecuteNoneQuery(cmd);
                logger.Info($"Đã giảm {soLuongGiam} cho lô {idMaSanPham}");
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Lỗi khi giảm số lượng tồn", ex);
                throw;
            }
        }

        public bool Save()
        {
            return da.ExecuteNoneQuery() > 0;
        }
    }
}
