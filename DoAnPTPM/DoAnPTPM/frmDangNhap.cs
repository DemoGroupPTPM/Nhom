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
        NhanVienBLL nvBLL = new NhanVienBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            LoadComBoBoxMaNV();
            cboMaNV.Focus();
        }

        void LoadComBoBoxMaNV()
        {
            cboMaNV.DataSource = nvBLL.GetCboMaNV_BLL();
            cboMaNV.ValueMember = "MANV";
            cboMaNV.DisplayMember = "MANV";
            cboMaNV.SelectedIndex = -1;
        }

       
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex != -1)
            {
                if (txtTaiKhoan.Text == String.Empty)
                {
                    MessageBox.Show("Bạn còn bỏ trống tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Focus();
                }
                 else if (txtMatKhau.Text == String.Empty)
                {
                    MessageBox.Show("Bạn còn bỏ trống mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Focus();
                }
                if (txtTaiKhoan.Text == String.Empty && txtMatKhau.Text == String.Empty)
                {
                    MessageBox.Show("Bạn còn bỏ trống tài khoản mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Focus();
                }
            }
            if ( txtTaiKhoan.Text != string.Empty && txtMatKhau.Text != string.Empty)
            {
                string tk = nvBLL.GetTenDn_BLL(cboMaNV.SelectedValue.ToString());
                string mk = nvBLL.GetMatKhau_BLL(cboMaNV.SelectedValue.ToString());
                if (txtTaiKhoan.Text == tk && txtMatKhau.Text == mk)
                {
                    MessageBox.Show("Đăng Nhập Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_Main main = new frm_Main();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        void kiemtraEmty()
        {
            if (cboMaNV.SelectedIndex != -1)
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
                if (txtTaiKhoan.Text == String.Empty && txtMatKhau.Text == String.Empty)
                {
                    MessageBox.Show("Bạn còn bỏ trống tài khoản mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Focus();
                }
            }
        }

        //private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult result;
        //    result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
        //        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        //    if (result == DialogResult.No)
        //        e.Cancel = true;
        //}

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
    }
}
