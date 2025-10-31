using CuahangNongduoc.DataLayer;
using CuahangNongduoc.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Controller
{
    internal class GiamGiaController
    {
        private readonly GGApDungTrenPBFactory _factory = new GGApDungTrenPBFactory();
        private static readonly ILogger logger = new Logger<GiamGiaController>();

        public GiamGiaController()
        {
            logger.Debug("Initialized GiamGiaController");
        }

        public decimal LayTheoPhieuBan(string idPhieuBan)
        {
            try
            {
                return _factory.LayTheoPhieuBan(idPhieuBan);
            }
            catch (Exception ex)
            {
                logger.Error("LayTheoPhieuBan failed", ex);
                return 0;
            }
        }

        public bool LayLoaiTheoPhieuBan(string idPhieuBan)
        {
            try
            {
                return _factory.LayLoaiTheoPhieuBan(idPhieuBan);
            }
            catch (Exception ex)
            {
                logger.Error("LayTheoPhieuBan failed", ex);
                return false;
            }
        }

        public bool CapNhat(string idPhieuBan, bool loai, decimal giaTriGiam)
        {
            try
            {
                return _factory.CapNhat(idPhieuBan, loai, giaTriGiam);
            }
            catch (Exception ex)
            {
                logger.Error("CapNhat failed", ex);
                return false;
            }
        }

        public bool Xoa(string idPhieuBan)
        {
            try
            {
                return _factory.Xoa(idPhieuBan);
            }
            catch (Exception ex)
            {
                logger.Error("Xoa failed", ex);
                return false;
            }
        }
    }
}
