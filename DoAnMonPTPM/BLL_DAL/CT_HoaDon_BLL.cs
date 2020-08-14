using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
   public class CT_HoaDon_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();

        public IQueryable LoadChiTiet_HD_BLL(string mahd)
        {
            var h = (from s in qlch.CHITIETHOADONs
                     join l in qlch.SANPHAMs
                     on s.MASP
                     equals l.MASP
                     where s.MAHD == mahd
                     select new
                     {
                         s.MAHD,
                         s.MASP,
                         l.TENHANG,
                         s.DONGIA,
                         s.SOLUONG,
                         s.DONVITINH,
                         s.THANHTIEN
                     });
            //return qlch.CHITIETHOADONs.Where(h => h.MAHD == mahd).Select(h => h);

            return h;
        }

        public void ThemChiTiet_HoaDon(string mahd, string masp, decimal dongia,
           int soluong, string dvt, decimal thanhtien)
        {
            CHITIETHOADON hd = new CHITIETHOADON();
            hd.MAHD = mahd;
            hd.MASP = masp;
            hd.DONGIA = dongia;
            hd.SOLUONG = soluong;
            hd.DONVITINH = dvt;
            hd.THANHTIEN = thanhtien;
            qlch.CHITIETHOADONs.InsertOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public void suaChiTiet_HoaDon(string mahd, string masp, int soluong, decimal thanhtien)
        {
            CHITIETHOADON hd = qlch.CHITIETHOADONs.Where(d => d.MAHD == mahd && d.MASP == masp).FirstOrDefault();
            hd.MAHD = mahd;
            hd.MASP = masp;
            hd.SOLUONG = soluong;
            hd.THANHTIEN = thanhtien;
            qlch.SubmitChanges();
        }
        public void xoaChiTiet_HoaDon(string mahd, string masp)
        {
            CHITIETHOADON hd = qlch.CHITIETHOADONs.Where(d => d.MAHD == mahd && d.MASP == masp).FirstOrDefault();
            qlch.CHITIETHOADONs.DeleteOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public Boolean KiemTraTrung_CTHD(string mahd, string masp)
        {
            var cthd = qlch.CHITIETHOADONs.Where(n => (n.MAHD == mahd && n.MASP == masp)).FirstOrDefault();
            if (cthd != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
    }
}
