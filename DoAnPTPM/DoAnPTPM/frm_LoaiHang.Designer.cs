namespace DoAnPTPM
{
    partial class frm_LoaiHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LoaiHang));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripThoat = new System.Windows.Forms.ToolStripButton();
            this.dataLoaiHang = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenLoaiHang = new System.Windows.Forms.TextBox();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.cboMaNhomHang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLoaiHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripThem,
            this.toolStripSeparator1,
            this.toolStripSua,
            this.toolStripSeparator2,
            this.toolStripXoa,
            this.toolStripSeparator3,
            this.toolStripClear,
            this.toolStripSeparator4,
            this.toolStripThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(666, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripThem
            // 
            this.toolStripThem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripThem.Image")));
            this.toolStripThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripThem.Name = "toolStripThem";
            this.toolStripThem.Size = new System.Drawing.Size(142, 24);
            this.toolStripThem.Text = "Thêm Loại Hàng";
            this.toolStripThem.Click += new System.EventHandler(this.toolStripThem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSua
            // 
            this.toolStripSua.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSua.Image")));
            this.toolStripSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSua.Name = "toolStripSua";
            this.toolStripSua.Size = new System.Drawing.Size(130, 24);
            this.toolStripSua.Text = "Sửa Loại Hàng";
            this.toolStripSua.Click += new System.EventHandler(this.toolStripSua_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripXoa
            // 
            this.toolStripXoa.Image = ((System.Drawing.Image)(resources.GetObject("toolStripXoa.Image")));
            this.toolStripXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXoa.Name = "toolStripXoa";
            this.toolStripXoa.Size = new System.Drawing.Size(131, 24);
            this.toolStripXoa.Text = "Xóa Loại Hàng";
            this.toolStripXoa.Click += new System.EventHandler(this.toolStripXoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripClear
            // 
            this.toolStripClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClear.Image")));
            this.toolStripClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClear.Name = "toolStripClear";
            this.toolStripClear.Size = new System.Drawing.Size(91, 24);
            this.toolStripClear.Text = "Làm Mới";
            this.toolStripClear.Click += new System.EventHandler(this.toolStripClear_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripThoat
            // 
            this.toolStripThoat.Image = ((System.Drawing.Image)(resources.GetObject("toolStripThoat.Image")));
            this.toolStripThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripThoat.Name = "toolStripThoat";
            this.toolStripThoat.Size = new System.Drawing.Size(71, 24);
            this.toolStripThoat.Text = "Thoát";
            this.toolStripThoat.Click += new System.EventHandler(this.toolStripThoat_Click);
            // 
            // dataLoaiHang
            // 
            this.dataLoaiHang.AllowUserToAddRows = false;
            this.dataLoaiHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLoaiHang.Location = new System.Drawing.Point(34, 269);
            this.dataLoaiHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataLoaiHang.Name = "dataLoaiHang";
            this.dataLoaiHang.RowHeadersWidth = 51;
            this.dataLoaiHang.Size = new System.Drawing.Size(505, 228);
            this.dataLoaiHang.TabIndex = 12;
            this.dataLoaiHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataLoaiHang_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenLoaiHang);
            this.groupBox1.Controls.Add(this.txtMaLoai);
            this.groupBox1.Controls.Add(this.cboMaNhomHang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 90);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(505, 171);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại Hàng";
            // 
            // txtTenLoaiHang
            // 
            this.txtTenLoaiHang.Location = new System.Drawing.Point(149, 128);
            this.txtTenLoaiHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenLoaiHang.Name = "txtTenLoaiHang";
            this.txtTenLoaiHang.Size = new System.Drawing.Size(204, 22);
            this.txtTenLoaiHang.TabIndex = 5;
            this.txtTenLoaiHang.Leave += new System.EventHandler(this.txtTenLoaiHang_Leave);
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Enabled = false;
            this.txtMaLoai.Location = new System.Drawing.Point(149, 78);
            this.txtMaLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(204, 22);
            this.txtMaLoai.TabIndex = 4;
            // 
            // cboMaNhomHang
            // 
            this.cboMaNhomHang.FormattingEnabled = true;
            this.cboMaNhomHang.Location = new System.Drawing.Point(149, 31);
            this.cboMaNhomHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMaNhomHang.Name = "cboMaNhomHang";
            this.cboMaNhomHang.Size = new System.Drawing.Size(204, 24);
            this.cboMaNhomHang.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Loại Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Nhóm Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Loại Hàng";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "QUẢN LÝ LOẠI HÀNG";
            // 
            // frm_LoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 510);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataLoaiHang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm_LoaiHang";
            this.Text = "Loại Hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_LoaiHang_FormClosing);
            this.Load += new System.EventHandler(this.frm_LoaiHang_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLoaiHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripSua;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripThoat;
        private System.Windows.Forms.DataGridView dataLoaiHang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenLoaiHang;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.ComboBox cboMaNhomHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
    }
}