using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
 public   class BaoHanh_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        BAOHANHTableAdapter bh = new BAOHANHTableAdapter();
        public BaoHanh_BLL() { }

        public IQueryable<KHACHHANG> loadKhachHang_BLL()
        {
            return qlch.KHACHHANGs.Select(k => k);
        }

        public IQueryable<SANPHAM> loadSanPham_BLL()
        {
            return qlch.SANPHAMs.Select(k => k);
        }

        public IQueryable<BAOHANH> loaddata_BaoHanh()
        {
            return qlch.BAOHANHs.Select(k => k);
        }

        public string SinhMa_BH()
        {
 
            string t="";
            if (bh.GetSoMaBH() != null)
                {
                    string somabh = "000" + bh.GetSoMaBH().ToString();
                    somabh = somabh.Substring(somabh.Length - 4, 4);
                    t = "BH" + somabh;
                }
                else
                {
                    t = "BH0001";
                }

            return t;
        }

        public Boolean KiemTraTrungMaBH(string mabh)
        {
            var bh = qlch.BAOHANHs.Where(d => (d.MABAOHANH == mabh)).FirstOrDefault();
            if (bh != null)
            {
                return false;
            }
            return true;
        }

        public void TaoPhieuBaoHanh(string mabh, string makh, string maps, string manv, string yeucau,
            DateTime ngaynhan, DateTime ngaytra, string tinhtrang)
        {
            BAOHANH bh = new BAOHANH();
            bh.MABAOHANH = mabh;
            bh.MAKHACHHANG = makh;
            bh.MASP = maps;
            bh.MANV = manv;
            bh.YEUCAUBAOHANH = yeucau;
            bh.NGAYNHAN = ngaynhan;
            bh.NGAYTRA = ngaytra;
            bh.TINHTRANG = tinhtrang;

            qlch.BAOHANHs.InsertOnSubmit(bh);
            qlch.SubmitChanges();
        }

        public void SuaPhieuBaoHanh(string mabh, string yeucau, DateTime ngaytra, string tinhtrang)
        {
            BAOHANH bh = qlch.BAOHANHs.Where(d => d.MABAOHANH == mabh).FirstOrDefault();

            bh.MABAOHANH = mabh;
            bh.YEUCAUBAOHANH = yeucau;
            bh.NGAYTRA = ngaytra;
            bh.TINHTRANG = tinhtrang;
            qlch.SubmitChanges();
        }

        //xóa khách hàng
        public void xoaPhieuBaoHanh(string mabh)
        {
            BAOHANH bh = qlch.BAOHANHs.Where(d => d.MABAOHANH == mabh).FirstOrDefault();

            qlch.BAOHANHs.DeleteOnSubmit(bh);
            qlch.SubmitChanges();
        }
    }
}
