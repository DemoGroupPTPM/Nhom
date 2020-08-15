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
    public partial class frm_LoaiHang : Form
    {
        NhomHang_BLL nhomhang_bll = new NhomHang_BLL();
        LoaiHang_BLL loaihang_bll = new LoaiHang_BLL();
        public frm_LoaiHang()
        {
            InitializeComponent();
        }
        void loadMaLoaiTuTao()
        {
            txtMaLoai.Text = loaihang_bll.SinhMaloai();
        }

        // load data grid view 
        void loadDataLoaiHang()
        {
            gcLoaiHang.DataSource = loaihang_bll.loadLoaiHang_BLL();
            // gvLoaiHang.Columns["NHOMHANG"].Visible = false;
        }
        void LoadMaNhomHang()
        {
            cboMaNhomHang.DataSource = nhomhang_bll.LoadNhomHang_BLL();
            cboMaNhomHang.ValueMember = "MANHOMHANG";
            cboMaNhomHang.DisplayMember = "TENNHOMHANG";
            cboMaNhomHang.SelectedIndex = -1;

        }
        public void clearText()
        {
            loadMaLoaiTuTao();
            txtTenLoaiHang.EditValue = "";

        }
        private void frm_LoaiHang_Load(object sender, EventArgs e)
        {
            cboMaNhomHang.Focus();
            LoadMaNhomHang();
            loadMaLoaiTuTao();
            loadDataLoaiHang();
            lammoi();
            txtMaLoai.Enabled = false;
        }

        private void txtTenLoaiHang_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenLoaiHang.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnThemLH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string maloai = txtMaLoai.Text;
                string manhomhang = cboMaNhomHang.SelectedValue.ToString();
                string tenloai = txtTenLoaiHang.Text;

                if (maloai != string.Empty && manhomhang != string.Empty && tenloai != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Loại hàng  " + maloai + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm nhân viên
                        if (loaihang_bll.KiemTraTrungMaLoaiHang(txtMaLoai.Text) == true)
                        {
                            loaihang_bll.ThemLoaiHang(maloai, manhomhang, tenloai);
                            MessageBox.Show("Thêm Thành Công loại hàng " + maloai, "Thông báo");
                            loadDataLoaiHang();
                            lammoi();
                            cboMaNhomHang.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Mã loại hàng Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    if (txtTenLoaiHang.Text == string.Empty)
                    {
                        MessageBox.Show("tên loại hàng còn bỏ trống", "Thống báo");
                        txtTenLoaiHang.Focus();
                    }


                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaLH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maloai = gvLoaiHang.GetRowCellValue(gvLoaiHang.FocusedRowHandle, "MALOAI").ToString();
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa loại hàng   " + maloai + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    loaihang_bll.xoaLoaiHang(maloai);
                    loadDataLoaiHang();
                    MessageBox.Show("Xóa Thành Công loại hàng " + maloai.ToString());

                    cboMaNhomHang.Focus();
                    lammoi();
                }
                clearText();
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa loại hàng  " + maloai);
            }
        }

        private void btnSuaLH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maloai = gvLoaiHang.GetRowCellValue(gvLoaiHang.FocusedRowHandle, "MALOAI").ToString();
            try
            {

                string manhomhang = cboMaNhomHang.SelectedValue.ToString();
                string tenloai = txtTenLoaiHang.Text;
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa loại hàng  " + maloai + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    loaihang_bll.SuaLoaiHang(maloai, manhomhang, tenloai);
                    loadDataLoaiHang();
                    MessageBox.Show("Sửa Thành Công loại hàng " + maloai, "Thông Báo");
                    lammoi();
                    txtTenLoaiHang.Focus();
                }
                clearText();
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa loại hàng " + maloai, "Thông Báo");
            }
        }
        void lammoi()
        {
            loadMaLoaiTuTao();
            txtTenLoaiHang.EditValue = "";
            cboMaNhomHang.DataSource = null;
            LoadMaNhomHang();
            cboMaNhomHang.Focus();
        }
        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lammoi();
        }

        private void frm_LoaiHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void gvLoaiHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        private void gvLoaiHang_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvLoaiHang.RowCount != 0)
            {
                txtMaLoai.Text = gvLoaiHang.GetRowCellValue(gvLoaiHang.FocusedRowHandle, "MALOAI").ToString();
                cboMaNhomHang.SelectedValue = gvLoaiHang.GetRowCellValue(gvLoaiHang.FocusedRowHandle, "MANHOMHANG").ToString();
                txtTenLoaiHang.Text = gvLoaiHang.GetRowCellValue(gvLoaiHang.FocusedRowHandle, "TENLOAI").ToString();
            }
        }
    }
}
