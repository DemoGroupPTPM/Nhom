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
    public partial class frm_BaoCao_PN : Form
    {
        CT_PHIEUNHAP ctpn_bll = new CT_PHIEUNHAP();
        public frm_BaoCao_PN()
        {
            InitializeComponent();
        }

        private void frm_BaoCao_PN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet_QLCH.DataTable2' table. You can move, or remove it, as needed.
            //this.DataTable2TableAdapter.Fill(this.DataSet_QLCH.DataTable2);
            // TODO: This line of code loads data into the 'DataSet_QLCH.PHIEUNHAP' table. You can move, or remove it, as needed.
            //this.PHIEUNHAPTableAdapter.Fill(this.DataSet_QLCH.PHIEUNHAP);
            loadCboPN();
            this.reportViewer1.RefreshReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string t = "";
            if(cboMaPN.SelectedIndex != -1)
            {
                t = cboMaPN.SelectedValue.ToString();
            }
            try
            {
                this.DataTable2TableAdapter.Fill(this.DataSet_QLCH.DataTable2, t);
                this.PHIEUNHAPTableAdapter.FillBy(this.DataSet_QLCH.PHIEUNHAP, t);
                this.reportViewer1.RefreshReport();
            }
            catch
            {

            }
           

        }
        private void loadCboPN()
        {
            cboMaPN.DataSource = ctpn_bll.LoadCbo_PN_BLL();
            cboMaPN.DisplayMember = "MAPN";
            cboMaPN.ValueMember = "MAPN";
            cboMaPN.SelectedIndex = -1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
