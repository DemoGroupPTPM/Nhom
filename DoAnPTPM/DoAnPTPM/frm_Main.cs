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
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_QuanLyNV frm = new frm_QuanLyNV();
            frm.MdiParent = this;
            frm.Show();
        }
        //frmNguoiDung frm = new frmNguoiDung();
        //frm.MdiParent = this;
        //frm.Show();
    }
}
