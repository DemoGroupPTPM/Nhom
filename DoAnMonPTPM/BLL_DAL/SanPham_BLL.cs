using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
   public class SanPham_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        SANPHAMTableAdapter sp;
        public SanPham_BLL() { }
        public IQueryable<SANPHAM> LoadSP_BLL()
        {
            return qlch.SANPHAMs.Select(sp => sp);
        }


        public Boolean KiemTraTrung_SP(string masp)
        {
            var sp = qlch.SANPHAMs.Where(n => (n.MASP == masp)).FirstOrDefault();
            if (sp != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void ThemSanPham(string masp, string maloai, string tenhang, string hinhanh, decimal dongia,
            int soluong, string baohanh, string mancc)
        {
            SANPHAM sp = new SANPHAM();
            sp.MASP = masp;
            sp.MALOAI = maloai;
            sp.MANCC = mancc;
            sp.TENHANG = tenhang;
            sp.HINHANH = hinhanh;
            sp.DONGIA = dongia;
            sp.SOLUONG = soluong;
            sp.BAOHANH = baohanh;

            qlch.SANPHAMs.InsertOnSubmit(sp);
            qlch.SubmitChanges();
        }

        public void suaSanPham(string masp, string maloai, string tenhang, string hinhanh, decimal dongia,
            int soluong, string baohanh, string mancc)
        {
            SANPHAM sp = qlch.SANPHAMs.Where(d => d.MASP == masp).FirstOrDefault();
            //diemsv.Diem1 = diem;
            sp.MALOAI = maloai;
            sp.MANCC = mancc;
            sp.TENHANG = tenhang;
            sp.HINHANH = hinhanh;
            sp.DONGIA = dongia;
            sp.SOLUONG = soluong;
            sp.BAOHANH = baohanh;
            qlch.SubmitChanges();
        }

        // xóa nhân viên
        public void xoaSanPham(string masp)
        {
            SANPHAM sp = qlch.SANPHAMs.Where(d => d.MASP == masp).FirstOrDefault();
            qlch.SANPHAMs.DeleteOnSubmit(sp);
            qlch.SubmitChanges();
        }

        public string SinhMaSP()
        {
            sp = new SANPHAMTableAdapter();
            string t;
            if (sp.GetSoMaSP() != null)
            {
                string somasp = "000" + sp.GetSoMaSP().ToString();
                somasp = somasp.Substring(somasp.Length - 4, 4);
                t = "SP" + somasp; ;
            }
            else
            {
                t = "SP0001";
            }

            return t;
        }

        public decimal GetDonGia(string masp)
        {
            var h = (from n in qlch.SANPHAMs where (n.MASP == masp) select n.DONGIA).FirstOrDefault();
            // var  h= qlch.SANPHAMs.Where(n => (n.MASP == masp)).Select(n => n.DONGIA).FirstOrDefault();
            decimal a = Convert.ToDecimal(h);
            return a;
        }

        public int GetSoLiuong(string masp)
        {
            var h = (from n in qlch.SANPHAMs where (n.MASP == masp) select n.SOLUONG).FirstOrDefault();
            int a = Convert.ToInt32(h);
            return a;
        }

        public void updateSanPham_saukhiThemCTD(string masp, int soluong)
        {
            SANPHAM sp = qlch.SANPHAMs.Where(d => d.MASP == masp).FirstOrDefault();
            sp.SOLUONG = soluong;
            qlch.SubmitChanges();
        }
    }
}
