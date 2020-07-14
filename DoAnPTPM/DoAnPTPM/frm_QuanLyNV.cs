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
    public partial class frm_QuanLyNV : Form
    {
        NhanVienBLL nv_bll = new NhanVienBLL();
        PhanQuyen_BLL pq_bll = new PhanQuyen_BLL();
        public frm_QuanLyNV()
        {
            InitializeComponent();
        }

        private void frm_QuanLyNV_Load(object sender, EventArgs e)
        {
            loadDataNhanVien();
            loadCboPhanQuyen();
        }

        // load data grid view 
        void loadDataNhanVien()
        {
            dataGridViewNhanVien.DataSource = nv_bll.LoadNhanVien_BLL();
            //dataGridViewDiem.Columns["SinhVien"].Visible = false;
        }

        // combobox phan quyen
        void loadCboPhanQuyen()
        {
            cboQuyen.DataSource = pq_bll.LoadcboPhanQuyen_BLL();
            cboQuyen.DisplayMember = "CHUTHICH";
            cboQuyen.ValueMember = "MAPHANQUYEN";
            cboQuyen.SelectedIndex = -1;
        }
        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboQuyen.SelectedIndex != -1)
            {
                listBoxChucNang.DataSource = pq_bll.LoadChucNang_PhanQuyen_BLL(cboQuyen.SelectedValue.ToString());
                listBoxChucNang.DisplayMember = "TENCHUCNANG";
                listBoxChucNang.ValueMember = "MACHUCNANG";
            }
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
            if (ctr.Text.Trim().Length > 9)
            {
                errorProvider1.SetError(ctr, "Số điện thoại chỉ gồm 10 số");
                txtDienThoai.Focus();
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

        private void txtTenDN_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenDN.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtMK.Focus();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text;
                string tendn = txtTenDN.Text;
                string matkhau = txtMK.Text;
                string tennv = txtTenNV.Text;
                string diachi;
                if( txtDiaChi.Text == string.Empty)
                {
                    diachi = "";
                }
                else
                {
                    diachi = txtDiaChi.Text;
                }

                string dt = txtDienThoai.Text;
                string maphanquyen = cboQuyen.SelectedValue.ToString();
                string chuthich;
                if (txtChuThich.Text == string.Empty)
                {
                   chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich.Text;
                }


                // thêm nhân viên

                if (nv_bll.KiemTraTrung_NV(txtMaNV.Text) == true)
                {
                    nv_bll.ThemNv(manv, tendn, matkhau, tennv, diachi, dt, maphanquyen, chuthich);
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    loadDataNhanVien();
                }
                else
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo");
                }


            }
            catch
            {
                if(txtMaNV.Text == string.Empty)
                {
                    MessageBox.Show("Mã nhân viên còn bỏ trống","Thống báo");
                    txtMaNV.Focus();
                }
                else if (txtTenDN.Text == string.Empty)
                {
                    MessageBox.Show("Tên đăng nhập còn bỏ trống", "Thống báo");
                    txtTenDN.Focus();
                }
                else if (txtMK.Text == string.Empty)
                {
                    MessageBox.Show("Mật khẩu còn bỏ trống", "Thống báo");
                    txtMK.Focus();
                }
                else if (txtTenNV.Text == string.Empty)
                {
                    MessageBox.Show("Tên nhân viên còn bỏ trống", "Thống báo");
                    txtTenNV.Focus();
                }
                else if (txtDienThoai.Text == string.Empty)
                {
                    MessageBox.Show("Số điện thoại còn bỏ trống", "Thống báo");
                    txtDienThoai.Focus();
                }
                MessageBox.Show("Có gì đó sai sai rồi!!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

       
    }
}
