using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnPTPM
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
            //Application.Run(new frmDangNhap());
            //Application.Run(new frm_QuanLyNV());
            //Application.Run(new frm_NCC());
            //Application.Run(new frm_KhachHang());
            //Application.Run(new frm_LoaiHang());
            //Application.Run(new frm_SanPham());
            Application.Run(new frm_HoaDon());
        }
    }
}
