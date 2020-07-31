using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
namespace DoAnPTPM
{
    public partial class frmDangNhap : Form
    {
        public Boolean dn = true ;
        NhanVienBLL nvBLL = new NhanVienBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        void ThucThi_DangNhap()
        {
            try
            {

                if (txtTaiKhoan.Text != string.Empty && txtMatKhau.Text != string.Empty)
                {
                    string tendn = txtTaiKhoan.Text;
                    if (nvBLL.KiemTraMaNVTonTai(tendn) != null)
                    {
                        string tk = nvBLL.GetTenDn_BLL(tendn);
                        string mk = nvBLL.GetMatKhau_BLL(tendn);
                        if (txtTaiKhoan.Text == tk && txtMatKhau.Text == mk)
                        {
                            string luuTenDN = tk;
                            MessageBox.Show("Đăng Nhập Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //frm_Main main = new frm_Main(luuTenDN);
                            //main.Show();
                            this.Hide();
                            // lấy trạng thái đăng nhập thành công
                            dn = true;

                            frm_HoaDon hd = new frm_HoaDon(luuTenDN);
                            hd.Show();

                        }
                        else
                        {
                            dn = false;
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //}
                    }
                    else
                    {
                        dn = false;
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (txtTaiKhoan.Text == String.Empty)
                    {
                        MessageBox.Show("Bạn còn bỏ trống tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTaiKhoan.Focus();
                    }
                    if (txtMatKhau.Text == String.Empty)
                    {
                        MessageBox.Show("Bạn còn bỏ trống mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Đăng Nhập", "Thông Báo");
            }

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ThucThi_DangNhap();
        }

       
        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Bạn không được bỏ trống");
                txtTaiKhoan.Focus();
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

        private void frmDangNhap_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucThi_DangNhap();
            }
        }
    }
}
