using System;
using System.Data;
using CuahangNongduoc.DataLayer;
using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Utils.Logger;

namespace CuahangNongduoc.Controller
{
    public class SoLuongTonLoController
    {
        private readonly SoLuongTonLoFactory factory = new SoLuongTonLoFactory();
        private static readonly ILogger logger = new Logger<SoLuongTonLoController>();

        public SoLuongTonLoController()
        {
            logger.Debug("Initialized SoLuongTonLoController");
        }

        public int LaySoLuongTon(string idMaSanPham)
        {
            try
            {
                int ton = factory.LaySoLuongTon(idMaSanPham);
                logger.Debug($"Lấy số lượng tồn của Mã sản phẩm {idMaSanPham}: {ton}");
                return ton;
            }
            catch (Exception ex)
            {
                logger.Error("Lỗi khi lấy số lượng tồn", ex);
                throw;
            }
        }


        public void TangSoLuongTon(string idMaSanPham, int soLuongThem)
        {
            try
            {
                factory.TangSoLuongTon(idMaSanPham, soLuongThem);
                logger.Info($"Đã tăng {soLuongThem} sản phẩm cho lô mã sản phẩm {idMaSanPham}");
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
                bool result = factory.GiamSoLuongTon(idMaSanPham, soLuongGiam);
                if (result)
                    logger.Info($"Đã giảm {soLuongGiam} sản phẩm cho lô mã sản phẩm {idMaSanPham}");
                else
                    logger.Info($"Không đủ số lượng để giảm {soLuongGiam} cho lô mã sản phẩm {idMaSanPham}");
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("Lỗi khi giảm số lượng tồn", ex);
                throw;
            }
        }
    }
}
