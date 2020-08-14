using System;
using System.Collections.Generic;

namespace QLCHDT_API.Models
{
    public partial class Loaihang
    {
        public Loaihang()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        public string Maloai { get; set; }
        public string Tenloai { get; set; }

        public ICollection<Sanpham> Sanpham { get; set; }
    }
}
