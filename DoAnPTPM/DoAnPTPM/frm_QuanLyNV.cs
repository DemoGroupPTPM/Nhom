using BLL_DAL;
using System;
using System.Windows.Forms;

namespace DoAnPTPM
{
    public partial class frm_QuanLyNV : Form
    {
        NhanVienBLL nv_bll = new NhanVienBLL();
        PhanQuyen_BLL pq_bll = new PhanQuyen_BLL();
        ChucNang_BLL cn_BLL = new ChucNang_BLL();

        public frm_QuanLyNV()
        {
            InitializeComponent();
        }

        private void frm_QuanLyNV_Load(object sender, EventArgs e)
        {
            loadDataNhanVien();
            loadCboPhanQuyen();
            loadMaNVTuTao();
            txtMaNV.Enabled = false;
            
        }

        // load mã nv
        void loadMaNVTuTao()
        {
            txtMaNV.Text = nv_bll.SinhMaNV();
        }

        // load data grid view 
        void loadDataNhanVien()
        {
            dataGridViewNhanVien.DataSource = nv_bll.LoadNhanVien_BLL();
            dataGridViewNhanVien.Columns["PhanQuyen"].Visible = false;
        }

        // combobox phân quyền
        void loadCboPhanQuyen()
        {
            cboQuyen.DataSource = pq_bll.LoadcboPhanQuyen_BLL();
            cboQuyen.DisplayMember = "CHUTHICH";
            cboQuyen.ValueMember = "MAPHANQUYEN";
            cboQuyen.SelectedIndex = -1;
        }

        //chọn quyền sẽ xuát hiện các chức năng mà quyền dó có thể làm 
        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboQuyen.SelectedIndex != -1)
            {
                listBoxChucNang.DataSource = pq_bll.LoadChucNang_PhanQuyen_BLL(cboQuyen.SelectedValue.ToString());
                listBoxChucNang.DisplayMember = "TENCHUCNANG";
                listBoxChucNang.ValueMember = "MACHUCNANG";
            }
           
        }


        // bắt lỗi các sự kiện
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


        //khi nhấn vào listbox chức năng sẽ hiện ra tên chức năng
        private void listBoxChucNang_Click(object sender, EventArgs e)
        {
            if (listBoxChucNang.Items.Count != 0)
            {
                string macn = listBoxChucNang.SelectedValue.ToString();
                listBoxTenChucNang.DataSource = cn_BLL.LoadTenChucNang_BLL(macn);
                listBoxTenChucNang.DisplayMember = "TENCHUCNANG";
            }

        }


        // đưa dữ liệu từ datagrid view về các textbox
        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtMK.Text = dataGridViewNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtTenNV.Text = dataGridViewNhanVien.CurrentRow.Cells[2].Value.ToString();
            if (dataGridViewNhanVien.CurrentRow.Cells[3].Value == null)
            {
                txtDiaChi.Text = "";
            }
            else
            {
                txtDiaChi.Text = dataGridViewNhanVien.CurrentRow.Cells[3].Value.ToString();
            }

            txtDienThoai.Text = dataGridViewNhanVien.CurrentRow.Cells[4].Value.ToString();
            cboQuyen.Text = dataGridViewNhanVien.CurrentRow.Cells[5].Value.ToString();

            if (dataGridViewNhanVien.CurrentRow.Cells[6].Value == null)
            {
                txtChuThich.Text = "";
            }
            else
            {
                txtChuThich.Text = dataGridViewNhanVien.CurrentRow.Cells[6].Value.ToString();
            }
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

        }

        // thêm nhân viên 
        private void toolStripThem_Click(object sender, EventArgs e)
        {

            try
            {
                string manv = txtMaNV.Text;
                string matkhau = txtMK.Text;
                string tennv = txtTenNV.Text;
                string dt = txtDienThoai.Text;
                string maphanquyen;
                string chuthich;
                string diachi;

                if (txtDiaChi.Text == string.Empty)
                {
                    diachi = "";
                }
                else
                {
                    diachi = txtDiaChi.Text;
                }

                if (txtChuThich.Text == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich.Text;
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
                            txtTenNV.Clear();
                            txtMK.Clear();
                            txtDiaChi.Clear();
                            txtDienThoai.Clear();
                           // cboQuyen.DataSource = null;
                            loadDataNhanVien();
                            loadCboPhanQuyen();
                            listBoxChucNang.Enabled = false;
                            listBoxTenChucNang.Enabled = false;
                            txtChuThich.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Mã Nhân Viên Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {

                    if (txtMK.Text == string.Empty)
                    {
                        MessageBox.Show("Mật khẩu còn bỏ trống", "Thống báo");
                        txtMK.Focus();
                    }
                    if (txtTenNV.Text == string.Empty)
                    {
                        MessageBox.Show("Tên nhân viên còn bỏ trống", "Thống báo");
                        txtTenNV.Focus();
                    }
                    if (txtDienThoai.Text == string.Empty)
                    {
                        MessageBox.Show("Số điện thoại còn bỏ trống", "Thống báo");
                        txtDienThoai.Focus();
                    }
                    if (cboQuyen.Text == string.Empty)
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

        // sửa nhân viên
        private void toolStripSua_Click(object sender, EventArgs e)
        {
            string manv = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
            try
            {

                string matkhau = txtMK.Text;
                string tennv = txtTenNV.Text;
                string dt = txtDienThoai.Text;
                string maphanquyen = cboQuyen.Text;
                string chuthich;
                string diachi;
                if (txtDiaChi.Text == string.Empty)
                {
                    diachi = "";
                }
                else
                {
                    diachi = txtDiaChi.Text;
                }

                if (txtChuThich.Text == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich.Text;
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Nhân Viên  " + manv + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    nv_bll.suaNhanVien(manv, matkhau, tennv, diachi, dt, maphanquyen, chuthich);
                    loadDataNhanVien();
                    MessageBox.Show("Sửa Thành Công Nhân Viên " + manv, "Thông Báo");
                
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Nhân Viên " + manv, "Thông Báo");
            }
        }
        // xóa nhan viên
        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            string manv = dataGridViewNhanVien.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Nhân Viên  " + manv + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    nv_bll.xoaNhanVien(manv);
                    loadDataNhanVien();
                    MessageBox.Show("Xóa Thành Công Nhân Viên  " + manv);
          
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Nhân Viên  " + manv);
            }

        }
        // nút clear mọi thông tin và làm mới mã nhân viên
        private void toolStripClear_Click(object sender, EventArgs e)
        {
            loadMaNVTuTao();
            txtTenNV.Clear();
            txtMK.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            cboQuyen.DataSource = null;
            listBoxChucNang.Enabled = false;       
            listBoxTenChucNang.Enabled = false;
            txtChuThich.Clear();
            loadCboPhanQuyen();
           
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_QuanLyNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có kí tự");
            }
            else
                errorProvider1.Clear();
        }

     
    }
}
