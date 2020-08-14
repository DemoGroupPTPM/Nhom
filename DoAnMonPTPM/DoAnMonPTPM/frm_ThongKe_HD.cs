using BLL_DAL;
using DoAnMonPTPM.DataSet_QLCHTableAdapters;
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
    public partial class frm_ThongKe_HD : Form
    {
        HoaDon_BLL hd_bll = new HoaDon_BLL();
        public frm_ThongKe_HD()
        {
            InitializeComponent();
         
        }

        private void loadCboHD()
        {
            cboMaHD.DataSource = hd_bll.LoadHoaDon_BLL();
            cboMaHD.DisplayMember = "MAHD";
            cboMaHD.ValueMember = "MAHD";
            cboMaHD.SelectedIndex = -1;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string t = "";
            if(cboMaHD.SelectedIndex != -1)
            {
                t = cboMaHD.SelectedValue.ToString();
            }
            try
            {
                this.DataTable1TableAdapter.Fill(this.DataSet_QLCH.DataTable1, t);
                this.HOADONTableAdapter.FillBymahd(this.DataSet_QLCH.HOADON, t);
                this.reportViewer1.RefreshReport();
            }
            catch
            {

            }
           
        }

        private void frm_ThongKe_HD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet_QLCH.DataTable1' table. You can move, or remove it, as needed.
            //this.DataTable1TableAdapter.Fill(this.DataSet_QLCH.DataTable1);
            // TODO: This line of code loads data into the 'DataSet_QLCH.HOADON' table. You can move, or remove it, as needed.
            //this.HOADONTableAdapter.Fill(this.DataSet_QLCH.HOADON);
            // TODO: This line of code loads data into the 'DataSet_QLCH.DataTable1' table. You can move, or remove it, as needed.

            loadCboHD();
            this.reportViewer1.RefreshReport();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
