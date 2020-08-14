using System;
using System.Collections.Generic;

namespace QLCHDT_API.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitiethoadon = new HashSet<Chitiethoadon>();
        }

        public string Masp { get; set; }
        public string Maloai { get; set; }
        public string Tenhang { get; set; }
        public string Hinhanh { get; set; }
        public decimal? Dongia { get; set; }
        public int? Soluong { get; set; }
        public string Baohanh { get; set; }
        public string Mancc { get; set; }

        public Loaihang MaloaiNavigation { get; set; }
        public Nhacungcap ManccNavigation { get; set; }
        public ICollection<Chitiethoadon> Chitiethoadon { get; set; }
    }
}
