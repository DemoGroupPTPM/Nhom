using System;
using System.Collections.Generic;

namespace QLCHDT_API.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        public string Mancc { get; set; }
        public string Tenncc { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public string Chuthich { get; set; }

        public ICollection<Sanpham> Sanpham { get; set; }
    }
}
