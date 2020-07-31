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

namespace DoAnPTPM
{
    public partial class frm_SanPham : Form
    {
        SanPham_BLL sp_bll = new SanPham_BLL();
        LoaiHang_BLL lh_bll = new LoaiHang_BLL();
        NCC_BLL ncc_bll = new NCC_BLL();

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
        }

        private void loadCboLoai()
        {
            cboLoai.DataSource = lh_bll.loadLoaiHang_BLL();
            cboLoai.DisplayMember = "TENLOAI";
            cboLoai.ValueMember = "MALOAI";
            cboLoai.SelectedIndex = -1;
        }

        private void loadCboNCC()
        {
            cboNCC.DataSource = ncc_bll.LoadNCC_BLL();
            cboNCC.DisplayMember = "TENNCC";
            cboNCC.ValueMember = "MANCC";
            cboNCC.SelectedIndex = -1;
        }

        void loadSP()
        {
            dataSanPham.DataSource = sp_bll.LoadSP_BLL();
            dataSanPham.Columns["LOAIHANG"].Visible = false;
            dataSanPham.Columns["NHACUNGCAP"].Visible = false;
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

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có số không kí tự");
                txtDonGia.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void txtDonGia_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtDonGia.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSL_Leave(object sender, EventArgs e)
        {

            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtSL.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có số không kí tự");
                txtSL.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void txtBaoHanh_Leave(object sender, EventArgs e)
        {

            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtSL.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void toolStripThem_Click(object sender, EventArgs e)
        {
            try
            {
                string masp = txtMaSP.Text;
                string maloai ;
                string mancc ;
                string tensp = txtTenSP.Text;
                decimal dongia = Convert.ToDecimal(txtDonGia.Text);
                int  soluong = int.Parse(txtSL.Text);
                string baohanh = txtBaoHanh.Text;
                string hinhanh;

                if (txtHinhAnh.Text == string.Empty)
                {
                    hinhanh = "";
                }
                else
                {
                    hinhanh = txtHinhAnh.Text;
                }


            
            // kt xem textbox có bị bỏ trống không
            if (masp != string.Empty && cboLoai.SelectedIndex != -1 && cboNCC.SelectedIndex != -1 && tensp != string.Empty
                && txtDonGia.Text != null && txtSL.Text != null && baohanh != string.Empty)
            {
                DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Sản Phẩm " + masp + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm nhân viên
                        if (sp_bll.KiemTraTrung_SP(txtMaSP.Text) == true)
                        {
                            maloai = cboLoai.SelectedValue.ToString();
                            mancc = cboNCC.SelectedValue.ToString();
                            sp_bll.ThemSanPham(masp, maloai,tensp, hinhanh, dongia, soluong, baohanh , mancc);
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

        private void toolStripSua_Click(object sender, EventArgs e)
        {
            string masp = dataSanPham.CurrentRow.Cells[0].Value.ToString();
            try
            {

                string maloai;
                string mancc;
                string tensp = txtTenSP.Text;
                decimal dongia = Convert.ToDecimal( txtDonGia.Text);
                int soluong = int.Parse(txtSL.Text);
                string baohanh = txtBaoHanh.Text;
                string hinhanh;

                if (txtHinhAnh.Text == string.Empty)
                {
                    hinhanh = "";
                }
                else
                {
                    hinhanh = txtHinhAnh.Text;
                }

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Nhân Viên  " + masp + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                maloai = cboLoai.Text;
                mancc = cboNCC.Text;
                    sp_bll.suaSanPham(masp, maloai, tensp, hinhanh, dongia, soluong, baohanh, mancc);
                    loadSP();
                    MessageBox.Show("Sửa Thành Công Sản Phẩm " + masp, "Thông Báo");

                }
        }
        catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Nhân Viên " + masp, "Thông Báo");
            }
}

        private void dataSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dataSanPham.CurrentRow.Cells[0].Value.ToString();
            cboLoai.Text = dataSanPham.CurrentRow.Cells[1].Value.ToString();      
            txtTenSP.Text = dataSanPham.CurrentRow.Cells[2].Value.ToString();
            txtHinhAnh.Text = dataSanPham.CurrentRow.Cells[3].Value.ToString();
            txtDonGia.Text = dataSanPham.CurrentRow.Cells[4].Value.ToString();
            txtSL.Text = dataSanPham.CurrentRow.Cells[5].Value.ToString();
            txtBaoHanh.Text = dataSanPham.CurrentRow.Cells[6].Value.ToString();
            cboNCC.Text= dataSanPham.CurrentRow.Cells[7].Value.ToString();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {

            string masp = dataSanPham.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Nhân Viên  " + masp + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    sp_bll.xoaSanPham(masp);
                    loadSP();
                    MessageBox.Show("Xóa Thành Công Nhân Viên  " + masp);

                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Nhân Viên  " + masp);
            }
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            cboLoai.DataSource = null;
            cboNCC.DataSource = null;
            txtTenSP.Clear();
            txtDonGia.Clear();
            txtSL.Clear();
            txtBaoHanh.Clear();
            txtHinhAnh.Clear();
            loadCboLoai();
            loadCboNCC();
            loadSP();
            SinhMaTuDong();
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
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
            txtMaSP.Text = sp_bll.SinhMaSP();
        }

        private void cboLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                cboNCC.Focus();
                e.Handled = true;
            }
        }

        private void cboNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtTenSP.Focus();
                e.Handled = true;
            }
        }

        private void txtTenSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtDonGia.Focus();
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtSL.Focus();
                e.Handled = true;
            }
        }

        private void txtSL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtBaoHanh.Focus();
                e.Handled = true;
            }
        }

        private void txtBaoHanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtHinhAnh.Focus();
                e.Handled = true;
            }
        }
    }
}
