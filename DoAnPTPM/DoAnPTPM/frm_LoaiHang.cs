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
            dataLoaiHang.DataSource = loaihang_bll.loadLoaiHang_BLL();
            dataLoaiHang.Columns["NHOMHANG"].Visible = false;
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
            txtTenLoaiHang.Clear();
          
        }

        private void frm_LoaiHang_Load(object sender, EventArgs e)
        {
            txtTenLoaiHang.Focus();
            LoadMaNhomHang();
            loadMaLoaiTuTao();
            loadDataLoaiHang();
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

        private void toolStripThem_Click(object sender, EventArgs e)
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
                            clearText();
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

        private void toolStripSua_Click(object sender, EventArgs e)
        {
            string maloai = dataLoaiHang.CurrentRow.Cells[0].Value.ToString();
            try
            {

                string manhomhang = cboMaNhomHang.SelectedValue.ToString();
                string tenloai = txtTenLoaiHang.Text;
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa loại hàng  " + dataLoaiHang.CurrentRow.Cells[0].Value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    loaihang_bll.SuaLoaiHang(maloai, manhomhang, tenloai);
                    loadDataLoaiHang();
                    MessageBox.Show("Sửa Thành Công loại hàng " + maloai, "Thông Báo");
                    
                    txtTenLoaiHang.Focus();
                }
                clearText();
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa loại hàng " + dataLoaiHang.CurrentRow.Cells[0].Value.ToString(), "Thông Báo");
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            string maloai = dataLoaiHang.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa loại hàng   " + dataLoaiHang.CurrentRow.Cells[0].Value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    loaihang_bll.xoaLoaiHang(dataLoaiHang.CurrentRow.Cells[0].Value.ToString());
                    loadDataLoaiHang();
                    MessageBox.Show("Xóa Thành Công loại hàng " + maloai.ToString());
                 
                    cboMaNhomHang.Focus();
                }
                clearText();
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa loại hàng  " + maloai);
            }
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            loadMaLoaiTuTao();
            txtTenLoaiHang.Clear();
            cboMaNhomHang.SelectedIndex = -1;
          
           
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_LoaiHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void dataLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoai.Text = dataLoaiHang.CurrentRow.Cells[0].Value.ToString();
            cboMaNhomHang.SelectedValue = dataLoaiHang.CurrentRow.Cells[1].Value.ToString();
            txtTenLoaiHang.Text = dataLoaiHang.CurrentRow.Cells[2].Value.ToString();
        }

     
    }
}
