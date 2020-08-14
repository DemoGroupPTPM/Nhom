using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
   public class LoaiHang_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        LOAIHANGTableAdapter lh;
        public LoaiHang_BLL()
        { }

        // truyền dữ liệu vào datagrid
        public IQueryable<LOAIHANG> loadLoaiHang_BLL()
        {
            return qlch.LOAIHANGs.Select(k => k);
        }

        //thêm loại hàng
        public void ThemLoaiHang(string maloai, string manhomhang, string tenloai)
        {
            LOAIHANG l = new LOAIHANG();
            l.MALOAI = maloai;
            l.MANHOMHANG = manhomhang;
            l.TENLOAI = tenloai;

            qlch.LOAIHANGs.InsertOnSubmit(l);
            qlch.SubmitChanges();
        }

        //kiểm tra trùng ma khách hàng
        public Boolean KiemTraTrungMaLoaiHang(string maloai)
        {
            var l = qlch.LOAIHANGs.Where(d => (d.MALOAI == maloai)).FirstOrDefault();
            if (l != null)
            {
                return false;
            }
            return true;
        }
        // sắp xếp giảm dần, lấy cái đầu tiên - tương đương só lớn nhất-
        public string SinhMaloai()
        {
            lh = new LOAIHANGTableAdapter();
            string t;
            if (lh.GetSoMaLoai_LoaiHang() != null)
            {
                string somaloai = "000" + lh.GetSoMaLoai_LoaiHang().ToString();
                somaloai = somaloai.Substring(somaloai.Length - 4, 4);
                t = "Loai" + somaloai;
            }
            else
            {
                t = "Loai0001";
            }
            return t;
        }
        // sửa 
        public void SuaLoaiHang(string maloai, string manhomhang, string tenloai)
        {
            LOAIHANG l = qlch.LOAIHANGs.Where(d => d.MALOAI == maloai).FirstOrDefault();

            l.MALOAI = maloai;
            l.MANHOMHANG = manhomhang;
            l.TENLOAI = tenloai;

            qlch.SubmitChanges();
        }

        //xóa 
        public void xoaLoaiHang(string maloai)
        {
            LOAIHANG l = qlch.LOAIHANGs.Where(d => d.MALOAI == maloai).FirstOrDefault();
            qlch.LOAIHANGs.DeleteOnSubmit(l);
            qlch.SubmitChanges();
        }
    }
}
