using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace DoAnMonPTPM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_DangNhap());
            //Application.Run(new frmMain());
         //Application.Run(new frm_NhanVien());
             //Application.Run(new frm_KhachHang());
            //Application.Run(new frm_LoaiHang());
            //Application.Run(new frm_SanPham());
            //Application.Run(new frm_PhieuNhap()); 
            // Application.Run(new frm_BaoHanh());
            //Application.Run(new frm_QLHoaDon());
            //Application.Run(new frm_ThongKe_HD());
            //Application.Run(new frm_HoaDon_CoNgay());
            //Application.Run(new frm_BaoCao_PN_TheoNgay());
            // Application.Run(new frm_NCC());
            //Application.Run(new frm_BaoCao_PN());
        }
    }
}
