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
    public partial class frm_NCC : Form
    {
        NCC_BLL ncc_bll = new NCC_BLL();
        public frm_NCC()
        {
            InitializeComponent();
        }

   
        // load mã NCC tự tạo
        void loadMaNCCTuTao()
        {
            txtMaNCC_NCC.Text = ncc_bll.SinhMaNCC();
        }

        // load data grid view 
        void loadDataNCC()
        {
            dataNCC.DataSource = ncc_bll.LoadNCC_BLL();
        }

        private void frm_NCC_Load(object sender, EventArgs e)
        {
            loadDataNCC();
            loadMaNCCTuTao();
 
        }

      

        private void txtDiaChi_NCC_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtDiaChi_NCC.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSDT_NCC_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length != 10)
            {
                errorProvider1.SetError(ctr, "Số điện thoại chỉ gồm 10 số");
                txtSDT_NCC.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtTenNCC_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenNCC.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtSDT_NCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Số điện thoại chỉ có số");
            }
            else
                errorProvider1.Clear();
        }

        private void dataNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC_NCC.Text = dataNCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dataNCC.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi_NCC.Text = dataNCC.CurrentRow.Cells[2].Value.ToString();
            txtSDT_NCC.Text = dataNCC.CurrentRow.Cells[3].Value.ToString();
            if (dataNCC.CurrentRow.Cells[4].Value == null)
            {
                txtChuThich_NCC.Text = "";
            }
            else
            {
                txtChuThich_NCC.Text = dataNCC.CurrentRow.Cells[4].Value.ToString();
            }

        }


        private void frm_NCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void toolStripThem_Click(object sender, EventArgs e)
        {
            try
            {
                string mancc = txtMaNCC_NCC.Text;
                string tenncc = txtTenNCC.Text;
                string dt = txtSDT_NCC.Text;
                string diachi = txtDiaChi_NCC.Text;
                string chuthich;


                if (txtChuThich_NCC.Text == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich_NCC.Text;
                }

                if (mancc != string.Empty && tenncc != string.Empty && dt != string.Empty && diachi != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Nhà Cung Cấp  " + mancc + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm nhân viên
                        if (ncc_bll.KiemTraTrung_NCC(txtMaNCC_NCC.Text) == true)
                        {
                            ncc_bll.ThemNcc(mancc, tenncc, diachi, dt, chuthich);
                            MessageBox.Show("Thêm Thành Công Nhà Cung Cấp " + mancc, "Thông báo");
                            loadDataNCC();
                            loadMaNCCTuTao();
                            txtTenNCC.Clear();
                            txtDiaChi_NCC.Clear();
                            txtSDT_NCC.Clear();
                            txtChuThich_NCC.Clear();
                           
                        }
                        else
                        {
                            MessageBox.Show("Mã Nhà Cung Cấp Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    if (txtDiaChi_NCC.Text == string.Empty)
                    {
                        MessageBox.Show("Địa chỉ còn bỏ trống", "Thống báo");
                        txtMaNCC_NCC.Focus();
                    }

                    if (txtTenNCC.Text == string.Empty)
                    {
                        MessageBox.Show("Tên nhà cung cấp còn bỏ trống", "Thống báo");
                        txtTenNCC.Focus();
                    }
                    if (txtSDT_NCC.Text == string.Empty)
                    {
                        MessageBox.Show("Số điện thoại còn bỏ trống", "Thống báo");
                        txtSDT_NCC.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Nhà Cung Cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripSua_Click(object sender, EventArgs e)
        {
            string mancc = dataNCC.CurrentRow.Cells[0].Value.ToString();
            try
            {
                string tenncc = txtTenNCC.Text;
                string dt = txtSDT_NCC.Text;
                string diachi = txtDiaChi_NCC.Text;
                string chuthich;

                if (txtChuThich_NCC.Text == string.Empty)
                {
                    chuthich = "";
                }
                else
                {
                    chuthich = txtChuThich_NCC.Text;
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Nhà Cung Cấp  " + dataNCC.CurrentRow.Cells[0].Value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    ncc_bll.suaNCC(mancc, tenncc, diachi, dt, chuthich);
                    loadDataNCC();
                    MessageBox.Show("Sửa Thành Công Nhà Cung Cấp " + mancc, "Thông Báo");
                    
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Nhà Cung Cấp " + mancc, "Thông Báo");
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            string mancc = dataNCC.CurrentRow.Cells[0].Value.ToString();
            try
            {
               
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Nhà Cung Cấp   " + dataNCC.CurrentRow.Cells[0].Value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    ncc_bll.xoaNCC(dataNCC.CurrentRow.Cells[0].Value.ToString());
                    loadDataNCC();
                    MessageBox.Show("Xóa Thành Công Nhà Cung Cấp  " + mancc);
                    loadMaNCCTuTao();
                    txtTenNCC.Clear();
                    txtDiaChi_NCC.Clear();
                    txtSDT_NCC.Clear();
                    txtChuThich_NCC.Clear();
                  
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Nhà Cung Cấp  " + mancc);
            }
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            loadMaNCCTuTao();
            txtTenNCC.Clear();
            txtDiaChi_NCC.Clear();
            txtSDT_NCC.Clear();
            txtChuThich_NCC.Clear();
          
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

      
    }
}
