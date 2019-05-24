namespace GUI
{
    partial class frm_ThemChuyen
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChonChuyen = new System.Windows.Forms.DataGridView();
            this.clmMaTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbTramBatDau = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDTuyen = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbLoaiXe = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.dgvXe = new System.Windows.Forms.DataGridView();
            this.clmMaXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIDXe = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTenTaiXe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTaiXe = new System.Windows.Forms.DataGridView();
            this.clmMaTaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenTaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBangLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIDTaiXe = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpGioKhoiHanh = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaChuyen = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.dtpNgayKhoiHanh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonChuyen)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXe)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiXe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM CHUYẾN";
            // 
            // dgvChonChuyen
            // 
            this.dgvChonChuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChonChuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaTuyen,
            this.clmTramDi,
            this.clmTramKetThuc});
            this.dgvChonChuyen.Location = new System.Drawing.Point(9, 65);
            this.dgvChonChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChonChuyen.Name = "dgvChonChuyen";
            this.dgvChonChuyen.Size = new System.Drawing.Size(480, 127);
            this.dgvChonChuyen.TabIndex = 1;
            this.dgvChonChuyen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChonChuyen_CellClick);
            // 
            // clmMaTuyen
            // 
            this.clmMaTuyen.DataPropertyName = "ID_Tuyen";
            this.clmMaTuyen.FillWeight = 50F;
            this.clmMaTuyen.HeaderText = "ID";
            this.clmMaTuyen.Name = "clmMaTuyen";
            this.clmMaTuyen.Width = 50;
            // 
            // clmTramDi
            // 
            this.clmTramDi.DataPropertyName = "TenTram1";
            this.clmTramDi.FillWeight = 130F;
            this.clmTramDi.HeaderText = "Trạm bắt đầu";
            this.clmTramDi.Name = "clmTramDi";
            this.clmTramDi.Width = 130;
            // 
            // clmTramKetThuc
            // 
            this.clmTramKetThuc.DataPropertyName = "TenTram2";
            this.clmTramKetThuc.FillWeight = 130F;
            this.clmTramKetThuc.HeaderText = "Trạm kết thúc";
            this.clmTramKetThuc.Name = "clmTramKetThuc";
            this.clmTramKetThuc.Width = 130;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbTramBatDau);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtIDTuyen);
            this.groupBox2.Controls.Add(this.dgvChonChuyen);
            this.groupBox2.Location = new System.Drawing.Point(8, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(504, 231);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn tuyến";
            // 
            // cbbTramBatDau
            // 
            this.cbbTramBatDau.FormattingEnabled = true;
            this.cbbTramBatDau.Location = new System.Drawing.Point(111, 22);
            this.cbbTramBatDau.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTramBatDau.Name = "cbbTramBatDau";
            this.cbbTramBatDau.Size = new System.Drawing.Size(160, 24);
            this.cbbTramBatDau.TabIndex = 1;
            this.cbbTramBatDau.SelectedIndexChanged += new System.EventHandler(this.cbbTramBatDau_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trạm bắt đầu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIDTuyen
            // 
            this.txtIDTuyen.Location = new System.Drawing.Point(412, 199);
            this.txtIDTuyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDTuyen.Name = "txtIDTuyen";
            this.txtIDTuyen.ReadOnly = true;
            this.txtIDTuyen.Size = new System.Drawing.Size(76, 22);
            this.txtIDTuyen.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbLoaiXe);
            this.groupBox3.Controls.Add(this.label);
            this.groupBox3.Controls.Add(this.dgvXe);
            this.groupBox3.Controls.Add(this.txtIDXe);
            this.groupBox3.Location = new System.Drawing.Point(8, 262);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(504, 210);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn xe";
            // 
            // cbbLoaiXe
            // 
            this.cbbLoaiXe.FormattingEnabled = true;
            this.cbbLoaiXe.Location = new System.Drawing.Point(111, 25);
            this.cbbLoaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.cbbLoaiXe.Name = "cbbLoaiXe";
            this.cbbLoaiXe.Size = new System.Drawing.Size(160, 24);
            this.cbbLoaiXe.TabIndex = 2;
            this.cbbLoaiXe.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiXe_SelectedIndexChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(8, 28);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 17);
            this.label.TabIndex = 3;
            this.label.Text = "Loại xe";
            this.label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvXe
            // 
            this.dgvXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaXe,
            this.clmTenXe,
            this.clmLoaiXe});
            this.dgvXe.Location = new System.Drawing.Point(8, 55);
            this.dgvXe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvXe.Name = "dgvXe";
            this.dgvXe.Size = new System.Drawing.Size(481, 116);
            this.dgvXe.TabIndex = 1;
            this.dgvXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXe_CellClick);
            // 
            // clmMaXe
            // 
            this.clmMaXe.DataPropertyName = "XeID";
            this.clmMaXe.HeaderText = "ID";
            this.clmMaXe.Name = "clmMaXe";
            this.clmMaXe.Width = 50;
            // 
            // clmTenXe
            // 
            this.clmTenXe.DataPropertyName = "TenXe";
            this.clmTenXe.HeaderText = "Tên xe";
            this.clmTenXe.Name = "clmTenXe";
            this.clmTenXe.Width = 130;
            // 
            // clmLoaiXe
            // 
            this.clmLoaiXe.DataPropertyName = "TenLoai";
            this.clmLoaiXe.HeaderText = "Loại xe";
            this.clmLoaiXe.Name = "clmLoaiXe";
            this.clmLoaiXe.Width = 130;
            // 
            // txtIDXe
            // 
            this.txtIDXe.Location = new System.Drawing.Point(412, 178);
            this.txtIDXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDXe.Name = "txtIDXe";
            this.txtIDXe.ReadOnly = true;
            this.txtIDXe.Size = new System.Drawing.Size(76, 22);
            this.txtIDXe.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTimKiem);
            this.groupBox4.Controls.Add(this.txtTenTaiXe);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.dgvTaiXe);
            this.groupBox4.Controls.Add(this.txtIDTaiXe);
            this.groupBox4.Location = new System.Drawing.Point(520, 23);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(515, 229);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chọn tài xế";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(265, 14);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 28);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTenTaiXe
            // 
            this.txtTenTaiXe.Location = new System.Drawing.Point(88, 17);
            this.txtTenTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenTaiXe.Name = "txtTenTaiXe";
            this.txtTenTaiXe.Size = new System.Drawing.Size(168, 22);
            this.txtTenTaiXe.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tên tài xế";
            // 
            // dgvTaiXe
            // 
            this.dgvTaiXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaTaiXe,
            this.clmTenTaiXe,
            this.clmBangLai});
            this.dgvTaiXe.Location = new System.Drawing.Point(11, 63);
            this.dgvTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTaiXe.Name = "dgvTaiXe";
            this.dgvTaiXe.Size = new System.Drawing.Size(481, 127);
            this.dgvTaiXe.TabIndex = 1;
            this.dgvTaiXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiXe_CellClick);
            // 
            // clmMaTaiXe
            // 
            this.clmMaTaiXe.DataPropertyName = "ID_TaiXe";
            this.clmMaTaiXe.HeaderText = "ID";
            this.clmMaTaiXe.Name = "clmMaTaiXe";
            this.clmMaTaiXe.Width = 50;
            // 
            // clmTenTaiXe
            // 
            this.clmTenTaiXe.DataPropertyName = "TenTaiXe";
            this.clmTenTaiXe.HeaderText = "Tên tài xế";
            this.clmTenTaiXe.Name = "clmTenTaiXe";
            this.clmTenTaiXe.Width = 130;
            // 
            // clmBangLai
            // 
            this.clmBangLai.DataPropertyName = "BangLai";
            this.clmBangLai.HeaderText = "Bằng lái";
            this.clmBangLai.Name = "clmBangLai";
            this.clmBangLai.Width = 130;
            // 
            // txtIDTaiXe
            // 
            this.txtIDTaiXe.Location = new System.Drawing.Point(328, 199);
            this.txtIDTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDTaiXe.Name = "txtIDTaiXe";
            this.txtIDTaiXe.ReadOnly = true;
            this.txtIDTaiXe.Size = new System.Drawing.Size(76, 22);
            this.txtIDTaiXe.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpGioKhoiHanh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMaChuyen);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.dtpNgayKhoiHanh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1048, 492);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chuyến";
            // 
            // dtpGioKhoiHanh
            // 
            this.dtpGioKhoiHanh.CustomFormat = "HH:mm";
            this.dtpGioKhoiHanh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioKhoiHanh.Location = new System.Drawing.Point(643, 329);
            this.dtpGioKhoiHanh.Margin = new System.Windows.Forms.Padding(4);
            this.dtpGioKhoiHanh.Name = "dtpGioKhoiHanh";
            this.dtpGioKhoiHanh.ShowUpDown = true;
            this.dtpGioKhoiHanh.Size = new System.Drawing.Size(72, 22);
            this.dtpGioKhoiHanh.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(528, 330);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Giờ khởi hành";
            // 
            // txtMaChuyen
            // 
            this.txtMaChuyen.Location = new System.Drawing.Point(643, 265);
            this.txtMaChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaChuyen.Name = "txtMaChuyen";
            this.txtMaChuyen.Size = new System.Drawing.Size(133, 22);
            this.txtMaChuyen.TabIndex = 4;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(643, 363);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(380, 121);
            this.txtGhiChu.TabIndex = 7;
            // 
            // dtpNgayKhoiHanh
            // 
            this.dtpNgayKhoiHanh.CustomFormat = "dd-MM-yyyy";
            this.dtpNgayKhoiHanh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKhoiHanh.Location = new System.Drawing.Point(643, 297);
            this.dtpNgayKhoiHanh.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayKhoiHanh.Name = "dtpNgayKhoiHanh";
            this.dtpNgayKhoiHanh.Size = new System.Drawing.Size(133, 22);
            this.dtpNgayKhoiHanh.TabIndex = 6;
            this.dtpNgayKhoiHanh.Value = new System.DateTime(2018, 12, 14, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 363);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ghi Chú";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(543, 268);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã chuyến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(525, 302);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày khởi hành";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(413, 544);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(191, 57);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frm_ThemChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 613);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_ThemChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ThemChuyen";
            this.Load += new System.EventHandler(this.frm_ThemChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonChuyen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXe)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiXe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChonChuyen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvXe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvTaiXe;
        private System.Windows.Forms.ComboBox cbbTramBatDau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDTuyen;
        private System.Windows.Forms.ComboBox cbbLoaiXe;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtIDXe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTenTaiXe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIDTaiXe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.DateTimePicker dtpNgayKhoiHanh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLoaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaTaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenTaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBangLai;
        private System.Windows.Forms.TextBox txtMaChuyen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpGioKhoiHanh;
        private System.Windows.Forms.Label label7;
    }
}