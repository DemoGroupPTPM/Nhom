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
    public partial class frm_HoaDon : Form
    {
        
        string manv_dn;
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        NhanVienBLL nv_bll = new NhanVienBLL();
        SanPham_BLL sp_bll = new SanPham_BLL();
        HoaDon_BLL hd_bll = new HoaDon_BLL();

        DateTime ngaylap;
        public frm_HoaDon()
        {
            InitializeComponent();
        }

        public frm_HoaDon(string manv)
        {
            InitializeComponent();
            manv_dn = manv;
        }
        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            loadKhachHang_cbo();
            //loadNhanVien_cbo();
            loadDataHD();
            SinhMaHDTuDong();
            cboMaHD.Enabled = false;
            cboMaSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGia.Enabled = false;
            txtDVT.Enabled = false;

            txtMaNV.Text = manv_dn;
            SinhMaHDTuDong();
            dateTimePicker1.Value = DateTime.Now;
            dataGridViewHoaDon.DefaultCellStyle.ForeColor = Color.Red;
        }

        private void loadDataHD()
        {
            dataGridViewHoaDon.DataSource = hd_bll.LoadHoaDon_BLL();
            dataGridViewHoaDon.Columns["KHACHHANG"].Visible = false;
            dataGridViewHoaDon.Columns["NHANVIEN"].Visible = false;
        }

        void loadKhachHang_cbo()
        {
            cboMaKH.DataSource = kh_bll.loadKhachHang_BLL();
            cboMaKH.DisplayMember = "TENKHACHHANG";
            cboMaKH.ValueMember = "MAKHACHHANG";
            cboMaKH.SelectedIndex = -1;
        }
        //void loadNhanVien_cbo()
        //{
        //    cboMaNV.DataSource = nv_bll.LoadNhanVien_BLL();
        //    cboMaNV.DisplayMember = "TENNV";
        //    cboMaNV.ValueMember = "MANV";
        //    cboMaNV.SelectedIndex = -1;
        //}

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            cboMaHD.Enabled = true;
            cboMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDVT.Enabled = true;
            loadCboHD();
            loadCboSP();
        }

        private void loadCboSP()
        {
            cboMaSP.DataSource = sp_bll.LoadSP_BLL();
            cboMaSP.DisplayMember = "TENHANG";
            cboMaSP.ValueMember = "MASP";
            cboMaSP.SelectedIndex = -1;
        }

        private void loadCboHD()
        {
            cboMaHD.DataSource = hd_bll.LoadHoaDon_BLL();
            cboMaHD.DisplayMember = "MAHD";
            cboMaHD.ValueMember = "MAHD";
            cboMaHD.SelectedIndex = -1;
        }

        void SinhMaHDTuDong()
        {
            txtMaHD.Text = hd_bll.SinhMaHD();
        }

        void Clear_HD()
        {
            SinhMaHDTuDong();
            loadKhachHang_cbo();
            loadDataHD();
            dateTimePicker1.Value = DateTime.Now;
            txtTongTien.Clear();
            txtMaNV.Clear();
            txtMaNV.Text = manv_dn;
        }

        void ThucThi_TaoHD()
        {
            try
            {
                string mahd = txtMaHD.Text;
                string makh;
                string manv = manv_dn;
                ngaylap = dateTimePicker1.Value;

                // kt xem textbox có bị bỏ trống không
                if (mahd != string.Empty && cboMaKH.SelectedIndex != -1 && manv != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Tạo Hóa Đơn " + mahd + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        if (BatLoi_NgayLap_HD(ngaylap) == true)
                        {
                            // thêm nhân viên
                            if (hd_bll.KiemTraTrung_HD(txtMaHD.Text) == true)
                            {
                                makh = cboMaKH.SelectedValue.ToString();
                                hd_bll.ThemHoaDon(mahd, makh, manv, ngaylap, 0);
                                MessageBox.Show("Tạo Thành Công Hóa Dơn " + mahd, "Thông báo");
                                Clear_HD();
                            }
                            else
                            {
                                MessageBox.Show("Hóa Đơn Đã Tồn Tại", "Thông báo");
                            }
                        }
                        else
                        {
                            dateTimePicker1.ResetText();
                            dateTimePicker1.Focus();
                            MessageBox.Show("Ngày Tạo Hóa Đơn Khác Với Ngày Hệ Thống", "Thông báo");
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

        private void toolStripThem_Click(object sender, EventArgs e)
        {
             ThucThi_TaoHD();
          
            //string a = hd_bll.SinhMaHD();
            //MessageBox.Show("day là mã sinh tự động" + a);
        }

        private void toolStripSua_Click(object sender, EventArgs e)
        {
            string mahd = dataGridViewHoaDon.CurrentRow.Cells[0].Value.ToString();
            try
            {
                string makh;
                string manv = manv_dn;
                DateTime ngaylap = dateTimePicker1.Value;

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  " + mahd + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    makh = cboMaKH.SelectedValue.ToString();
                    hd_bll.suaHoaDon(mahd,makh,ngaylap);
                    loadDataHD();
                    MessageBox.Show("Sửa Thành Công Hóa Đơn " + mahd, "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Hóa Đơn " + mahd, "Thông Báo");
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            string mahd = dataGridViewHoaDon.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Hóa Đơn  " + mahd + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    hd_bll.xoaHoaDon(mahd);
                    loadDataHD();
                    MessageBox.Show("Xóa Thành Công Hóa Đơn  " + mahd);
                    Clear_HD();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Hóa Đơn  " + mahd);
            }
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            Clear_HD();
        }

        private void frm_HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }          
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        Boolean BatLoi_NgayLap_HD(DateTime ngay)
        {
            DateTime baygio = dateTimePicker1.Value;
            int kq = DateTime.Compare(baygio, ngay);
            if(kq == 0)
            {
                return true;
            }
            return false;

        }

        private void cboMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucThi_TaoHD();
            }
            if (e.KeyData == Keys.Tab)
            {
                dateTimePicker1.Focus();
                e.Handled = true;
            }
        }

        private void dataGridViewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dataGridViewHoaDon.CurrentRow.Cells[0].Value.ToString();
            cboMaKH.Text = dataGridViewHoaDon.CurrentRow.Cells[1].Value.ToString();
            txtMaNV.Text = dataGridViewHoaDon.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text= dataGridViewHoaDon.CurrentRow.Cells[3].Value.ToString();
            txtTongTien.Text = dataGridViewHoaDon.CurrentRow.Cells[4].Value.ToString();
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
