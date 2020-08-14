using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
  public  class NhaCungCap_BLL
    {
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        NHACUNGCAPTableAdapter ncc;
        public NhaCungCap_BLL()
        {

        }

        // load data grid view 
        public IQueryable<NHACUNGCAP> LoadNCC_BLL()
        {
            return qlch.NHACUNGCAPs.Select(k => k);
        }

        // thêm nhà cung cấp
        public void ThemNcc(string mancc, string tenncc,
            string diachi, string dienthoai, string chuthich)
        {
            NHACUNGCAP ncc = new NHACUNGCAP();
            ncc.MANCC = mancc;
            ncc.TENNCC = tenncc;
            ncc.DIACHI = diachi;
            ncc.DIENTHOAI = dienthoai;
            ncc.CHUTHICH = chuthich;


            qlch.NHACUNGCAPs.InsertOnSubmit(ncc);
            qlch.SubmitChanges();
        }
        //// kiểm tra trùng ncc
        public Boolean KiemTraTrung_NCC(string mancc)
        {
            var ncc = qlch.NHACUNGCAPs.Where(n => (n.MANCC == mancc)).FirstOrDefault();
            if (ncc != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        //// đếm số ncc để cập nhật lại mã ncc nếu cần thêm
        public string SinhMaNCC()
        {
            ncc = new NHACUNGCAPTableAdapter();
            string t;
            if (ncc.GetSoMaNCC() != null)
            {
                string somancc = "000" + ncc.GetSoMaNCC().ToString();
                somancc = somancc.Substring(somancc.Length - 4, 4);
                t = "NCC" + somancc;
            }
            else
            {
                t = "NCC0001";
            }

            return t;
        }

        //// sửa toàn bộ thông tin ncc , trừ mã ncc
        public void suaNCC(string mancc, string tenncc,
            string diachi, string dienthoai, string chuthich)
        {
            NHACUNGCAP ncc = qlch.NHACUNGCAPs.Where(d => d.MANCC == mancc).FirstOrDefault();

            ncc.TENNCC = tenncc;
            ncc.DIACHI = diachi;
            ncc.DIENTHOAI = dienthoai;
            ncc.CHUTHICH = chuthich;

            qlch.SubmitChanges();
        }

        //// xóa nhân viên
        public void xoaNCC(string mancc)
        {
            NHACUNGCAP ncc = qlch.NHACUNGCAPs.Where(d => d.MANCC == mancc).FirstOrDefault();
            qlch.NHACUNGCAPs.DeleteOnSubmit(ncc);
            qlch.SubmitChanges();
        }
    }
}
