using CuahangNongduoc.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Controller
{
    internal class PhuPhiController
    {
        private readonly PhuPhiFactory factory = new PhuPhiFactory();

        public PhuPhiController()
        {
            factory.LoadSchema();
        }

        public DataTable LayTheoPhieuBan(string idPhieuBan)
        {
            return factory.LayTheoPB(idPhieuBan);
        }

        public decimal TongTien(string idPhieuBan)
        {
            return factory.TongTien(idPhieuBan);
        }

        public void Add(string idPhieuBan, string ten, decimal soTien, string ghiChu)
        {
            factory.Them(idPhieuBan, ten, soTien, ghiChu);
        }

        public bool Delete(int id)
        {
            return factory.Delete(id);
        }

        public bool Save()
        {
            return factory.Save();
        }
    }
}
