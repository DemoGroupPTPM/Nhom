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

namespace DoAnMonPTPM
{
    public partial class frm_DangNhap : Form
    {
        NhanVien_BLL nvBLL = new NhanVien_BLL();
        public Boolean dn = true;
        public string tendn_khidn="";
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
           
        }

        void ThucThi_DangNhap()
        {
            try
            {

                if (txtTenTaiKhoan.Text != string.Empty && txtMatKhau.Text != string.Empty)
                {
                    string tendn = txtTenTaiKhoan.Text;
                    string matkhau = txtMatKhau.Text;
                    if (nvBLL.KiemTraMaNVTonTai(tendn) != null)
                    {
                        string matk = nvBLL.GetMkNV_BLL(tendn);
                        if (tendn == nvBLL.KiemTraMaNVTonTai(tendn) && matkhau == matk)
                        {
                            string luuTenDN = tendn;
                            MessageBox.Show("Đăng Nhập Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmMain main = new frmMain(luuTenDN);
                            main.Show();
                            this.Hide();
                            tendn_khidn = luuTenDN;
                            dn = true;
                            //frm_PhieuNhap n = new frm_PhieuNhap(luuTenDN);
                           // n.Show();
                        }
                        else
                        {
                            dn = false;
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        dn = false;
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dn = false;
                    MessageBox.Show("Có Thông Tin Còn Bỏ Trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                dn = false;
                MessageBox.Show("Có Vấn Đề Trong Việc Đăng Nhập", "Thông Báo");
            }

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ThucThi_DangNhap();
        }

        private void txtTenTaiKhoan_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Bạn không được bỏ trống");
                txtTenTaiKhoan.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Bạn không được bỏ trống");
                txtMatKhau.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucThi_DangNhap();
            }
        }

        private void txtTenTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtMatKhau.Focus();
            }
        }
    }
}
