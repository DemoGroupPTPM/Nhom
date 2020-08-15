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
    public partial class frm_SanPham : Form
    {
        SanPham_BLL sp_bll = new SanPham_BLL();

        LoaiHang_BLL lh_bll = new LoaiHang_BLL();
        NhaCungCap_BLL ncc_bll = new NhaCungCap_BLL();
        public frm_SanPham()
        {
            InitializeComponent();
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            loadSP();
            loadCboLoai();
            loadCboNCC();
            SinhMaTuDong();
            clear();
            txtMaSP.Enabled = false;
            cboMaLoai.Focus();
        }
        private void loadCboLoai()
        {
            cboMaLoai.DataSource = lh_bll.loadLoaiHang_BLL();
            cboMaLoai.DisplayMember = "TENLOAI";
            cboMaLoai.ValueMember = "MALOAI";
            cboMaLoai.SelectedIndex = -1;
        }

        private void loadCboNCC()
        {
            cboMaNCC_SP.DataSource = ncc_bll.LoadNCC_BLL();
            cboMaNCC_SP.DisplayMember = "TENNCC";
            cboMaNCC_SP.ValueMember = "MANCC";
            cboMaNCC_SP.SelectedIndex = -1;
        }

        void loadSP()
        {
            gcSanPham.DataSource = sp_bll.LoadSP_BLL();
            // gvSanPham.Columns["LOAIHANG"].Visible = false;
            //gvSanPham.Columns["NHACUNGCAP"].Visible = false;
        }
        void clear()
        {
            cboMaNCC_SP.DataSource = null;
            cboMaLoai.DataSource = null;
            txtTenSP.EditValue = " ";
            txtDonGiaSP.EditValue = " ";
            txtSL_SP.EditValue = " ";
            txtBaoHnah_SP.EditValue = "";
            imgHinh.EditValue = "";
            loadCboLoai();
            loadCboNCC();
            loadSP();
            SinhMaTuDong();
        }

        private void txtTenSP_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenSP.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDonGiaSP_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtDonGiaSP.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDonGiaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có số không kí tự");
                txtDonGiaSP.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void txtSL_SP_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtSL_SP.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSL_SP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có số không kí tự");
                txtSL_SP.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void txtBaoHnah_SP_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtBaoHnah_SP.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string masp = txtMaSP.EditValue.ToString();
                string maloai;
                string mancc;
                string tensp = txtTenSP.EditValue.ToString();
                decimal dongia = Convert.ToDecimal(txtDonGiaSP.EditValue.ToString());
                int soluong = int.Parse(txtSL_SP.EditValue.ToString());
                string baohanh = txtBaoHnah_SP.EditValue.ToString();
                string hinhanh;

                if (imgHinh.EditValue.ToString() == string.Empty)
                {
                    hinhanh = "";
                }
                else
                {
                    hinhanh = imgHinh.EditValue.ToString();
                }



                // kt xem textbox có bị bỏ trống không
                if (masp != string.Empty && cboMaLoai.SelectedIndex != -1 && cboMaNCC_SP.SelectedIndex != -1 && tensp != string.Empty
                && txtDonGiaSP.Text != null && txtSL_SP.Text != null && baohanh != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Sản Phẩm " + masp + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm nhân viên
                        if (sp_bll.KiemTraTrung_SP(txtMaSP.EditValue.ToString()) == true)
                        {
                            maloai = cboMaLoai.SelectedValue.ToString();
                            mancc = cboMaNCC_SP.SelectedValue.ToString();
                            sp_bll.ThemSanPham(masp, maloai, tensp, hinhanh, dongia, soluong, baohanh, mancc);
                            loadSP();
                            MessageBox.Show("Thêm Thành Công Sản Phẩm " + masp, "Thông báo");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Mã Nhân Viên Đã Tồn Tại", "Thông báo");

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Có Thông Tin Chưa Được Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Sản Phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvSanPham.FocusedRowHandle;
            string ma = "MASP";
            object value = gvSanPham.GetRowCellValue(id, ma);
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Sản Phẩm  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    sp_bll.xoaSanPham(value.ToString());
                    loadSP();
                    MessageBox.Show("Xóa Thành Công Sản Phẩm " + value.ToString());
                    clear();

                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Sản Phẩm  " + value.ToString());
                clear();
            }

        }

        private void btnSuaSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvSanPham.FocusedRowHandle;
            string ma = "MASP";
            object value = gvSanPham.GetRowCellValue(id, ma);
            try
            {
                string masp = txtMaSP.EditValue.ToString();
                string maloai;
                string mancc;
                string tensp = txtTenSP.EditValue.ToString();
                decimal dongia = Convert.ToDecimal(txtDonGiaSP.EditValue.ToString());
                int soluong = int.Parse(txtSL_SP.EditValue.ToString());
                string baohanh = txtBaoHnah_SP.EditValue.ToString();
                string hinhanh;

                if (imgHinh.EditValue.ToString() == string.Empty)
                {
                    hinhanh = "";
                }
                else
                {
                    hinhanh = imgHinh.EditValue.ToString();
                }


                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Sản phẩm  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    maloai = cboMaLoai.SelectedValue.ToString();
                    mancc = cboMaNCC_SP.SelectedValue.ToString();
                    sp_bll.suaSanPham(masp, maloai, tensp, hinhanh, dongia, soluong, baohanh, mancc);
                    loadSP();
                    MessageBox.Show("Sửa Thành Công Sản phẩm  " + value.ToString(), "Thông Báo");
                    clear();


                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa Sản phẩm  " + value.ToString());
            }
        }

        private void btnLamMoiSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clear();
        }

        private void btnDongSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frm_SanPham_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }
        //tạo mã sản phẩm 
        void SinhMaTuDong()
        {
            txtMaSP.EditValue = sp_bll.SinhMaSP();
        }

        private void txtBaoHnah_SP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                imgHinh.Focus();
                e.Handled = true;
            }
        }

        private void txtSL_SP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtBaoHnah_SP.Focus();
                e.Handled = true;
            }
        }

        private void txtTenSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtDonGiaSP.Focus();
                e.Handled = true;
            }
        }

        private void txtDonGiaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtSL_SP.Focus();
                e.Handled = true;
            }
        }

        private void cboMaNCC_SP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMaNCC_SP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtTenSP.Focus();
                e.Handled = true;
            }
        }

        private void cboMaLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                cboMaNCC_SP.Focus();
                e.Handled = true;
            }
        }

        private void gvSanPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        private void gvSanPham_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvSanPham.RowCount != 0)
            {
                txtMaSP.EditValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "MASP").ToString();
                cboMaLoai.SelectedValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "MALOAI").ToString();
                txtTenSP.EditValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "TENHANG").ToString();
                imgHinh.EditValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "HINHANH").ToString();
                txtDonGiaSP.EditValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "DONGIA").ToString();
                txtSL_SP.EditValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "SOLUONG").ToString();
                txtBaoHnah_SP.EditValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "BAOHANH").ToString();
                cboMaNCC_SP.SelectedValue = gvSanPham.GetRowCellValue(gvSanPham.FocusedRowHandle, "MANCC").ToString();
            }
        }
    }
}
