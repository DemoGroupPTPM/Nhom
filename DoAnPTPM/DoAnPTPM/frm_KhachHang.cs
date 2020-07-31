using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnPTPM
{
    public partial class frm_KhachHang : Form
    {
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        public frm_KhachHang()
        {
            InitializeComponent();
        }
        void loadMaKHTuTao()
        {
            txtMaKH_KH.Text = kh_bll.SinhMaKH();
        }

        // load data grid view 
        void loadDataKH()
        {
            dataKH.DataSource = kh_bll.loadKhachHang_BLL();
        }
       
        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            loadDataKH();
            loadMaKHTuTao();
        }

        private void frm_KhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void txtTenKH_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenKH.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private void txtEmailKH_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtDiaChiKH.Focus();
            }
            else if (isValidEmail(ctr.Text) == false)
            {
                errorProvider1.SetError(ctr, "Sai định dạng email");
                txtDiaChiKH.Focus();
            }
            else 
            {
                errorProvider1.Clear();
            }
        }

        private void txtSDTKH_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length != 10)
            {
                errorProvider1.SetError(ctr, "Số điện thoại chỉ gồm 10 số");
                txtSDTKH.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Số điện thoại chỉ có số");

            }
            else
                errorProvider1.Clear();
        }

        private void txtDiaChiKH_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtDiaChiKH.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có kí tự");
            }
            else
                errorProvider1.Clear();
        }

        private void dataKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH_KH.Text = dataKH.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dataKH.CurrentRow.Cells[1].Value.ToString();
            txtDiaChiKH.Text = dataKH.CurrentRow.Cells[2].Value.ToString();
            txtSDTKH.Text = dataKH.CurrentRow.Cells[3].Value.ToString();
            txtEmailKH.Text = dataKH.CurrentRow.Cells[4].Value.ToString();
        }

        private void toolStripThem_Click(object sender, EventArgs e)
        {
            try
            {
                string makh = txtMaKH_KH.Text;
                string tenkh = txtTenKH.Text;
                string diachi = txtDiaChiKH.Text;
                string dt = txtSDTKH.Text;

                string email = txtEmailKH.Text;
                if (email.Contains('@'))
                {
                    string[] t = email.Split('@');
                    t[0] = email;
                }

                

                if (makh != string.Empty && tenkh != string.Empty && dt != string.Empty &&  diachi != string.Empty && 
                    email != string.Empty )
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm khách hàng  " + makh + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm nhân viên
                        if (kh_bll.KiemTraTrungMaKH(txtMaKH_KH.Text) == true)
                        {
                            kh_bll.ThemKhachHang(makh, tenkh, diachi, dt, email);
                            MessageBox.Show("Thêm Thành Công khách hàng " + makh, "Thông báo");
                            loadDataKH();
                        }
                        else
                        {
                            MessageBox.Show("Mã khách hàng Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    if (txtDiaChiKH.Text == string.Empty)
                    {
                        MessageBox.Show("Địa chỉ còn bỏ trống", "Thống báo");
                        txtMaKH_KH.Focus();
                    }

                    if (txtTenKH.Text == string.Empty)
                    {
                        MessageBox.Show("Tên khách hàng còn bỏ trống", "Thống báo");
                        txtTenKH.Focus();
                    }
                    if (txtSDTKH.Text == string.Empty)
                    {
                        MessageBox.Show("Số điện thoại còn bỏ trống", "Thống báo");
                        txtSDTKH.Focus();
                    }
                    if (txtEmailKH.Text == string.Empty)
                    {
                        MessageBox.Show("email còn bỏ trống", "Thống báo");
                        txtEmailKH.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripSua_Click(object sender, EventArgs e)
        {
                string makh = dataKH.CurrentRow.Cells[0].Value.ToString();
                try
                {
                    string tenkh = txtTenKH.Text;
                    string diachi = txtDiaChiKH.Text;
                    string dt = txtSDTKH.Text;

                    string email = txtEmailKH.Text;


                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Sửa khách hàng " + dataKH.CurrentRow.Cells[0].Value.ToString() + " ?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        kh_bll.SuaKhachHang(makh, tenkh, diachi, dt, email);
                        loadDataKH();
                        MessageBox.Show("Sửa Thành Công khách hàng " + makh, "Thông Báo");
                    }
                }
                catch
                {
                    MessageBox.Show("Có Vấn Đề Trong Việc Sửa khách hàng " + makh, "Thông Báo");
                }
            }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {

            string makh = dataKH.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa khách hàng   " + dataKH.CurrentRow.Cells[0].Value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    kh_bll.xoaKhachHang(dataKH.CurrentRow.Cells[0].Value.ToString());
                    loadDataKH();
                    MessageBox.Show("Xóa Thành Công khách hàng  " + makh);
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa khách hàng " + makh);
            }
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            loadMaKHTuTao();
            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtDiaChiKH.Clear();
            txtEmailKH.Clear();
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
