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
    public partial class frm_BaoHanh : Form
    {
        string manv_dn;
        KhachHang_BLL kh_bll = new KhachHang_BLL();
        NhanVien_BLL nv_bll = new NhanVien_BLL();
        SanPham_BLL sp_bll = new SanPham_BLL();
        BaoHanh_BLL bh_bll = new BaoHanh_BLL();
        public frm_BaoHanh()
        {
            InitializeComponent();
        }
        public frm_BaoHanh(string manv)
        {
            InitializeComponent();
            manv_dn = manv;
        }
        private void frm_BaoHanh_Load(object sender, EventArgs e)
        {
            loadMaKH();
            loadMaSP();
            loadTinhTrang();
            loadDataBaoHanh();
            sinhma();
            txtMaNV_BH.EditValue = manv_dn;
            dateNgayNhan_BH.Value = DateTime.Now;
            dateNgayTra_BH.Value = DateTime.Now.AddDays(7);
            clear();
        }
        void loadMaKH()
        {
            cboMaKH_BH.DataSource = bh_bll.loadKhachHang_BLL();
            cboMaKH_BH.DisplayMember = "TENKHACHHANG";
            cboMaKH_BH.ValueMember = "MAKHACHHANG";
            cboMaKH_BH.SelectedIndex = -1;
        }
        void loadMaSP()
        {
            cboMaSP_BH.DataSource = bh_bll.loadSanPham_BLL();
            cboMaSP_BH.DisplayMember = "TENHANG";
            cboMaSP_BH.ValueMember = "MASP";
            cboMaSP_BH.SelectedIndex = -1;
        }

        void loadTinhTrang()
        {
            cboTinhTrang_BH.Items.Add("Tiếp Nhận");
            cboTinhTrang_BH.Items.Add("Đang Tiến Hành");
            cboTinhTrang_BH.Items.Add("Đã Trả Bảo Hành");
            cboTinhTrang_BH.SelectedIndex = -1;
        }

        void loadDataBaoHanh()
        {
            gcBaoHanh.DataSource = bh_bll.loaddata_BaoHanh();
            // gvBaoHanh.Columns["SANPHAM"].Visible = false;
            //  gvBaoHanh.Columns["KHACHHANG"].Visible = false;
            // gvBaoHanh.Columns["NHANVIEN"].Visible = false;
        }

        void sinhma()
        {
                txtMaBH.Text = bh_bll.SinhMa_BH();
        }
        Boolean BatLoi_NgayLap_PhieuBH(DateTime ngay)
        {
            DateTime baygio = DateTime.Now;
            int kq = DateTime.Compare(baygio.Date, ngay.Date);
            if (kq == 0)
            {
                return true;
            }
            return false;

        }

        Boolean BatLoi_NgayTra_PhieuBH(DateTime ngaynhan, DateTime ngay)
        {
            //DateTime ngaynhan = dateNgayNhan_BH.Value;
            int kq = DateTime.Compare(ngay.Date, ngaynhan.Date);
            if (kq == 0 || kq == 1)
            {
                return true;
            }
            return false;

        }
        void clear()
        {
            sinhma();
            cboMaKH_BH.DataSource = null;
            cboMaKH_BH.DataSource = null;
            txtYeuCau.EditValue = "";
            cboTinhTrang_BH.Items.Clear();
            loadMaKH();
            loadMaSP();
            loadDataBaoHanh();
            loadTinhTrang();
            txtMaNV_BH.EditValue = manv_dn;
            dateNgayTra_BH.Value = DateTime.Now.AddDays(7);
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnThemBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                string mabh = txtMaBH.Text;
                string makh;
                string masp;
                string manv = txtMaNV_BH.Text;
                string yeucau = txtYeuCau.Text;
                string tinhtrang = cboTinhTrang_BH.Text;
                DateTime ngaynhan = dateNgayNhan_BH.Value;
                DateTime ngaytra = dateNgayTra_BH.Value;

                // kt xem textbox có bị bỏ trống không

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Tạo Phiếu Bảo Hành " + mabh + "?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {

                    if (cboMaKH_BH.SelectedIndex != -1 && cboMaSP_BH.SelectedIndex != -1 && manv != string.Empty && yeucau != string.Empty
                        && tinhtrang != string.Empty)
                    {
                        if (BatLoi_NgayLap_PhieuBH(ngaynhan))
                        {

                            if (BatLoi_NgayTra_PhieuBH(ngaynhan, ngaytra))
                            {
                                if (bh_bll.KiemTraTrungMaBH(mabh) == true)
                                {
                                    makh = cboMaKH_BH.SelectedValue.ToString();
                                    masp = cboMaSP_BH.SelectedValue.ToString();
                                    bh_bll.TaoPhieuBaoHanh(mabh, makh, masp, manv, yeucau, ngaynhan, ngaytra, tinhtrang);
                                    MessageBox.Show("Tạo Thành Công Phiếu Bảo Hành " + mabh, "Thông báo");
                                    loadDataBaoHanh();
                                    clear();

                                }
                                else
                                {
                                    MessageBox.Show("Phiếu Bảo Hành Đã Tồn Tại", "Thông báo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ngày Trả Phiếu Phải Lớn Hơn Hoặc Bằng Ngày Lập Phiếu", "Thông báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ngày Lập Phiếu Có Vấn Đề ", "Thông báo");
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
                MessageBox.Show("Có Vấn Đề Trong Việc Tạo Phiếu Bảo Hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mabh = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "MABAOHANH").ToString();
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Phiếu Bảo Hành  " + mabh + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    bh_bll.xoaPhieuBaoHanh(mabh);
                    loadDataBaoHanh();
                    MessageBox.Show("Xóa Thành Công Phiếu Bảo Hành  " + mabh);
                    clear();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Phiếu Bảo Hành  " + mabh);
            }
        }

        private void btnSuaBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mabh = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "MABAOHANH").ToString();
            try
            {
                string yeucau = txtYeuCau.Text;
                string tinhtrang = cboTinhTrang_BH.Text;
                DateTime ngaytra = dateNgayTra_BH.Value;
                DateTime ngaynhan = DateTime.Parse(gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "NGAYNHAN").ToString());
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Phiếu Bảo Hành  " + mabh + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "NGAYTRA").ToString() != "Đã Trả Bảo Hành")
                    {
                        if (BatLoi_NgayTra_PhieuBH(ngaynhan, ngaytra))
                        {
                            bh_bll.SuaPhieuBaoHanh(mabh, yeucau, ngaytra, tinhtrang);
                            loadDataBaoHanh();
                            MessageBox.Show("Sửa Thành Công Phiếu Bảo Hành " + mabh, "Thông Báo");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Ngày Trả Phiếu Bảo Hành Nhỏ Hơn Ngày Tạo ", "Thông Báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phiếu Bảo Hành Đã Hoàn Thành Không Thể Chỉnh Sửa ", "Thông Báo");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Phiếu Bảo Hành " + mabh, "Thông Báo");
            }
        }

        private void btnLamMoiBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clear();
        }

        private void gvBaoHanh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
         
           
        }

        private void gvBaoHanh_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvBaoHanh.RowCount != 0)
            {
                txtMaBH.EditValue = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "MABAOHANH").ToString();
                cboMaKH_BH.Text = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "MAKHACHHANG").ToString();
                cboMaSP_BH.Text = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "MASP").ToString();
                txtMaNV_BH.EditValue = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "MANV").ToString();
                txtYeuCau.EditValue = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "YEUCAUBAOHANH").ToString();
                dateNgayNhan_BH.Text = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "NGAYNHAN").ToString();
                dateNgayTra_BH.Text = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "NGAYTRA").ToString();
                cboTinhTrang_BH.Text = gvBaoHanh.GetRowCellValue(gvBaoHanh.FocusedRowHandle, "TINHTRANG").ToString();
            }
        }
    }
}
