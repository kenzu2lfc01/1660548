namespace GUI
{
    partial class frm_QuanLyChuyen
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
            this.button8 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnShowXe = new System.Windows.Forms.Button();
            this.btnSuaChuyen = new System.Windows.Forms.Button();
            this.btnShowTaiXe = new System.Windows.Forms.Button();
            this.btnXoaChuyen = new System.Windows.Forms.Button();
            this.btnThemChuyen = new System.Windows.Forms.Button();
            this.dgvChuyenXe = new System.Windows.Forms.DataGridView();
            this.clmIdChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgayKhoiHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGioKhoiHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenTaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenXe)).BeginInit();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(153, 413);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(148, 49);
            this.button8.TabIndex = 4;
            this.button8.Text = "Quản lý vé";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(477, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(316, 31);
            this.label10.TabIndex = 36;
            this.label10.Text = "QUẢN LÝ CHUYẾN XE";
            // 
            // btnShowXe
            // 
            this.btnShowXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowXe.Location = new System.Drawing.Point(246, 350);
            this.btnShowXe.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowXe.Name = "btnShowXe";
            this.btnShowXe.Size = new System.Drawing.Size(148, 49);
            this.btnShowXe.TabIndex = 5;
            this.btnShowXe.Text = "Quản lý xe";
            this.btnShowXe.UseVisualStyleBackColor = true;
            this.btnShowXe.Click += new System.EventHandler(this.btnShowXe_Click_1);
            // 
            // btnSuaChuyen
            // 
            this.btnSuaChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaChuyen.Location = new System.Drawing.Point(328, 293);
            this.btnSuaChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaChuyen.Name = "btnSuaChuyen";
            this.btnSuaChuyen.Size = new System.Drawing.Size(148, 49);
            this.btnSuaChuyen.TabIndex = 3;
            this.btnSuaChuyen.Text = "Sửa";
            this.btnSuaChuyen.UseVisualStyleBackColor = true;
            this.btnSuaChuyen.Click += new System.EventHandler(this.btnSuaChuyen_Click_1);
            // 
            // btnShowTaiXe
            // 
            this.btnShowTaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTaiXe.Location = new System.Drawing.Point(90, 350);
            this.btnShowTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowTaiXe.Name = "btnShowTaiXe";
            this.btnShowTaiXe.Size = new System.Drawing.Size(148, 49);
            this.btnShowTaiXe.TabIndex = 6;
            this.btnShowTaiXe.Text = "Quản lý tài xế";
            this.btnShowTaiXe.UseVisualStyleBackColor = true;
            this.btnShowTaiXe.Click += new System.EventHandler(this.btnShowTaiXe_Click_1);
            // 
            // btnXoaChuyen
            // 
            this.btnXoaChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaChuyen.Location = new System.Drawing.Point(172, 293);
            this.btnXoaChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaChuyen.Name = "btnXoaChuyen";
            this.btnXoaChuyen.Size = new System.Drawing.Size(148, 49);
            this.btnXoaChuyen.TabIndex = 2;
            this.btnXoaChuyen.Text = "Xóa";
            this.btnXoaChuyen.UseVisualStyleBackColor = true;
            this.btnXoaChuyen.Click += new System.EventHandler(this.btnXoaChuyen_Click_1);
            // 
            // btnThemChuyen
            // 
            this.btnThemChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemChuyen.Location = new System.Drawing.Point(16, 293);
            this.btnThemChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemChuyen.Name = "btnThemChuyen";
            this.btnThemChuyen.Size = new System.Drawing.Size(148, 49);
            this.btnThemChuyen.TabIndex = 1;
            this.btnThemChuyen.Text = "Thêm";
            this.btnThemChuyen.UseVisualStyleBackColor = true;
            this.btnThemChuyen.Click += new System.EventHandler(this.btnThemChuyen_Click_1);
            // 
            // dgvChuyenXe
            // 
            this.dgvChuyenXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChuyenXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdChuyen,
            this.clmTramDi,
            this.clmTramDen,
            this.clmNgayKhoiHanh,
            this.clmGioKhoiHanh,
            this.clmTenXe,
            this.clmTenTaiXe,
            this.clmTinhTrang,
            this.clmGhiChu});
            this.dgvChuyenXe.Location = new System.Drawing.Point(15, 42);
            this.dgvChuyenXe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChuyenXe.Name = "dgvChuyenXe";
            this.dgvChuyenXe.Size = new System.Drawing.Size(1391, 241);
            this.dgvChuyenXe.TabIndex = 30;
            // 
            // clmIdChuyen
            // 
            this.clmIdChuyen.DataPropertyName = "ID_Chuyen";
            this.clmIdChuyen.FillWeight = 80F;
            this.clmIdChuyen.HeaderText = "ID";
            this.clmIdChuyen.Name = "clmIdChuyen";
            this.clmIdChuyen.Width = 50;
            // 
            // clmTramDi
            // 
            this.clmTramDi.DataPropertyName = "TramDi";
            this.clmTramDi.HeaderText = "Trạm khởi hành";
            this.clmTramDi.Name = "clmTramDi";
            this.clmTramDi.Width = 135;
            // 
            // clmTramDen
            // 
            this.clmTramDen.DataPropertyName = "TramDen";
            this.clmTramDen.HeaderText = "Trạm kết thúc";
            this.clmTramDen.Name = "clmTramDen";
            this.clmTramDen.Width = 135;
            // 
            // clmNgayKhoiHanh
            // 
            this.clmNgayKhoiHanh.DataPropertyName = "NgayKhoiHanh";
            this.clmNgayKhoiHanh.HeaderText = "Ngày khởi hành";
            this.clmNgayKhoiHanh.Name = "clmNgayKhoiHanh";
            this.clmNgayKhoiHanh.Width = 120;
            // 
            // clmGioKhoiHanh
            // 
            this.clmGioKhoiHanh.DataPropertyName = "GioKhoiHanh";
            this.clmGioKhoiHanh.HeaderText = "Giờ khởi hành";
            this.clmGioKhoiHanh.Name = "clmGioKhoiHanh";
            this.clmGioKhoiHanh.Width = 130;
            // 
            // clmTenXe
            // 
            this.clmTenXe.DataPropertyName = "TenXe";
            this.clmTenXe.HeaderText = "Tên xe";
            this.clmTenXe.Name = "clmTenXe";
            // 
            // clmTenTaiXe
            // 
            this.clmTenTaiXe.DataPropertyName = "TenTaiXe";
            this.clmTenTaiXe.HeaderText = "Tên tài xế";
            this.clmTenTaiXe.Name = "clmTenTaiXe";
            this.clmTenTaiXe.Width = 130;
            // 
            // clmTinhTrang
            // 
            this.clmTinhTrang.DataPropertyName = "TinhTrang";
            this.clmTinhTrang.HeaderText = "Tình trạng";
            this.clmTinhTrang.Name = "clmTinhTrang";
            // 
            // clmGhiChu
            // 
            this.clmGhiChu.DataPropertyName = "Ghi_Chu";
            this.clmGhiChu.HeaderText = "Ghi chú";
            this.clmGhiChu.Name = "clmGhiChu";
            // 
            // frm_QuanLyChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 475);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnShowXe);
            this.Controls.Add(this.btnSuaChuyen);
            this.Controls.Add(this.btnShowTaiXe);
            this.Controls.Add(this.btnXoaChuyen);
            this.Controls.Add(this.btnThemChuyen);
            this.Controls.Add(this.dgvChuyenXe);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_QuanLyChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_QuanLyChuyen";
            this.Load += new System.EventHandler(this.frm_QuanLyChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnShowXe;
        private System.Windows.Forms.Button btnSuaChuyen;
        private System.Windows.Forms.Button btnShowTaiXe;
        private System.Windows.Forms.Button btnXoaChuyen;
        private System.Windows.Forms.Button btnThemChuyen;
        private System.Windows.Forms.DataGridView dgvChuyenXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgayKhoiHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioKhoiHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenTaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGhiChu;
    }
}