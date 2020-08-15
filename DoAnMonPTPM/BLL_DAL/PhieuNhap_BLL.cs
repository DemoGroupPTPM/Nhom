using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
   public class PhieuNhap_BLL
    {
        PHIEUNHAPTableAdapter pn = new PHIEUNHAPTableAdapter();
        QLCHDTDataContext qlch = new QLCHDTDataContext();

        public IQueryable<PHIEUNHAP> LoadPhieuNhap_BLL()
        {
            return qlch.PHIEUNHAPs.Select(h => h);
        }



        // kiểm tra trùng hd
        public Boolean KiemTraTrung_PN(string mapn)
        {
            var pn = qlch.PHIEUNHAPs.Where(n => (n.MAPN == mapn)).FirstOrDefault();
            if (pn != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void ThemPhieuNhap(string mapn, string manv, string mancc, string madondat,
            DateTime ngaylap, decimal thanhtien)
        {
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.MAPN = mapn;
            pn.MANV = manv;
            pn.MANCC = mancc;
            pn.MADONDOAT = madondat;
            pn.NGAYLAP = ngaylap;
            pn.THANHTIEN = thanhtien;
            qlch.PHIEUNHAPs.InsertOnSubmit(pn);
            qlch.SubmitChanges();
        }

        public void suaPhieuNhap(string mapn,  string madondat)
        {
            PHIEUNHAP pn = qlch.PHIEUNHAPs.Where(d => d.MAPN == mapn).FirstOrDefault();
            pn.MAPN = mapn;
            pn.MADONDOAT = madondat;
            qlch.SubmitChanges();
        }

        // xóa nhân viên
        public void xoaPhieuNhap(string mapn)
        {
            PHIEUNHAP pn = qlch.PHIEUNHAPs.Where(d => d.MAPN == mapn).FirstOrDefault();
            qlch.PHIEUNHAPs.DeleteOnSubmit(pn);
            qlch.SubmitChanges();
        }

        public string SinhMaPN()
        {
            string t;
            if ( pn.GetSoMAPN() != null)
            {
                string somapn = "000" + pn.GetSoMAPN().ToString();
                somapn = somapn.Substring(somapn.Length - 4, 4);
                t = "PN" + somapn;
            }
            else
            {
                t = "PN0001";
            }
            return t;
        }

        public void updateTongTienPhieuNhap_saukhiThemCTD(string mapn, decimal thanhtien)
        {
            PHIEUNHAP pn = qlch.PHIEUNHAPs.Where(d => d.MAPN == mapn).FirstOrDefault();
            pn.MAPN = mapn;
            pn.THANHTIEN = thanhtien;
            qlch.SubmitChanges();
        }
    }
}
