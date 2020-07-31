using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnPTPM
{
    public partial class frm_Main : Form
    {
        string t;
        //public Boolean ktdn;
        NhanVienBLL nv_bll = new NhanVienBLL();
        public frm_Main()
        {
            InitializeComponent();
        }
        public frm_Main(string tendn)
        {
            InitializeComponent();
            t = tendn;
            
        }

        public Boolean kiemTraDangNhap()
        {
            frmDangNhap frmdn = new frmDangNhap();
            return frmdn.dn ;
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy")
                    {
                        frm_QuanLyNV frmNV = new frm_QuanLyNV();
                        frmNV.MdiParent = this;
                        frmNV.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Sử Dụng Chức Năng Này", "Thông báo");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }

           
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NCC frm = new frm_NCC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_KhachHang frmkh = new frm_KhachHang();
            frmkh.MdiParent = this;
            frmkh.Show();
        }

        private void quảnLýLoạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LoaiHang frmlh = new frm_LoaiHang();
            frmlh.MdiParent = this;
            frmlh.Show();
        }
    }
}
