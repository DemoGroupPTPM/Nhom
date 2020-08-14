using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
  public  class KhachHang_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        KHACHHANGTableAdapter kh;
        public KhachHang_BLL() { }

        // truyền dữ liệu vào datagrid
        public IQueryable<KHACHHANG> loadKhachHang_BLL()
        {
            return qlch.KHACHHANGs.Select(k => k);
        }
        //thêm khách hàng
        public void ThemKhachHang(string makh, string tenkh, string diachi, string sdt, string email)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.MAKHACHHANG = makh;
            kh.TENKHACHHANG = tenkh;
            kh.DIACHI = diachi;
            kh.DIENTHOAI = sdt;
            kh.EMAIL = email;

            qlch.KHACHHANGs.InsertOnSubmit(kh);
            qlch.SubmitChanges();
        }

        //kiểm tra trùng ma khách hàng
        public Boolean KiemTraTrungMaKH(string makh)
        {
            var kh = qlch.KHACHHANGs.Where(d => (d.MAKHACHHANG == makh)).FirstOrDefault();
            if (kh != null)
            {
                return false;
            }
            return true;
        }
        // đếm số khách hàng để cập nhật lại mã khách hàng nếu cần thêm
        public string SinhMaKH()
        {
            kh = new KHACHHANGTableAdapter();
            string t;
            if (kh.GetSoMaKH() != null)
            {
                string somakh = "000" + kh.GetSoMaKH().ToString();
                somakh = somakh.Substring(somakh.Length - 4, 4);
                t = "KH" + somakh;
            }
            else
            {
                t = "KH0001";
            }
            return t;
        }
        // sửa khách hang
        public void SuaKhachHang(string makh, string tenkh, string diachi, string sdt, string email)
        {
            KHACHHANG kh = qlch.KHACHHANGs.Where(d => d.MAKHACHHANG == makh).FirstOrDefault();

            kh.MAKHACHHANG = makh;
            kh.TENKHACHHANG = tenkh;
            kh.DIACHI = diachi;
            kh.DIENTHOAI = sdt;
            kh.EMAIL = email;
            qlch.SubmitChanges();
        }

        //xóa khách hàng
        public void xoaKhachHang(string makh)
        {
            KHACHHANG kh = qlch.KHACHHANGs.Where(d => d.MAKHACHHANG == makh).FirstOrDefault();
            qlch.KHACHHANGs.DeleteOnSubmit(kh);
            qlch.SubmitChanges();
        }
    }
}
