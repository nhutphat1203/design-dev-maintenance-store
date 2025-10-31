namespace CuahangNongduoc.GiamGia
{
    public class GiamGiaContext
    {
        private IGiamGiaStrategy _strategy;

        public GiamGiaContext(IGiamGiaStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IGiamGiaStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal TinhGiam(decimal tongTien, decimal giaTri)
        {
            return _strategy.TinhGiam(tongTien, giaTri);
        }
    }
}
