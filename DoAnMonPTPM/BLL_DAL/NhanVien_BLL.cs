using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Data;
using System.Linq;

namespace BLL_DAL
{
    public class NhanVien_BLL
    {
        NHANVIENTableAdapter nvadapter;
        QLCHDTDataContext qlch = new QLCHDTDataContext();
        
        public NhanVien_BLL() { }
        //lấy tài khoản
        public string GetMkNV_BLL(string manv)
        {
            nvadapter = new NHANVIENTableAdapter();
            return nvadapter.LayMkNVDN(manv) ;
        }
        //lấy hết nv
        public DataTable GetCboMaNV_BLL()
        {
            nvadapter = new NHANVIENTableAdapter();
            return nvadapter.GetData();
        }

        // kiểm tra nhân viên tồn tại
        public string KiemTraMaNVTonTai(string manv)
        {
            nvadapter = new NHANVIENTableAdapter();
            return (string)nvadapter.KiemTraMaNV(manv);
        }

        // load data grid view 
        public IQueryable<NHANVIEN> LoadNhanVien_BLL()
        {
            return qlch.NHANVIENs.Select(k => k);
        }

        // thêm nhân  viên
        public void ThemNv(string manv, string matkhau, string tennv,
            string diachi, string dienthoai, string maphanquyen, string chuthich)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = manv;
            nv.MATKHAU = matkhau;
            nv.TENNV = tennv;
            nv.DIACHI = diachi;
            nv.DIENTHOAI = dienthoai;
            nv.MAPHANQUYEN = maphanquyen;
            nv.CHUTHICH = chuthich;

            qlch.NHANVIENs.InsertOnSubmit(nv);
            qlch.SubmitChanges();
        }

        // kiểm tra trùng nv
        public Boolean KiemTraTrung_NV(string manv)
        {
            var nv = qlch.NHANVIENs.Where(n => (n.MANV == manv)).FirstOrDefault();
            if (nv != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        //  cập nhật lại mã nhân viên nếu cần thêm
        public string SinhMaNV()
        {
            nvadapter = new NHANVIENTableAdapter();
            string t;
            if (nvadapter.GetSoMaNV()!= null)
            {
                string somanv = "000" + nvadapter.GetSoMaNV().ToString();
                somanv = somanv.Substring(somanv.Length - 4, 4);
                t = "NV" + somanv;
            }
            else
            {
                t = "NV0001";
            }
            return t;
        }

        // sửa toàn bộ thông tin nhân viên , trừ mã nhân viên
        public void suaNhanVien(string manv, string matkhau, string tennv,
            string diachi, string dienthoai, string maphanquyen, string chuthich)
        {
            NHANVIEN nv = qlch.NHANVIENs.Where(d => d.MANV == manv).FirstOrDefault();
            //diemsv.Diem1 = diem;
            nv.MATKHAU = matkhau;
            nv.TENNV = tennv;
            nv.DIACHI = diachi;
            nv.DIENTHOAI = dienthoai;
            nv.MAPHANQUYEN = maphanquyen;
            nv.CHUTHICH = chuthich;
            qlch.SubmitChanges();
        }

       //public void  XoaChucNangNV(string manv, string maphanquyen)
       // {
       //     CTPHANQUYEN ctpq = qlch.CTPHANQUYENs.Where(d => d.MAPHANQUYEN == maphanquyen).FirstOrDefault();
       //     var h = (from n in qlch.CTPHANQUYENs
       //              where (n.MAPHANQUYEN == maphanquyen)
       //              select n.MACHUCNANG).ToList();
       //     foreach(string n in h)
       //     {

       //     }
       //     qlch.CTPHANQUYENs.DeleteOnSubmit(h);
       // }

        // xóa nhân viên
        public void xoaNhanVien(string manv)
        {
            NHANVIEN nv = qlch.NHANVIENs.Where(d => d.MANV == manv).FirstOrDefault();
            qlch.NHANVIENs.DeleteOnSubmit(nv);
            qlch.SubmitChanges();
        }

        // lấy quyền của nhân viên dăng nhập
        public string LayQuyenNhanVien(string manv)
        {
            nvadapter = new NHANVIENTableAdapter();
            return (string)nvadapter.LayPhanQuyenNV(manv);
        }
    }
}
