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
    public partial class frm_NhanVien : Form
    {
        NhanVien_BLL nv_bll = new NhanVien_BLL();
        PhanQuyen_BLL pq_bll = new PhanQuyen_BLL();
        ChucNang_BLL cn_BLL = new ChucNang_BLL();
        public frm_NhanVien()
        {
            InitializeComponent();
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            loadDataNhanVien();
            loadCboPhanQuyen();
            loadMaNVTuTao();
            txtMaNV.Enabled = false;
            //lammoi();
            txtTenNV.Focus();
            txtMatKhau.EditValue = "";
            txtTenNV.EditValue = "";
            txtDiaChiNV.EditValue = "";
            txtDienThoai.EditValue = "";
            txtChuThich.EditValue = "";
        }// load mã nv
        void loadMaNVTuTao()
        {
            txtMaNV.Text = nv_bll.SinhMaNV();
        }

        // load data grid view 
        void loadDataNhanVien()
        {
            gcNhanVien.DataSource = nv_bll.LoadNhanVien_BLL();
        }

        // combobox phân quyền
        void loadCboPhanQuyen()
        {
            cboQuyen.DataSource = pq_bll.LoadcboPhanQuyen_BLL();
            cboQuyen.DisplayMember = "CHUTHICH";
            cboQuyen.ValueMember = "MAPHANQUYEN";
            cboQuyen.SelectedIndex = -1;

        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có số không kí tự");
            }
            else
                errorProvider1.Clear();
        }

        private void txtDienThoai_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length != 10)
            {
                errorProvider1.SetError(ctr, "Số điện thoại chỉ gồm 10 số");
                txtDienThoai.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void cboQuyen_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Phải cấp quyền cho nhân viên!");
                cboQuyen.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtMaNV.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtTenNV_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenNV.Focus();
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
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtMatKhau.Focus();
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

        private void btnThemNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string manv = txtMaNV.EditValue.ToString();
                string matkhau = txtMatKhau.EditValue.ToString();
                string tennv = txtTenNV.EditValue.ToString();
                string dt = txtDienThoai.EditValue.ToString();
                string maphanquyen;
                string chuthich;
                string diachi;

                if (txtDiaChiNV.EditValue.ToString() == string.Empty)
                {
                    diachi = "";
                }
                else
                {
                    diachi = txtDiaChiNV.EditValue.ToString();
                }

                if (txtChuThich.EditValue.ToString() == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich.EditValue.ToString();
                }



                // kt xem textbox có bị bỏ trống không
                if (manv != string.Empty && matkhau != string.Empty && tennv != string.Empty
                    && dt != string.Empty && cboQuyen.SelectedIndex != -1)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Nhân Viên  " + manv + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm nhân viên
                        if (nv_bll.KiemTraTrung_NV(txtMaNV.Text) == true)
                        {
                            maphanquyen = cboQuyen.SelectedValue.ToString();
                            nv_bll.ThemNv(manv, matkhau, tennv, diachi, dt, maphanquyen, chuthich);
                            MessageBox.Show("Thêm Thành Công Nhân Viên  " + manv, "Thông báo");
                            loadMaNVTuTao();
                            //txtTenNV.Clear();
                            //txtMatKhau.Clear();
                            //txtDiaChiNV.Clear();
                            //txtDienThoai.Clear();
                            // cboQuyen.DataSource = null;
                            loadDataNhanVien();
                            loadCboPhanQuyen();
                            listBoxChucNang.Enabled = false;
                            listBoxTenChucNang.Enabled = false;
                            //txtChuThich.Clear();
                            lammoi();

                        }
                        else
                        {
                            MessageBox.Show("Mã Nhân Viên Đã Tồn Tại", "Thông báo");
                            lammoi();
                        }
                    }
                }
                else
                {

                    if (txtMatKhau.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Mật khẩu còn bỏ trống", "Thống báo");
                        txtMatKhau.Focus();
                    }
                    if (txtTenNV.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tên nhân viên còn bỏ trống", "Thống báo");
                        txtTenNV.Focus();
                    }
                    if (txtDienThoai.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Số điện thoại còn bỏ trống", "Thống báo");
                        txtDienThoai.Focus();
                    }
                    if (cboQuyen.SelectedValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Phân quyền còn bỏ trống", "Thống báo");
                        cboQuyen.Focus();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnXoaNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvNhanVien.FocusedRowHandle;
            string ma = "MANV";
            object value = gvNhanVien.GetRowCellValue(id, ma);
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Nhân Viên  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    nv_bll.xoaNhanVien(value.ToString());
                    loadDataNhanVien();
                    MessageBox.Show("Xóa Thành Công Nhân Viên  " + value.ToString());
                    lammoi();

                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Nhân Viên  " + value.ToString());
            }
        }

        private void btnSuaNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = gvNhanVien.FocusedRowHandle;
            string ma = "MANV";
            object value = gvNhanVien.GetRowCellValue(id, ma);
            try
            {
                string matkhau = txtMatKhau.EditValue.ToString();
                string tennv = txtTenNV.EditValue.ToString();
                string dt = txtDienThoai.EditValue.ToString();
                string maphanquyen;
                string chuthich;
                string diachi;

                if (txtDiaChiNV.EditValue.ToString() == string.Empty)
                {
                    diachi = "";
                }
                else
                {
                    diachi = txtDiaChiNV.EditValue.ToString();
                }

                if (txtChuThich.EditValue.ToString() == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich.EditValue.ToString();
                }

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Nhân Viên  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    maphanquyen = cboQuyen.SelectedValue.ToString();
                    nv_bll.suaNhanVien(value.ToString(), matkhau, tennv, diachi, dt, maphanquyen, chuthich);
                    loadDataNhanVien();
                    MessageBox.Show("Sửa Thành Công Nhân Viên " + value.ToString(), "Thông Báo");
                    lammoi();

                }
        }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa Nhân Viên  " + value.ToString());
            }
}
        void lammoi()
        {
            loadMaNVTuTao();
            txtMatKhau.EditValue = "";
            txtTenNV.EditValue = "";
            txtDiaChiNV.EditValue = "";
            txtDienThoai.EditValue = "";
            cboQuyen.DataSource = null;
            listBoxChucNang.Enabled = false;
            listBoxTenChucNang.Enabled = false;
            txtChuThich.EditValue = "";
            loadCboPhanQuyen();
        }
        private void btnLamMoiNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            lammoi();
        }

        private void frm_NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void gvNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        private void listBoxChucNang_Click(object sender, EventArgs e)
        {
            string macn="";
            if (listBoxChucNang.Items.Count != 0)
            {
                macn = listBoxChucNang.SelectedValue.ToString();
                listBoxTenChucNang.DataSource = cn_BLL.LoadTenChucNang_BLL(macn);
                listBoxTenChucNang.DisplayMember = "TENCHUCNANG";
            }
        }

        private void gvNhanVien_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        private void gvNhanVien_FocusedRowChanged_2(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMaNV.EditValue = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "MANV").ToString();
            txtMatKhau.EditValue = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "MATKHAU").ToString();
            txtTenNV.EditValue = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "TENNV").ToString();
            txtDiaChiNV.EditValue = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "DIACHI").ToString();
            txtDienThoai.EditValue = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "DIENTHOAI").ToString();
            cboQuyen.SelectedValue = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "MAPHANQUYEN").ToString();
            if (listBoxChucNang.Items.Count != 0)
            {
                listBoxChucNang.DataSource = null;
                listBoxChucNang.Items.Clear();
            }
            if (listBoxTenChucNang.Items.Count != 0)
            {
                listBoxTenChucNang.DataSource = null;
                listBoxTenChucNang.Items.Clear();
            }
            if (gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "CHUTHICH") == null)
            {
                txtChuThich.EditValue = "";
            }
            else
            {
                txtChuThich.EditValue = gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, "CHUTHICH").ToString();
            }
        }

        private void cboQuyen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboQuyen.SelectedIndex != -1)
            {
                listBoxChucNang.DataSource = pq_bll.LoadChucNang_PhanQuyen_BLL(cboQuyen.SelectedValue.ToString());
                listBoxChucNang.DisplayMember = "MACHUCNANG";
                listBoxChucNang.ValueMember = "MACHUCNANG";
                //listBoxChucNang.DataSource = pq_bll.LoadChucNang_PhanQuyen_BLL(cboQuyen.SelectedValue.ToString());
                //listBoxChucNang.DisplayMember = "MACHUCNANG";
            }
        }
    }
}
