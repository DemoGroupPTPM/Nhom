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
    public partial class frm_BaoCao_PN_TheoNgay : Form
    {
        public frm_BaoCao_PN_TheoNgay()
        {
            InitializeComponent();
        }

        private void frm_BaoCao_PN_TheoNgay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet_QLCH.PHIEUNHAP' table. You can move, or remove it, as needed.
            //this.PHIEUNHAPTableAdapter.Fill(this.DataSet_QLCH.PHIEUNHAP);

            this.reportViewer1.RefreshReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string ngaydau = Convert.ToString(dateTimePicker_TuNgay.Value.ToString());
            string ngaycuoi = Convert.ToString(dateTimePicker_DenNgay.Value.ToString());
            this.PHIEUNHAPTableAdapter.FillBy1(this.DataSet_QLCH.PHIEUNHAP,ngaydau,ngaycuoi);
            this.reportViewer1.RefreshReport();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
