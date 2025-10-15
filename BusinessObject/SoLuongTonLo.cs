using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.BusinessObject
{
    internal class SoLuongTonLo
    {
        private MaSanPham m_MaSanPham;

        public MaSanPham MaSanPham
        {
            get { return m_MaSanPham; }
            set { m_MaSanPham = value; }
        }

        private int m_SoLuongTon;

        public int SoLuong
        {
            get { return m_SoLuongTon; }
            set { m_SoLuongTon = value; }
        }
    }
}
