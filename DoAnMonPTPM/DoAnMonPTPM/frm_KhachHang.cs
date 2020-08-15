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

namespace DoAnMonPTPM
{
    public partial class frm_KhachHang : Form
    {
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            loadDataKH();
            loadMaKHTuTao();
            lammoi();
        }
        void loadMaKHTuTao()
        {
            txtMaKH.Text = kh_bll.SinhMaKH();
        }

        // load data grid view 
        void loadDataKH()
        {
            gcKhachHang.DataSource = kh_bll.loadKhachHang_BLL();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();    
        }

        private void btnThemKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string makh = txtMaKH.EditValue.ToString();
                string tenkh = txtTenKH.EditValue.ToString();
                string diachi = txtDiaChiKH.EditValue.ToString();
                string dt = txtSDTKH.EditValue.ToString();

                string email = txtEmailKH.EditValue.ToString();
                //if (email.Contains('@'))
                //{
                //    string[] t = email.Split('@');
                //    t[0] = email;
                //}

                // kt xem textbox có bị bỏ trống không
                if (makh != string.Empty && tenkh != string.Empty && dt != string.Empty && diachi != string.Empty &&
                     email != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm khách hàng  " + makh + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm 
                        if (kh_bll.KiemTraTrungMaKH(txtMaKH.EditValue.ToString()) == true)
                        {
                            kh_bll.ThemKhachHang(makh, tenkh, diachi, dt, email);
                            MessageBox.Show("Thêm Thành Công khách hàng " + makh, "Thông báo");
                            loadDataKH();
                            lammoi();
                        }
                        else
                        {
                            MessageBox.Show("Mã khách hàng Đã Tồn Tại", "Thông báo");

                        }
                    }
                }
                else
                {

                    if (txtDiaChiKH.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Địa chỉ còn bỏ trống", "Thống báo");
                        txtDiaChiKH.Focus();
                    }

                    if (txtTenKH.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tên khách hàng còn bỏ trống", "Thống báo");
                        txtTenKH.Focus();
                    }
                    if (txtSDTKH.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Số điện thoại còn bỏ trống", "Thống báo");
                        txtSDTKH.Focus();
                    }
                    if (txtEmailKH.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("email còn bỏ trống", "Thống báo");
                        txtEmailKH.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvKhachHang.FocusedRowHandle;
            string ma = "MAKHACHHANG";
            object value = gvKhachHang.GetRowCellValue(id, ma);
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Khách hàng  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    kh_bll.xoaKhachHang(value.ToString());
                    loadDataKH();
                    MessageBox.Show("Xóa Thành Công Khách hàng " + value.ToString());
                    lammoi();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Khách hàng " + value.ToString());
            }
        }

        private void btnSuaKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvKhachHang.FocusedRowHandle;
            string ma = "MAKHACHHANG";
            object value = gvKhachHang.GetRowCellValue(id, ma);
            try
            {
                string tenkh = txtTenKH.EditValue.ToString();
                string diachi = txtDiaChiKH.EditValue.ToString();
                string dt = txtSDTKH.EditValue.ToString();

                string email = txtEmailKH.EditValue.ToString();

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Khách hàng " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {

                    kh_bll.SuaKhachHang(value.ToString(), tenkh, diachi, dt, email);
                    loadDataKH();
                    MessageBox.Show("Sửa Thành Công khách hàng " + value.ToString(), "Thông Báo");
                    lammoi();

                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa khách hàng  " + value.ToString());
            }
        }
        void lammoi()
        {
            loadMaKHTuTao();
            txtMaKH.Enabled = false;
            txtTenKH.EditValue = "";
            txtDiaChiKH.EditValue = "";
            txtSDTKH.EditValue = "";
            txtEmailKH.EditValue = "";

        }
        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lammoi();
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
     
        private void gvKhachHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
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

        private void gvKhachHang_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (gvKhachHang.RowCount != 0)
            {
                txtMaKH.EditValue = gvKhachHang.GetRowCellValue(gvKhachHang.FocusedRowHandle, "MAKHACHHANG").ToString();
                txtTenKH.EditValue = gvKhachHang.GetRowCellValue(gvKhachHang.FocusedRowHandle, "TENKHACHHANG").ToString();
                txtDiaChiKH.EditValue = gvKhachHang.GetRowCellValue(gvKhachHang.FocusedRowHandle, "DIACHI").ToString();
                txtSDTKH.EditValue = gvKhachHang.GetRowCellValue(gvKhachHang.FocusedRowHandle, "DIENTHOAI").ToString();
                txtEmailKH.EditValue = gvKhachHang.GetRowCellValue(gvKhachHang.FocusedRowHandle, "EMAIL").ToString();
            }
        }
    }
}
