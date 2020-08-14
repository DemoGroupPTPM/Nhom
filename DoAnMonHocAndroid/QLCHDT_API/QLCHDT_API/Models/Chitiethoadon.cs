using System;
using System.Collections.Generic;

namespace QLCHDT_API.Models
{
    public partial class Chitiethoadon
    {
        public string Mahd { get; set; }
        public string Masp { get; set; }
        public string Makhachhang { get; set; }
        public decimal? Dongia { get; set; }
        public int? Soluong { get; set; }
        public string Donvitinh { get; set; }
        public decimal? Thanhtien { get; set; }

        public Sanpham MaspNavigation { get; set; }
    }
}
