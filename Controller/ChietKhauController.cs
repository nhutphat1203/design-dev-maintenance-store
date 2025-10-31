using CuahangNongduoc.DataLayer;
using CuahangNongduoc.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Controller
{
    internal class ChietKhauController
    {
        private readonly ChietKhauFactory _chietKhauFactory = new ChietKhauFactory();
        private readonly ChietKhauApDungFactory _apDungFactory = new ChietKhauApDungFactory();
        private static readonly ILogger logger = new Logger<ChietKhauController>();

        public ChietKhauController()
        {
            logger.Debug("Initialized ChietKhauController");
        }

        #region === Chiết khấu theo khách hàng ===

        public decimal LayChietKhauKhachHang(string idKhachHang)
        {
            try
            {
                return _chietKhauFactory.LayTheoKhachHang(idKhachHang);
            }
            catch (Exception ex)
            {
                logger.Error("LayChietKhauKhachHang failed", ex);
                return 0;
            }
        }

        public DataTable DanhSachChietKhau()
        {
            return _chietKhauFactory.LayChietKhau();
        }

        public bool CapNhatChietKhauKhachHang(string idKhachHang, decimal giaTri)
        {
            try
            {
                return _chietKhauFactory.CapNhat(idKhachHang, giaTri);
            }
            catch (Exception ex)
            {
                logger.Error("CapNhatChietKhauKhachHang failed", ex);
                return false;
            }
        }
        public bool XoaChietKhauKhachHang(string idKhachHang)
        {
            try
            {
                return _chietKhauFactory.Xoa(idKhachHang);
            }
            catch (Exception ex)
            {
                logger.Error("XoaChietKhauKhachHang failed", ex);
                return false;
            }
        }

        #endregion

        #region === Chiết khấu áp dụng cho phiếu bán ===

        public decimal LayChietKhauApDung(string idPhieuBan)
        {
            try
            {
                return _apDungFactory.LayTheoPhieuBan(idPhieuBan);
            }
            catch (Exception ex)
            {
                logger.Error("LayChietKhauApDung failed", ex);
                return 0;
            }
        }

        public bool CapNhatChietKhauApDung(string idPhieuBan, decimal giaTriGiam)
        {
            try
            {
                return _apDungFactory.CapNhat(idPhieuBan, giaTriGiam);
            }
            catch (Exception ex)
            {
                logger.Error("CapNhatChietKhauApDung failed", ex);
                return false;
            }
        }
        public bool XoaChietKhauApDung(string idPhieuBan)
        {
            try
            {
                return _apDungFactory.Xoa(idPhieuBan);
            }
            catch (Exception ex)
            {
                logger.Error("XoaChietKhauApDung failed", ex);
                return false;
            }
        }

        #endregion
    }
}
