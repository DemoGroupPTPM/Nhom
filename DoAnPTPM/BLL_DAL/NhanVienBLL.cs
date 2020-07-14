using BLL_DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NhanVienBLL
    {
        NHANVIENTableAdapter nvadapter;

        QLCHDataContext qlch = new QLCHDataContext();
        public NhanVienBLL() { }

        //lấy tài khoản
        public string GetTenDn_BLL(string manv)
        {
            nvadapter = new NHANVIENTableAdapter();
            return nvadapter.LayTenDN_MANV(manv) + string.Empty;
        }

        //lấy mật khẩu
        public string GetMatKhau_BLL(string manv)
        {
            nvadapter = new NHANVIENTableAdapter();
            return nvadapter.LayMatKhau_MaNV(manv) + string.Empty;
        }
        //lấy hết nv
        public DataTable GetCboMaNV_BLL()
        {
            nvadapter = new NHANVIENTableAdapter();
            return nvadapter.GetData();
        }


        // load data grid view 
        public IQueryable<NHANVIEN> LoadNhanVien_BLL()
        {
            return qlch.NHANVIENs.Select(k => k);
        }

       // thêm nhân  viên
        public void ThemNv(string manv, string tendn, string matkhau, string tennv,
            string diachi, string dienthoai,string maphanquyen, string chuthich)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = manv;
            nv.TENDN = tendn;
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
            if( nv != null )
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

    }
}
