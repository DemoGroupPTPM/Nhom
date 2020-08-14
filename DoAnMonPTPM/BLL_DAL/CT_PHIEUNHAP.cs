using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
   public class CT_PHIEUNHAP
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        public IQueryable LoadChiTiet_PN_BLL(string mapn)
        {
            var h = (from s in qlch.CHITIETPHIEUNHAPs
                     join l in qlch.SANPHAMs
                     on s.MASP
                     equals l.MASP
                     where s.MACTPN == mapn
                     select new
                     {
                         s.MACTPN,
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
        public IQueryable<PHIEUNHAP> LoadCbo_PN_BLL()
        {
            return qlch.PHIEUNHAPs.Select(h => h);
        }


        public void ThemChiTiet_PhieuNhap(string mapn, string masp,
           int soluong, decimal giagoc, decimal dongia, string dvt, decimal thanhtien)
        {
            CHITIETPHIEUNHAP hd = new CHITIETPHIEUNHAP();
            hd.MACTPN = mapn;
            hd.MASP = masp;
            hd.DONGIA = dongia;
            hd.SOLUONG = soluong;
            hd.DONVITINH = dvt;
            hd.THANHTIEN = thanhtien;
            qlch.CHITIETPHIEUNHAPs.InsertOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public void suaChiTiet_PhieuNhap(string mahd, string masp, int soluong, decimal thanhtien)
        {
            CHITIETPHIEUNHAP hd = qlch.CHITIETPHIEUNHAPs.Where(d => d.MACTPN == mahd && d.MASP == masp).FirstOrDefault();
            hd.MACTPN = mahd;
            hd.MASP = masp;
            hd.SOLUONG = soluong;
            hd.THANHTIEN = thanhtien;
            qlch.SubmitChanges();
        }
        public void xoaChiTiet_PhieuNhap(string mahd, string masp)
        {
            CHITIETPHIEUNHAP hd = qlch.CHITIETPHIEUNHAPs.Where(d => d.MACTPN == mahd && d.MASP == masp).FirstOrDefault();
            qlch.CHITIETPHIEUNHAPs.DeleteOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public Boolean KiemTraTrung_CTPN(string mahd, string masp)
        {
            var ctpn = qlch.CHITIETPHIEUNHAPs.Where(n => (n.MACTPN == mahd && n.MASP == masp)).FirstOrDefault();
            if (ctpn != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
    }
}
