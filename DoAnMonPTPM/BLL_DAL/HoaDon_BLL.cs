using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
   public class HoaDon_BLL
    {
        HOADONTableAdapter hd = new HOADONTableAdapter();
        QLCHDTDataContext qlch = new QLCHDTDataContext();

        public IQueryable<HOADON> LoadHoaDon_BLL()
        {
            return qlch.HOADONs.Select(h => h);
        }



        // kiểm tra trùng hd
        public Boolean KiemTraTrung_HD(string mahd)
        {
            var hd = qlch.HOADONs.Where(n => (n.MAHD == mahd)).FirstOrDefault();
            if (hd != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void ThemHoaDon(string mahd, string makhachhang, string manv,
            DateTime ngaylap, decimal thanhtien)
        {
            HOADON hd = new HOADON();
            hd.MAHD = mahd;
            hd.MAKHACHHANG = makhachhang;
            hd.MANV = manv;
            hd.NGAYLAPPHIEU = ngaylap;
            hd.TONGTIEN = thanhtien;
            qlch.HOADONs.InsertOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public void suaHoaDon(string mahd, string makhachhang, DateTime ngaylap)
        {
            HOADON hd = qlch.HOADONs.Where(d => d.MAHD == mahd).FirstOrDefault();
            hd.MAHD = mahd;
            hd.MAKHACHHANG = makhachhang;
            hd.NGAYLAPPHIEU = ngaylap;
            qlch.SubmitChanges();
        }

        // xóa nhân viên
        public void xoaHoaDon(string mahd)
        {
            HOADON hd = qlch.HOADONs.Where(d => d.MAHD == mahd).FirstOrDefault();
            qlch.HOADONs.DeleteOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public string SinhMaHD()
        {
            hd = new HOADONTableAdapter();
            string t;

            if (hd.GetSoMaHD() != null)
            {
                string somahd = "000" + hd.GetSoMaHD().ToString();
                somahd = somahd.Substring(somahd.Length - 4, 4);
                t = "HD" + somahd;
            }
            else
            {
                t = "HD0001";
            }

            return t;
        }

        public void updateTongTienHoaDon_saukhiThemCTD(string mahd, decimal tongtien)
        {
            HOADON hd = qlch.HOADONs.Where(d => d.MAHD == mahd).FirstOrDefault();
            hd.MAHD = mahd;
            hd.TONGTIEN = tongtien;
            qlch.SubmitChanges();
        }

    }
}
