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
    public partial class frm_NCC : Form
    {
        NhaCungCap_BLL ncc_bll = new NhaCungCap_BLL();
        public frm_NCC()
        {
            InitializeComponent();
        }

        private void frm_NCC_Load(object sender, EventArgs e)
        {
            loadMaNCCTuTao();
            loadDataGridViewNCC();
            lammoi();
        } // load mã NCC tự tạo
        void loadMaNCCTuTao()
        {
            txtMaNCC.Text = ncc_bll.SinhMaNCC();
        }

        // load data grid view 
        void loadDataGridViewNCC()
        {
            gcNCC.DataSource = ncc_bll.LoadNCC_BLL();
        }

        private void btnThoatNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();

        }

        private void btnThemNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string mancc = txtMaNCC.EditValue.ToString();
                string tenncc = txtTenNCC.EditValue.ToString();
                string dt = txtSDTNCC.EditValue.ToString();
                string diachi = txtDiaChiNCC.EditValue.ToString();
                string chuthich;


                if (txtChuThich_NCC.EditValue.ToString() == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich_NCC.EditValue.ToString();
                }

                if (mancc != string.Empty && tenncc != string.Empty && dt != string.Empty && diachi != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Nhà Cung Cấp  " + mancc + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm nhân viên
                        if (ncc_bll.KiemTraTrung_NCC(txtMaNCC.EditValue.ToString()) == true)
                        {
                            ncc_bll.ThemNcc(mancc, tenncc, diachi, dt, chuthich);
                            MessageBox.Show("Thêm Thành Công Nhà Cung Cấp " + mancc, "Thông báo");
                            loadDataGridViewNCC();
                            loadMaNCCTuTao();
                            lammoi();
                        }
                        else
                        {
                            MessageBox.Show("Mã Nhà Cung Cấp Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    if (txtDiaChiNCC.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Địa chỉ còn bỏ trống", "Thống báo");
                        txtMaNCC.Focus();
                    }

                    if (txtTenNCC.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tên nhà cung cấp còn bỏ trống", "Thống báo");
                        txtTenNCC.Focus();
                    }
                    if (txtSDTNCC.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Số điện thoại còn bỏ trống", "Thống báo");
                        txtSDTNCC.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Nhà Cung Cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvNCC.FocusedRowHandle;
            string ma = "MANCC";
            object value = gvNCC.GetRowCellValue(id, ma);
            try
            {
                
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Nhà Cung Cấp  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    ncc_bll.xoaNCC(value.ToString());
                    loadDataGridViewNCC();
                    MessageBox.Show("Xóa Thành Công Nhà Cung Cấp  " + value.ToString());
                    lammoi();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Nhà Cung Cấp  " + value.ToString());
            }
        }

        private void btnSuaNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvNCC.FocusedRowHandle;
            string ma = "MANCC";
            object value = gvNCC.GetRowCellValue(id, ma);
            try
            {
                
                string tenncc = txtTenNCC.EditValue.ToString();
                string dt = txtSDTNCC.EditValue.ToString();
                string diachi = txtDiaChiNCC.EditValue.ToString();
                string chuthich;

                if (txtChuThich_NCC.EditValue.ToString() == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich_NCC.EditValue.ToString();
                }


                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa  Nhà Cung Cấp " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {



                    ncc_bll.suaNCC(value.ToString(), tenncc, diachi, dt, chuthich);
                    loadDataGridViewNCC();
                    lammoi();
                    MessageBox.Show("Sửa Thành Công Nhà Cung Cấp " + value.ToString(), "Thông Báo");


                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa  Nhà Cung Cấp  " + value.ToString());
            }
        }
        void lammoi()
        {
            loadMaNCCTuTao();
            txtTenNCC.EditValue = "";
            txtDiaChiNCC.EditValue = "";
            txtSDTNCC.EditValue = "";
            txtChuThich_NCC.EditValue = "";
        }
        private void btnLamMoiNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lammoi();
        }

        private void frm_NCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void gvNCC_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void txtDiaChiNCC_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(ctr, "Không được bỏ trống");
                txtDiaChiNCC.Focus();
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtSDTNCC_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length != 10)
            {
                dxErrorProvider1.SetError(ctr, "Số điện thoại chỉ gồm 10 số");
                txtSDTNCC.Focus();
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtTenNCC_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenNCC.Focus();
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtSDTNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                dxErrorProvider1.SetError(ctr, "Số điện thoại chỉ có số");
            }
            else
                dxErrorProvider1.ClearErrors();
        }

        private void gvNCC_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvNCC.RowCount != 0)
            {
                txtMaNCC.EditValue = gvNCC.GetRowCellValue(gvNCC.FocusedRowHandle, "MANCC").ToString();
                txtTenNCC.EditValue = gvNCC.GetRowCellValue(gvNCC.FocusedRowHandle, "TENNCC").ToString();
                txtDiaChiNCC.EditValue = gvNCC.GetRowCellValue(gvNCC.FocusedRowHandle, "DIACHI").ToString();
                txtSDTNCC.EditValue = gvNCC.GetRowCellValue(gvNCC.FocusedRowHandle, "DIENTHOAI").ToString();
                if (gvNCC.GetRowCellValue(gvNCC.FocusedRowHandle, "CHUTHICH") == null)
                {
                    txtChuThich_NCC.EditValue = "";
                }
                else
                {
                    txtChuThich_NCC.EditValue = gvNCC.GetRowCellValue(gvNCC.FocusedRowHandle, "CHUTHICH").ToString();
                }
            }
        }
    }
}
