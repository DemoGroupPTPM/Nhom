namespace DoAnPTPM
{
    partial class frm_NCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NCC));
            this.txtDiaChi_NCC = new System.Windows.Forms.TextBox();
            this.txtChuThich_NCC = new System.Windows.Forms.TextBox();
            this.txtSDT_NCC = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtMaNCC_NCC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataNCC = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripThoat = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDiaChi_NCC
            // 
            this.txtDiaChi_NCC.Location = new System.Drawing.Point(147, 130);
            this.txtDiaChi_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiaChi_NCC.Name = "txtDiaChi_NCC";
            this.txtDiaChi_NCC.Size = new System.Drawing.Size(177, 22);
            this.txtDiaChi_NCC.TabIndex = 9;
            this.txtDiaChi_NCC.Leave += new System.EventHandler(this.txtDiaChi_NCC_Leave);
            // 
            // txtChuThich_NCC
            // 
            this.txtChuThich_NCC.Location = new System.Drawing.Point(508, 71);
            this.txtChuThich_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtChuThich_NCC.Name = "txtChuThich_NCC";
            this.txtChuThich_NCC.Size = new System.Drawing.Size(177, 22);
            this.txtChuThich_NCC.TabIndex = 8;
            // 
            // txtSDT_NCC
            // 
            this.txtSDT_NCC.Location = new System.Drawing.Point(508, 23);
            this.txtSDT_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtSDT_NCC.Name = "txtSDT_NCC";
            this.txtSDT_NCC.Size = new System.Drawing.Size(177, 22);
            this.txtSDT_NCC.TabIndex = 7;
            this.txtSDT_NCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_NCC_KeyPress);
            this.txtSDT_NCC.Leave += new System.EventHandler(this.txtSDT_NCC_Leave);
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(147, 76);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(177, 22);
            this.txtTenNCC.TabIndex = 6;
            this.txtTenNCC.Leave += new System.EventHandler(this.txtTenNCC_Leave);
            // 
            // txtMaNCC_NCC
            // 
            this.txtMaNCC_NCC.Enabled = false;
            this.txtMaNCC_NCC.Location = new System.Drawing.Point(147, 21);
            this.txtMaNCC_NCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNCC_NCC.Name = "txtMaNCC_NCC";
            this.txtMaNCC_NCC.Size = new System.Drawing.Size(177, 22);
            this.txtMaNCC_NCC.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Chú Thích";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Điện Thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Địa Chỉ ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên NCC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã NCC";
            // 
            // dataNCC
            // 
            this.dataNCC.AllowUserToAddRows = false;
            this.dataNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataNCC.Location = new System.Drawing.Point(13, 271);
            this.dataNCC.Margin = new System.Windows.Forms.Padding(4);
            this.dataNCC.Name = "dataNCC";
            this.dataNCC.ReadOnly = true;
            this.dataNCC.RowHeadersWidth = 51;
            this.dataNCC.Size = new System.Drawing.Size(752, 226);
            this.dataNCC.TabIndex = 3;
            this.dataNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataNCC_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiaChi_NCC);
            this.groupBox1.Controls.Add(this.txtTenNCC);
            this.groupBox1.Controls.Add(this.txtChuThich_NCC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSDT_NCC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaNCC_NCC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(13, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 176);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhà Cung Cấp";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripThem,
            this.toolStripSeparator1,
            this.toolStripSua,
            this.toolStripSeparator2,
            this.toolStripXoa,
            this.toolStripSeparator3,
            this.toolStripClear,
            this.toolStripSeparator4,
            this.toolStripThoat});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(806, 27);
            this.toolStrip2.TabIndex = 34;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripThem
            // 
            this.toolStripThem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripThem.Image")));
            this.toolStripThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripThem.Name = "toolStripThem";
            this.toolStripThem.Size = new System.Drawing.Size(169, 24);
            this.toolStripThem.Text = "Thêm Nhà Cung Cấp";
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
            this.toolStripSua.Size = new System.Drawing.Size(157, 24);
            this.toolStripSua.Text = "Sửa Nhà Cung Cấp";
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
            this.toolStripXoa.Size = new System.Drawing.Size(158, 24);
            this.toolStripXoa.Text = "Xóa Nhà Cung Cấp";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 32);
            this.label1.TabIndex = 35;
            this.label1.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            // 
            // frm_NCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataNCC);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_NCC";
            this.Text = "Nhà Cung Cấp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_NCC_FormClosing);
            this.Load += new System.EventHandler(this.frm_NCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDiaChi_NCC;
        private System.Windows.Forms.TextBox txtChuThich_NCC;
        private System.Windows.Forms.TextBox txtSDT_NCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtMaNCC_NCC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataNCC;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripSua;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripThoat;
        private System.Windows.Forms.Label label1;
    }
}