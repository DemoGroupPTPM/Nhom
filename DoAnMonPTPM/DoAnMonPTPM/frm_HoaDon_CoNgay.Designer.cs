namespace DoAnMonPTPM
{
    partial class frm_HoaDon_CoNgay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_HoaDon_CoNgay));
            this.HOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_QLCH = new DoAnMonPTPM.DataSet_QLCH();
            this.dateTimePicker_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HOADONTableAdapter = new DoAnMonPTPM.DataSet_QLCHTableAdapters.HOADONTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_QLCH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HOADONBindingSource
            // 
            this.HOADONBindingSource.DataMember = "HOADON";
            this.HOADONBindingSource.DataSource = this.DataSet_QLCH;
            // 
            // DataSet_QLCH
            // 
            this.DataSet_QLCH.DataSetName = "DataSet_QLCH";
            this.DataSet_QLCH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePicker_TuNgay
            // 
            this.dateTimePicker_TuNgay.CustomFormat = "yyyy.MM.dd";
            this.dateTimePicker_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_TuNgay.Location = new System.Drawing.Point(103, 41);
            this.dateTimePicker_TuNgay.Name = "dateTimePicker_TuNgay";
            this.dateTimePicker_TuNgay.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_TuNgay.TabIndex = 0;
            // 
            // dateTimePicker_DenNgay
            // 
            this.dateTimePicker_DenNgay.CustomFormat = "yyyy.MM.dd";
            this.dateTimePicker_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_DenNgay.Location = new System.Drawing.Point(103, 85);
            this.dateTimePicker_DenNgay.Name = "dateTimePicker_DenNgay";
            this.dateTimePicker_DenNgay.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_DenNgay.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker_DenNgay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker_TuNgay);
            this.groupBox1.Location = new System.Drawing.Point(25, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Thông Tin";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(353, 51);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 35);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ Ngày";
            // 
            // reportViewer1
            // 
            reportDataSource4.Name = "qlhd";
            reportDataSource4.Value = this.HOADONBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoAnMonPTPM.BaoCao_HD_Ngay.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(25, 188);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1004, 296);
            this.reportViewer1.TabIndex = 3;
            // 
            // HOADONTableAdapter
            // 
            this.HOADONTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1125, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 24);
            this.toolStripButton1.Text = "Thoát";
            this.toolStripButton1.ToolTipText = "Thoát";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frm_HoaDon_CoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1125, 543);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_HoaDon_CoNgay";
            this.Text = "Báo Cáo Hóa Đơn Có Ngày";
            this.Load += new System.EventHandler(this.frm_HoaDon_CoNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_QLCH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_TuNgay;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DenNgay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HOADONBindingSource;
        private DataSet_QLCH DataSet_QLCH;
        private DataSet_QLCHTableAdapters.HOADONTableAdapter HOADONTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}