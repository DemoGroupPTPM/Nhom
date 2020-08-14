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
    public partial class frm_QLHoaDon : Form
    {
        string manv_dn;
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        NhanVien_BLL nv_bll = new NhanVien_BLL();
        SanPham_BLL sp_bll = new SanPham_BLL();
        HoaDon_BLL hd_bll = new HoaDon_BLL();
        CT_HoaDon_BLL cthd_bll = new CT_HoaDon_BLL();
        public frm_QLHoaDon()
        {
            InitializeComponent();
        }
        public frm_QLHoaDon(string manv)
        {
            InitializeComponent();
            manv_dn = manv;
        }
        private void frm_QLHoaDon_Load(object sender, EventArgs e)
        {
            loadKhachHang_cbo();
            //loadNhanVien_cbo();
            loadDataHD();
            SinhMaHDTuDong();
            cboMaHD_CTHD.Enabled = false;
            cboMaSP_CTHD.Enabled = false;
            txtDonGia_CTHD.Enabled = false;
            txtSL_CTHD.Enabled = false;
            txtDonGia_CTHD.Enabled = false;
            txtDVTCTHD.Enabled = false;
            txtSLHientai.Enabled = false;
            txtMaNV_HD.Text = manv_dn;
            SinhMaHDTuDong();
            dateNgayLap.Value = DateTime.Now;
            Clear_HD();
            btnLamMoiCTHD.Enabled = false;
            btnThemCTHD.Enabled = true;
            btnLuu.Enabled = false;
            btnXoaCTHD.Enabled = false;
            btnSuaCTHD.Enabled = false;
            btnThanhToan.Enabled = false;

        }
        private void loadDataHD()
        {
            gcHoaDon.DataSource = hd_bll.LoadHoaDon_BLL();
        }

        void loadKhachHang_cbo()
        {
            cboMaKH_HD.DataSource = kh_bll.loadKhachHang_BLL();
            cboMaKH_HD.DisplayMember = "TENKHACHHANG";
            cboMaKH_HD.ValueMember = "MAKHACHHANG";
            cboMaKH_HD.SelectedIndex = -1;
        }



        private void loadCboSP()
        {
            cboMaSP_CTHD.DataSource = sp_bll.LoadSP_BLL();
            cboMaSP_CTHD.DisplayMember = "TENHANG";
            cboMaSP_CTHD.ValueMember = "MASP";
            cboMaSP_CTHD.SelectedIndex = -1;
        }

        private void loadCboHD()
        {
            cboMaHD_CTHD.DataSource = hd_bll.LoadHoaDon_BLL();
            cboMaHD_CTHD.DisplayMember = "MAHD";
            cboMaHD_CTHD.ValueMember = "MAHD";
            cboMaHD_CTHD.SelectedIndex = -1;
        }

        void SinhMaHDTuDong()
        {
            txtMaHD.EditValue = hd_bll.SinhMaHD();
        }

        void Clear_HD()
        {
            SinhMaHDTuDong();
            loadKhachHang_cbo();
            loadDataHD();
            dateNgayLap.Value = DateTime.Now;
            txtTongTien_HD.Text = "";
            cboMaKH_HD.SelectedValue = "";
            txtMaNV_HD.EditValue = manv_dn;
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frm_QLHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        Boolean BatLoi_NgayLap_HD(DateTime ngay)
        {
            DateTime baygio = DateTime.Now;
            int kq = DateTime.Compare(baygio.Date, ngay.Date);
            //TimeSpan dayyy = baygio - ngay;
            if (kq == 0)
            {
                return true;
            }
            return false;

        }
        void ThucThi_TaoHD()
        {
            try
            {
                string mahd = txtMaHD.EditValue.ToString();
                string makh;
                string manv = txtMaNV_HD.EditValue.ToString();
                DateTime ngaylap = dateNgayLap.Value;

                // kt xem textbox có bị bỏ trống không
                if (mahd != string.Empty && cboMaKH_HD.SelectedIndex != -1 && manv != string.Empty && txtMaNV_HD.EditValue.ToString() != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Tạo Hóa Đơn " + mahd + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        if (BatLoi_NgayLap_HD(ngaylap) == true)
                        {
                            // thêm nhân viên
                            if (hd_bll.KiemTraTrung_HD(txtMaHD.EditValue.ToString()) == true)
                            {
                                makh = cboMaKH_HD.SelectedValue.ToString();
                                hd_bll.ThemHoaDon(mahd, makh, manv, ngaylap, 0);
                                MessageBox.Show("Tạo Thành Công Hóa Dơn " + mahd, "Thông báo");
                                loadDataHD();
                                Clear_HD();
                            }
                            else
                            {
                                MessageBox.Show("Hóa Đơn Đã Tồn Tại", "Thông báo");
                            }
                        }
                        else
                        {
                            dateNgayLap.ResetText();
                            dateNgayLap.Focus();
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
                MessageBox.Show("Có Lỗi", "Thông báo");
            }
        }

        private void cboMaKH_HD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucThi_TaoHD();
            }
            if (e.KeyData == Keys.Tab)
            {
                dateNgayLap.Focus();
                e.Handled = true;
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            ThucThi_TaoHD();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            int id = gvHoaDon.FocusedRowHandle;
            string ma = "MAHD";
            object value = gvHoaDon.GetRowCellValue(id, ma);
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Hóa Đơn  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    //ThucThiXoa_CTHD();
                    hd_bll.xoaHoaDon(value.ToString());

                    loadDataHD();
                    MessageBox.Show("Xóa Thành Công Hóa Đơn  " + value.ToString());
                    Clear_HD();
                }
            }
            catch
            {
                MessageBox.Show("Bạn Cần Phải Xóa Sản Phẩm Trong Hóa Đơn " + value.ToString());
            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            int id = gvHoaDon.FocusedRowHandle;
            string ma = "MAHD";
            object value = gvHoaDon.GetRowCellValue(id, ma);
            try
            {
                string makh;
                string manv = manv_dn;
                DateTime ngaylap = dateNgayLap.Value;

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    makh = cboMaKH_HD.SelectedValue.ToString();
                    hd_bll.suaHoaDon(value.ToString(), makh, ngaylap);
                    loadDataHD();
                    MessageBox.Show("Sửa Thành Công Hóa Đơn " + value.ToString(), "Thông Báo");
                    Clear_HD();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Hóa Đơn " + value.ToString(), "Thông Báo");
            }
    
        }

        private void btnLamMoiHD_Click(object sender, EventArgs e)
        {
            Clear_HD();
        }

        private void gvHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gvHoaDon.RowCount != 0)
            {
                txtMaHD.EditValue = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHD").ToString();
                cboMaKH_HD.SelectedValue = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAKHACHHANG").ToString();
                txtMaNV_HD.EditValue = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MANV").ToString();
                dateNgayLap.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "NGAYLAPPHIEU").ToString();
                txtTongTien_HD.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "TONGTIEN").ToString();
            }
          
        }



        //cthd

        private void cboMaSP_CTHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP_CTHD.SelectedIndex != -1)
            {
                txtDonGia_CTHD.Text = Convert.ToString(sp_bll.GetDonGia(cboMaSP_CTHD.SelectedValue.ToString()));
                txtSLHientai.Text = Convert.ToString(sp_bll.GetSoLiuong(cboMaSP_CTHD.SelectedValue.ToString()));
                txtSL_CTHD.Text = "";
            }
        }

        private void txtSL_CTHD_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSL_CTHD.Text != string.Empty)
            {
                if (txtDonGia_CTHD.Text != string.Empty)
                {
                    decimal thanhtien = decimal.Parse(txtDonGia_CTHD.Text.ToString()) * int.Parse(txtSL_CTHD.EditValue.ToString());
                    txtThanhTien_CTHD.Text = Convert.ToString(thanhtien);
                }

            }
        }

        private void txtSL_CTHD_Leave(object sender, EventArgs e)
        {
            try
            {
                Control ctr = (Control)sender;
                if (txtSLHientai.Text != string.Empty)
                {
                    if (int.Parse(ctr.Text.ToString()) <= 0 ||
                        int.Parse(ctr.Text.ToString()) > int.Parse(txtSLHientai.EditValue.ToString()))
                    {
                        errorProvider1.SetError(ctr, "Nhập số lượng sai!");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }
                }
            }
            catch
            {

            }
           
        }

        private void txtSL_CTHD_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSLHientai_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSLHientai.Text != string.Empty)
            {
                if (int.Parse(txtSLHientai.EditValue.ToString()) == 0)
                {
                    txtSL_CTHD.Enabled = false;
                }
                else
                    txtSL_CTHD.Enabled = true;
            }
        }

        private void txtTongTien_CTHD_TextChanged(object sender, EventArgs e)
        {
            Boolean _fSetText = true;
            try
            {
                if (_fSetText)
                {
                    string strTemp = txtTongTien_CTHD.Text;
                    if (String.IsNullOrEmpty(strTemp)) return;
                    int iIndex = strTemp.IndexOf('.');
                    if (iIndex == -1)
                    {
                    }
                    else
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {
                        }
                    }
                    double flTienThuong = double.Parse(txtTongTien_CTHD.Text.Trim(','));
                    _fSetText = false;
                    txtTongTien_CTHD.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    txtTongTien_CTHD.Select(txtTongTien_CTHD.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
        private void loadData_CTHD(string mahd)
        {
            gcCTHD.DataSource = cthd_bll.LoadChiTiet_HD_BLL(mahd);
            //dataGVCTHD.Columns["SANPHAM"].Visible = false;
            //dataGVCTHD.Columns["HOADON"].Visible = false;
        }

        private void cboMaHD_CTHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaHD_CTHD.SelectedIndex != -1)
            {
                loadData_CTHD(cboMaHD_CTHD.SelectedValue.ToString());
            }
            txtTongTien_CTHD.Text = Convert.ToString(laydata_thanhtien());
        }
        void ThucThiLuu_CTHD()
        {
            try
            {
                string mahd = "";
                if (cboMaHD_CTHD.SelectedIndex != -1)
                {
                    mahd = cboMaHD_CTHD.SelectedValue.ToString();
                }
                string masp = "";
                if (cboMaSP_CTHD.SelectedIndex != -1)
                {
                    masp = cboMaSP_CTHD.SelectedValue.ToString();
                }
                decimal dongia = 0;
                if (txtDonGia_CTHD.Text != string.Empty)
                {
                    dongia = Convert.ToDecimal(txtDonGia_CTHD.Text);
                }
                int soluong = int.Parse(txtSL_CTHD.EditValue.ToString());
                string dvt = "";
                if (txtDVTCTHD.Text == string.Empty)
                {
                    dvt = "Cái";
                }
                else
                {
                    dvt = txtDVTCTHD.EditValue.ToString();
                }
                decimal thanhtien = 0;
                if (txtThanhTien_CTHD.Text != string.Empty)
                {
                    thanhtien = decimal.Parse(txtThanhTien_CTHD.Text);
                }
                int soluong_tonkho = 0;
                if (txtSLHientai.Text != string.Empty)
                {
                    soluong_tonkho = int.Parse(txtSLHientai.EditValue.ToString());
                }
                // kt xem có bị bỏ trống không
                if (mahd != string.Empty && cboMaHD_CTHD.SelectedIndex != -1 && masp != string.Empty &&
                    cboMaSP_CTHD.SelectedIndex != -1)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Vào Hóa Đơn " + mahd + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm chi tiết hóa đơn
                        if (cthd_bll.KiemTraTrung_CTHD(mahd, masp) == true)
                        {
                            if (soluong > 0 && soluong <= soluong_tonkho)
                            {
                                cthd_bll.ThemChiTiet_HoaDon(mahd, masp, dongia, soluong, dvt, thanhtien);
                                MessageBox.Show("Thêm Thành Công Vào Hóa Dơn " + mahd, "Thông báo");
                                Clear_CTHD();
                                loadData_CTHD(mahd);
                                // update số lượng sản phẩm lại nè
                                int soluong_hientai = soluong_tonkho - soluong;
                                sp_bll.updateSanPham_saukhiThemCTD(masp, soluong_hientai);
                                // update lại tổng tiền của hóa đơn
                            }
                            else
                            {
                                MessageBox.Show("Sai Sô Lượng " , "Thông báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hóa Đơn Đã Tồn Tại Sản Phẩm " + masp, "Thông báo");
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
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Vào Hóa Đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            cboMaHD_CTHD.Enabled = true;
            cboMaSP_CTHD.Enabled = true;
            txtSL_CTHD.Enabled = true;
            txtDVTCTHD.Enabled = true;
            loadCboHD();
            loadCboSP();
            btnLuu.Enabled = true;
            btnLamMoiCTHD.Enabled = true;
            btnThemCTHD.Enabled = false;
            btnThanhToan.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThucThiLuu_CTHD();
            txtThanhTien_CTHD.Text = Convert.ToString(laydata_thanhtien());
            Clear_CTHD();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                int id = gvCTHD.FocusedRowHandle;
                string ma = "MAHD";
                object value = gvCTHD.GetRowCellValue(id, ma);
                hd_bll.updateTongTienHoaDon_saukhiThemCTD(value.ToString(), laydata_thanhtien());
                loadDataHD();
                MessageBox.Show("Đã Thanh Toán Thành Công " + value.ToString(), "Thông Báo");
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề" , "Thông Báo");
            }
            
        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            string mahd = gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHD").ToString();
            string masp = gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MASP").ToString();
            int trucuasanpham = 0;
            int soluong_trongcthd = int.Parse(gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "SOLUONG").ToString());
            int soluongsanpham = Convert.ToInt32(sp_bll.GetSoLiuong(masp)); ;
            try
            {
                int soluong = int.Parse(txtSL_CTHD.EditValue.ToString());
                decimal thanhtien = 0;
                if (txtThanhTien_CTHD.Text != string.Empty)
                {
                    thanhtien = decimal.Parse(txtThanhTien_CTHD.Text);
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  " + mahd + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (txtSL_CTHD.Text != string.Empty)
                    {
                        cthd_bll.suaChiTiet_HoaDon(mahd, masp, soluong, thanhtien);
                        loadData_CTHD(mahd);
                        Clear_CTHD();
                        MessageBox.Show("Sửa Thành Công Hóa Đơn " + mahd + " Có Mã Sản Phẩm " + masp, "Thông Báo");

                        // update lại số lượng sản phẩm sau khi sửa
                        if (soluong != soluong_trongcthd)
                        {
                            if (soluong > soluong_trongcthd)
                            {
                                trucuasanpham = soluongsanpham - (soluong - soluong_trongcthd);
                                sp_bll.updateSanPham_saukhiThemCTD(masp, trucuasanpham);
                            }
                            else
                            {
                                trucuasanpham = soluongsanpham + (soluong_trongcthd - soluong);
                                sp_bll.updateSanPham_saukhiThemCTD(masp, trucuasanpham);
                            }
                        }
                        txtTongTien_CTHD.Text = Convert.ToString(laydata_thanhtien());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  ");
            }
        }


        decimal laydata_thanhtien()
        {
            decimal tongthanhtien = 0;
            for (int i = 0; i < gvCTHD.RowCount; i++)
            {
                if (gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "THANHTIEN").ToString() != string.Empty)
                {
                    
                    tongthanhtien = tongthanhtien + decimal.Parse(gvCTHD.GetRowCellValue(i, "THANHTIEN").ToString());
                }
            }
            return tongthanhtien;
        }

        void ThucThiXoa_CTHD()
        {
            int id;
            string ma = "";
            object value = "";
            string mahd = "";
            string masp="";
            int soluong = 0;
            if(gvCTHD.RowCount != 0)
            {
                 id = gvCTHD.FocusedRowHandle;
                 ma = "MAHD";
                 value = gvCTHD.GetRowCellValue(id, ma);

                mahd = gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHD").ToString();
                 masp = gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MASP").ToString();
                 soluong = int.Parse(gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "SOLUONG").ToString());
            }
            int slht = Convert.ToInt32(sp_bll.GetSoLiuong(masp));
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Hóa Đơn  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    cthd_bll.xoaChiTiet_HoaDon(value.ToString(), masp);
                    loadDataHD();
                    MessageBox.Show("Xóa Thành Công Hóa Đơn  " + value.ToString() + " Có Mã Sản Phẩm " + masp);
                    loadData_CTHD(value.ToString());
                    int soluong_hientai = slht + soluong;
                    sp_bll.updateSanPham_saukhiThemCTD(masp, soluong_hientai);
                    Clear_CTHD();
                    txtTongTien_CTHD.Text = Convert.ToString(laydata_thanhtien());
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Hóa Đơn  " + mahd);
            }
        }
        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            ThucThiXoa_CTHD();
        }
        void Clear_CTHD()
        {
            //cboMaHD.SelectedIndex = -1;
            cboMaSP_CTHD.DataSource = null;
            txtDonGia_CTHD.Text = "";
            txtSLHientai.EditValue = "";
            txtSL_CTHD.EditValue = "";
            txtDVTCTHD.EditValue = "";
            txtThanhTien_CTHD.Text = "";
            loadCboSP();
        }
        private void btnLamMoiCTHD_Click(object sender, EventArgs e)
        {
            cboMaHD_CTHD.SelectedIndex = -1;
            Clear_CTHD();
        }

        //private void gvCTHD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
          
        //}

        private void txtTongTien_HD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTongTien_HD.Text != string.Empty)
                {
                    string strTemp = txtDonGia_CTHD.Text;
                    if (String.IsNullOrEmpty(strTemp)) return;
                    int iIndex = strTemp.IndexOf('.');
                    if (iIndex == -1)
                    {
                    }
                    else
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {
                        }
                    }
                    double flTienThuong = double.Parse(txtTongTien_HD.Text.Trim(','));
                    txtTongTien_HD.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    // Đưa con trỏ về cuối chuỗi.
                    txtTongTien_HD.Select(txtTongTien_HD.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void txtDonGia_CTHD_TextChanged(object sender, EventArgs e)
        {
            Boolean _fSetText = true;
            try
            {
                if (_fSetText)
                {
                    string strTemp = txtDonGia_CTHD.Text;
                    if (String.IsNullOrEmpty(strTemp)) return;
                    int iIndex = strTemp.IndexOf('.');
                    if (iIndex == -1)
                    {
                    }
                    else
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {
                        }
                    }
                    double flTienThuong = double.Parse(txtDonGia_CTHD.Text.Trim(','));
                    _fSetText = false;
                    txtDonGia_CTHD.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    txtDonGia_CTHD.Select(txtDonGia_CTHD.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void txtThanhTien_CTHD_TextChanged(object sender, EventArgs e)
        {
            Boolean _fSetText = true;
            try
            {
                if (_fSetText)
                {
                    string strTemp = txtThanhTien_CTHD.Text;
                    if (String.IsNullOrEmpty(strTemp)) return;
                    int iIndex = strTemp.IndexOf('.');
                    if (iIndex == -1)
                    {
                    }
                    else
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {
                        }
                    }
                    double flTienThuong = double.Parse(txtThanhTien_CTHD.Text.Trim(','));
                    _fSetText = false;
                    txtThanhTien_CTHD.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    txtThanhTien_CTHD.Select(txtThanhTien_CTHD.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void gvCTHD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCTHD.RowCount != 0)
            {
                btnSuaCTHD.Enabled = true;
                btnXoaCTHD.Enabled = true;
                cboMaHD_CTHD.SelectedValue = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "MAHD").ToString();
                cboMaSP_CTHD.SelectedValue = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "MASP").ToString();
                txtDonGia_CTHD.Text = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "DONGIA").ToString();
                txtSL_CTHD.EditValue = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "SOLUONG").ToString();
                txtDVTCTHD.EditValue = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "DONVITINH").ToString();
                txtThanhTien_CTHD.Text = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "THANHTIEN").ToString();
                txtTongTien_CTHD.Text = Convert.ToString(laydata_thanhtien());
                btnSuaCTHD.Enabled = true;
                btnXoaCTHD.Enabled = true;
                txtSLHientai.EditValue = Convert.ToString(sp_bll.GetSoLiuong(gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MASP").ToString()));
            }
            txtSL_CTHD.Enabled = true;

        }
    }
}
