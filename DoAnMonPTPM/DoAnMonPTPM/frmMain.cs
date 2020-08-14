using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoAnMonPTPM
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        string t;
        NhanVien_BLL nv_bll = new NhanVien_BLL();
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string tendn)
        {
            InitializeComponent();
            t = tendn;
        }

        public Boolean kiemTraDangNhap()
        {
            frm_DangNhap frmdn = new frm_DangNhap();
            return frmdn.dn;
        }
        private Form KiemtraTonTai(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DangNhap frmdn = new frm_DangNhap();
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.ShowInTaskbar)
                    frm.Close();
            }
            this.Hide();
            frmdn.Show();
        }

        private void btnQLNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if(nv_bll.LayQuyenNhanVien(t) == "PQQuanLy")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_NhanVien));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_NhanVien f = new frm_NhanVien();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }     
        }

        private void btnQLKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQBanHang"  
                        || nv_bll.LayQuyenNhanVien(t) == "PQThuNgan" )
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_KhachHang));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_KhachHang f = new frm_KhachHang();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
          
        }

        private void btnQLNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_NCC));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_NCC f = new frm_NCC();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
        }

        private void btnQLHH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQKho")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_SanPham));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_SanPham f = new frm_SanPham();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
        }

        private void btnQLLH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_LoaiHang));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_LoaiHang f = new frm_LoaiHang();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
          
        }

        private void btnHD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy"  || nv_bll.LayQuyenNhanVien(t) == "PQThuNgan")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_QLHoaDon));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_QLHoaDon f = new frm_QLHoaDon(t);
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }          
        }

        private void btnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQKho")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_PhieuNhap));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_PhieuNhap f = new frm_PhieuNhap(t);
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
           
        }

        private void btnBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQThuNgan")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_BaoHanh));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_BaoHanh f = new frm_BaoHanh(t);
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem_HD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQThuNgan"
                        || nv_bll.LayQuyenNhanVien(t) == "PQBanHang")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_BaoHanh));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_ThongKe_HD f = new frm_ThongKe_HD();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }

        }

        private void barButtonItem_HD_CoNgay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQThuNgan"
                        || nv_bll.LayQuyenNhanVien(t) == "PQBanHang")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_BaoHanh));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_HoaDon_CoNgay f = new frm_HoaDon_CoNgay();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }

        }

        private void barButtonItem_PN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQThuNgan"
                        || nv_bll.LayQuyenNhanVien(t) == "PQKho")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_BaoHanh));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_BaoCao_PN f = new frm_BaoCao_PN();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
        }

        private void barButtonItem_PN_CoNgay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (kiemTraDangNhap() == true)
                {
                    if (nv_bll.LayQuyenNhanVien(t) == "PQQuanLy" || nv_bll.LayQuyenNhanVien(t) == "PQThuNgan"
                        || nv_bll.LayQuyenNhanVien(t) == "PQKho")
                    {
                        Form frm = this.KiemtraTonTai(typeof(frm_BaoHanh));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frm_BaoCao_PN_TheoNgay f = new frm_BaoCao_PN_TheoNgay();
                            f.MdiParent = this;
                            f.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Không Có Quyền Truy Cập Vào ", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn Cần Đăng Nhập ", "Thông báo");
                    frm_DangNhap frmdn = new frm_DangNhap();
                    this.Hide();
                    frmdn.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
        }
    }
}
