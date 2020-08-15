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
    public partial class frm_PhieuNhap : Form
    {
        string manv_dn="";
        PhieuNhap_BLL pn_bll = new PhieuNhap_BLL();
        NhaCungCap_BLL ncc_bll = new NhaCungCap_BLL();
        NhanVien_BLL nv_bll = new NhanVien_BLL();
        SanPham_BLL sp_bll = new SanPham_BLL();
        CT_PHIEUNHAP ctpn_bll = new CT_PHIEUNHAP();

        public frm_PhieuNhap()
        {
            InitializeComponent();
        }
        public frm_PhieuNhap(string manv)
        {
            InitializeComponent();
            manv_dn = manv;
        }
       

        private void frm_PhieuNhap_Load(object sender, EventArgs e)
        {
            Clear_PN();
            loadDataPN();
            txtMaNV.Text = manv_dn;
            SinhMaPNTuDong();
            loadNhaCungCap_cbo();
            dateNgayLap.Value = DateTime.Now;
            cboMaPN_CTPN.Enabled = false;
            cboMaSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDVT.Enabled = false;
            btnThanhToan.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLamMoi.Enabled = false;
            
        }
        private void loadDataPN()
        {
            gcPhieuNhap.DataSource = pn_bll.LoadPhieuNhap_BLL();
            // gvPhieuNhap.Columns["NHACUNGCAP"].Visible = false;
            // gvPhieuNhap.Columns["NHANVIEN"].Visible = false;
        }
        void SinhMaPNTuDong()
        {
            txtMaPN.Text = pn_bll.SinhMaPN();
        }

        void loadNhaCungCap_cbo()
        {
            cboMaNCC.DataSource = ncc_bll.LoadNCC_BLL();
            cboMaNCC.DisplayMember = "TENNCC";
            cboMaNCC.ValueMember = "MANCC";
            cboMaNCC.SelectedIndex = -1;
        }

        private void cboMaNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtMaDonDat.Focus();
                e.Handled = true;
            }
        }

        private void txtMaDonDat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaDonDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                dateNgayLap.Focus();
                e.Handled = true;
            }
        }

        private void frm_PhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtMaDonDat_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtMaDonDat.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        Boolean BatLoi_NgayLap_PN(DateTime ngay)
        {
            DateTime baygio = DateTime.Now;
            int kq = DateTime.Compare(baygio.Date, ngay.Date);
            if (kq == 0)
            {
                return true;
            }
            return false;

        }
        void ThucThi_TaoPN()
        {
            try
            {

                string mapn = txtMaPN.EditValue.ToString();
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Tạo Phiếu Nhập " + mapn + "?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {


                    if (txtMaPN.EditValue.ToString() != string.Empty && cboMaNCC.SelectedIndex != -1 && txtMaNV.EditValue.ToString() != string.Empty &&
               txtMaNV.EditValue.ToString() != string.Empty && txtMaDonDat.EditValue.ToString() != string.Empty)
                    {
                        string mancc;
                        string manv = txtMaNV.EditValue.ToString();
                        DateTime ngaylap = dateNgayLap.Value;
                        string madondat = txtMaDonDat.EditValue.ToString();
                        if (BatLoi_NgayLap_PN(ngaylap) == true)
                        {

                            // thêm 
                            if (pn_bll.KiemTraTrung_PN(mapn) == true)
                            {
                                mancc = cboMaNCC.SelectedValue.ToString();
                                pn_bll.ThemPhieuNhap(mapn, manv, mancc, madondat, ngaylap, 0);
                                MessageBox.Show("Tạo Thành Công Phiếu Nhập " + mapn, "Thông báo");
                                Clear_PN();
                            }
                            else
                            {
                                MessageBox.Show("Phiếu Nhập Đã Tồn Tại", "Thông báo");
                            }
                        }
                        else
                        {
                            dateNgayLap.ResetText();
                            dateNgayLap.Focus();
                            MessageBox.Show("Ngày Tạo Hóa Đơn Khác Với Ngày Hệ Thống", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có Thông Tin Chưa Được Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Tạo Phiếu Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        void Clear_PN()
        {
            cboMaNCC.DataSource = null;
            SinhMaPNTuDong();
            loadNhaCungCap_cbo();
            loadDataPN();
            dateNgayLap.Value = DateTime.Now;
            txtTongTien_PN.Clear();
            txtMaNV.EditValue = "";
            txtMaNV.EditValue = manv_dn;
            txtMaDonDat.EditValue = "";
        }

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            ThucThi_TaoPN();
            loadCboPN();
        }

        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            string mapn = "";
            if (gvPhieuNhap.RowCount != 0)
            {
               mapn = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "MAPN").ToString();
            }
           
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Phiếu Nhập " + mapn + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    //ThucThiXoa_CTHD();
                    pn_bll.xoaPhieuNhap(mapn);

                    loadDataPN();
                    MessageBox.Show("Xóa Thành Công Phiếu Nhập  " + mapn);
                    Clear_PN();
                }
            }
            catch
            {
                MessageBox.Show("Bạn Cần Phải Xóa Sản Phẩm Trong Phiếu Nhập " + mapn);
            }
        }

        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            string mapn = "";
            if (gvPhieuNhap.RowCount != 0)
            {
                 mapn = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "MAPN").ToString();
            }
            try
            {

                string manv = txtMaNV.EditValue.ToString();
                DateTime ngaylap = dateNgayLap.Value;
                string madondat = txtMaDonDat.EditValue.ToString();

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Phiếu Nhập  " + mapn + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (txtMaDonDat.Text != string.Empty)
                    {
                        pn_bll.suaPhieuNhap(mapn, madondat);
                        loadDataPN();
                        MessageBox.Show("Sửa Thành Công Phiếu Nhập " + mapn, "Thông Báo");
                        Clear_PN();
                    }
                    else
                    {
                        MessageBox.Show("Mã đơn đặt còn để trống " , "Thông Báo");
                    }
                   
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Phiếu Nhập " + mapn, "Thông Báo");
            }
        }

        private void btnLamMoiPN_Click(object sender, EventArgs e)
        {
            Clear_PN();
        }

        private void txtTongTien_PN_TextChanged(object sender, EventArgs e)
        {
            Boolean _fSetText = true;
            try
            {
                if (_fSetText)
                {
                    string strTemp = txtTongTien_PN.Text;
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
                    double flTienThuong = double.Parse(txtTongTien_PN.Text.Trim(','));
                    _fSetText = false;
                    txtTongTien_PN.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    txtTongTien_PN.Select(txtTongTien_PN.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void gvPhieuNhap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gvPhieuNhap.RowCount != 0)
            {
                txtMaPN.EditValue = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "MAPN").ToString();
                txtMaNV.EditValue = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "MANV").ToString();
                cboMaNCC.Text = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "MANCC").ToString();
                txtMaDonDat.EditValue = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "MADONDOAT").ToString();
                dateNgayLap.Text = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "NGAYLAP").ToString();
                txtTongTien_PN.Text = gvPhieuNhap.GetRowCellValue(gvPhieuNhap.FocusedRowHandle, "THANHTIEN").ToString();
            }
        }

        private void loadCboPN()
        {
            cboMaPN_CTPN.DataSource = ctpn_bll.LoadCbo_PN_BLL();
            cboMaPN_CTPN.DisplayMember = "MAPN";
            cboMaPN_CTPN.ValueMember = "MAPN";
            cboMaPN_CTPN.SelectedIndex = -1;
        }
        private void loadCboSP()
        {
            cboMaSP.DataSource = sp_bll.LoadSP_BLL();
            cboMaSP.DisplayMember = "TENHANG";
            cboMaSP.ValueMember = "MASP";
            cboMaSP.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;
            cboMaPN_CTPN.Enabled = true;
            cboMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDVT.Enabled = true;
            loadCboSP();
            loadCboPN();
            btnLuu.Enabled = true;
            btnLamMoi.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThucThiLuu_CTPN();
            Clear_CTPN();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string mapn = "";
            string masp ="";
            int soluong = 0;
            int slht = 0;
            if(gvCTPN.RowCount != 0)
            {
                 mapn = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "MACTPN").ToString();
                 masp = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "MASP").ToString();
                 soluong = int.Parse(gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "SOLUONG").ToString());
                   slht = Convert.ToInt32(sp_bll.GetSoLiuong(masp));
            }
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Chi Tiết Phiếu Nhập " + mapn + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {

                    ctpn_bll.xoaChiTiet_PhieuNhap(mapn, masp);

                    loadData_CTPN(mapn);
                    MessageBox.Show("Xóa Thành Công Chi Tiết Phiếu Nhập  " + mapn);
                    Clear_CTPN();
                    int soluong_hientai = slht - soluong;
                    sp_bll.updateSanPham_saukhiThemCTD(masp, soluong_hientai);
                    txtTongTien_CTPN.Text = Convert.ToString(laydata_thanhtien());
                    Clear_CTPN();
                }
            }
            catch
            {
                MessageBox.Show("Bạn Cần Phải Xóa Sản Phẩm Trong Phiếu Nhập " + mapn);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mapn="";
            if(gvCTPN.RowCount != 0)
            {
                 mapn = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "MACTPN").ToString();
            }
            try
            {
                string masp = cboMaSP.Text;
                int sl = int.Parse(txtSoLuong.Text);
                decimal thanhtien = decimal.Parse(txtThanhTien_CTPN.Text);
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Phiếu Nhập  " + mapn + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    ctpn_bll.suaChiTiet_PhieuNhap(mapn, masp, sl, thanhtien);
                    MessageBox.Show("Sửa Thành Công Chi Tiết Phiếu Nhập " + mapn, "Thông Báo");
                    loadData_CTPN(mapn);
                    txtTongTien_CTPN.Text = Convert.ToString(laydata_thanhtien());
                    Clear_CTPN();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Chi Tiết Phiếu Nhập " + mapn, "Thông Báo");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear_CTPN();
            gcCTPN.DataSource = null;
        }

        private void gvCTPN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gvCTPN.RowCount != 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                // btnThem.Enabled = false;
                cboMaPN_CTPN.Text = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "MACTPN").ToString();
                cboMaSP.Text = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "MASP").ToString();
                txtSoLuong.EditValue = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "SOLUONG").ToString();
                txtDonGia_CTPN.Text = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "DONGIA").ToString();
                txtDVT.EditValue = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "DONVITINH").ToString();
                txtThanhTien_CTPN.Text = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "THANHTIEN").ToString();
            }
            txtTongTien_CTPN.Text = Convert.ToString(laydata_thanhtien());
        }
        decimal laydata_thanhtien()
        {
            decimal tongthanhtien = 0;
            for (int i = 0; i < gvCTPN.RowCount; i++)
            {
                if (gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "THANHTIEN").ToString() != string.Empty)
                {
                    tongthanhtien = tongthanhtien + decimal.Parse(gvCTPN.GetRowCellValue(i, "THANHTIEN").ToString());
                }
            }
            return tongthanhtien;
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Bạn không được bỏ trống");
                txtSoLuong.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtDVT.Focus();
                e.Handled = true;
            }
        }

        private void cboMaPN_CTPN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                cboMaSP.Focus();
                e.Handled = true;
            }
        }

        private void cboMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                txtSoLuong.Focus();
                e.Handled = true;
            }
        }

        private void txtDVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtSoLuong.Focus();
                e.Handled = true;
            }
        }
        void ThucThiLuu_CTPN()
        {
            try
            {
                string mapn = "";
                if (cboMaPN_CTPN.SelectedIndex != -1)
                {
                    mapn = cboMaPN_CTPN.SelectedValue.ToString();
                }
                string masp = "";
                if (cboMaSP.SelectedIndex != -1)
                {
                    masp = cboMaSP.SelectedValue.ToString();
                }
                decimal gia = 0;
                if (txtDonGia_CTPN.Text != string.Empty)
                {
                    gia = Convert.ToDecimal(txtDonGia_CTPN.Text);
                }

                int soluong = int.Parse(txtSoLuong.Text);

                string dvt = "";
                if (txtDVT.Text == string.Empty)
                {
                    dvt = "Cái";
                }
                else
                {
                    dvt = txtDVT.Text;
                }
                decimal thanhtien = 0;
                if (txtThanhTien_CTPN.Text != string.Empty)
                {
                    thanhtien = decimal.Parse(txtThanhTien_CTPN.Text);
                }
                //int soluong_nhap = 0;
                //if (txtSoLuong.Text != string.Empty)
                //{
                //    soluong_nhap = int.Parse(txtSoLuong.Text);
                //}
                decimal dongia = 0;
                if (txtDonGia_CTPN.Text != string.Empty)
                {
                    dongia = Convert.ToDecimal(txtDonGia_CTPN.Text);
                }
                // kt xem có bị bỏ trống không
                if (mapn != string.Empty && cboMaPN_CTPN.SelectedIndex != -1 && masp != string.Empty &&
                    cboMaSP.SelectedIndex != -1 && txtSoLuong.Text != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Vào Chi Tiết Phiếu Nhập " + mapn + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm chi tiết hóa đơn
                        if (ctpn_bll.KiemTraTrung_CTPN(mapn, masp) == true)
                        {
                            ctpn_bll.ThemChiTiet_PhieuNhap(mapn, masp, soluong, gia, dongia, dvt, thanhtien);
                            MessageBox.Show("Thêm Thành Công Vào Chi Tiết Phiếu Nhập" + mapn, "Thông báo");
                            Clear_CTPN();
                            loadData_CTPN(mapn);
                            // update số lượng sản phẩm lại nè
                            int soluongtonkho = sp_bll.GetSoLiuong(masp);
                            int soluong_hientai = soluongtonkho + soluong;
                            sp_bll.updateSanPham_saukhiThemCTD(masp, soluong_hientai);
                            // update lại tổng tiền của hóa đơn
                            txtTongTien_CTPN.Text = Convert.ToString(laydata_thanhtien());
                        }
                        else
                        {
                            MessageBox.Show("Phiếu Nhập Đã Tồn Tại Sản Phẩm " + masp, "Thông báo");
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
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Vào Chi Tiết Phiếu Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Clear_CTPN()
        {
            //cboMaPN_CTPN.SelectedIndex = -1;
            cboMaSP.DataSource = null;
            txtDonGia_CTPN.Clear();
            txtSLTon.EditValue = "";
            txtSoLuong.EditValue = "";
            txtDVT.EditValue = "";
            txtThanhTien_CTPN.Clear();
            loadCboSP();
        }
        private void loadData_CTPN(string mahd)
        {
            // Clear_CTPN();
            gcCTPN.DataSource = ctpn_bll.LoadChiTiet_PN_BLL(mahd);

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string mapn = gvCTPN.GetRowCellValue(gvCTPN.FocusedRowHandle, "MACTPN").ToString();
                pn_bll.updateTongTienPhieuNhap_saukhiThemCTD(mapn, laydata_thanhtien());
                loadDataPN();
                MessageBox.Show("Đã Thanh Toán Thành Công " + mapn, "Thông Báo");
                Clear_CTPN();
            }
            catch
            {
                MessageBox.Show("Có Vấn Đè", "Thông báo");
            }
            
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedIndex != -1)
            {
                txtDonGia_CTPN.Text = Convert.ToString(sp_bll.GetDonGia(cboMaSP.SelectedValue.ToString()));
                txtSLTon.Text = Convert.ToString(sp_bll.GetSoLiuong(cboMaSP.SelectedValue.ToString()));
            }
        }

        private void txtDonGia_CTPN_TextChanged(object sender, EventArgs e)
        {
            Boolean _fSetText = true;
            try
            {
                if (_fSetText)
                {
                    string strTemp = txtDonGia_CTPN.Text;
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
                    double flTienThuong = double.Parse(txtDonGia_CTPN.Text.Trim(','));
                    _fSetText = false;
                    txtDonGia_CTPN.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    txtDonGia_CTPN.Select(txtDonGia_CTPN.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void cboMaPN_CTPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaPN_CTPN.SelectedIndex != -1)
            {
                loadData_CTPN(cboMaPN_CTPN.SelectedValue.ToString());
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != string.Empty)
            {
                if (txtDonGia_CTPN.Text != string.Empty)
                {
                    decimal thanhtien = decimal.Parse(txtDonGia_CTPN.Text) * int.Parse(txtSoLuong.Text);
                    txtThanhTien_CTPN.Text = Convert.ToString(thanhtien);
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtTongTien_CTPN_TextChanged(object sender, EventArgs e)
        {
            Boolean _fSetText = true;
            try
            {
                if (_fSetText)
                {
                    string strTemp = txtTongTien_CTPN.Text;
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
                    double flTienThuong = double.Parse(txtTongTien_CTPN.Text.Trim(','));
                    _fSetText = false;
                    txtTongTien_CTPN.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    txtTongTien_CTPN.Select(txtTongTien_CTPN.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void txtThanhTien_CTPN_TextChanged(object sender, EventArgs e)
        {
            Boolean _fSetText = true;
            try
            {
                if (_fSetText)
                {
                    string strTemp = txtThanhTien_CTPN.Text;
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
                    double flTienThuong = double.Parse(txtThanhTien_CTPN.Text.Trim(','));
                    _fSetText = false;
                    txtThanhTien_CTPN.Text = flTienThuong.ToString("0,00.##");
                }
                else
                {
                    _fSetText = true;
                    // Đưa con trỏ về cuối chuỗi.
                    txtThanhTien_CTPN.Select(txtThanhTien_CTPN.TextLength, 0);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
    }
}
