namespace CuahangNongduoc.GiamGia
{
    public class GiamTheoPhanTram : IGiamGiaStrategy
    {
        public decimal TinhGiam(decimal tongTien, decimal giaTri)
        {
            return tongTien * giaTri / 100;
        }
    }
}