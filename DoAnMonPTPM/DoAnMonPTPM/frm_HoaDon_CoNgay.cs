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
    public partial class frm_HoaDon_CoNgay : Form
    {
        public frm_HoaDon_CoNgay()
        {
            InitializeComponent();
        }

        private void frm_HoaDon_CoNgay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet_QLCH.HOADON' table. You can move, or remove it, as needed.
            

            this.reportViewer1.RefreshReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string ngaydau = Convert.ToString(dateTimePicker_TuNgay.Value.ToString());
            string ngaycuoi = Convert.ToString(dateTimePicker_DenNgay.Value.ToString());
            this.HOADONTableAdapter.FillByNgay(this.DataSet_QLCH.HOADON,ngaydau, ngaycuoi);
            this.reportViewer1.RefreshReport();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
