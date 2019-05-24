namespace GUI
{
    partial class frm_QuanLyXe
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
            this.dgvDSXE = new System.Windows.Forms.DataGridView();
            this.clmID_Xe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSoDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbLoaiXe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenXe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoDangKy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaXe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.btnXemGhe = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbLoaiXeThem = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSXE)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ XE";
            // 
            // dgvDSXE
            // 
            this.dgvDSXE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSXE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID_Xe,
            this.clmTenXe,
            this.clmSoDK,
            this.clmTenLoaiXe});
            this.dgvDSXE.Location = new System.Drawing.Point(197, 50);
            this.dgvDSXE.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSXE.Name = "dgvDSXE";
            this.dgvDSXE.Size = new System.Drawing.Size(713, 185);
            this.dgvDSXE.TabIndex = 1;
            // 
            // clmID_Xe
            // 
            this.clmID_Xe.DataPropertyName = "XeID";
            this.clmID_Xe.HeaderText = "Mã Xe";
            this.clmID_Xe.Name = "clmID_Xe";
            // 
            // clmTenXe
            // 
            this.clmTenXe.DataPropertyName = "TenXe";
            this.clmTenXe.HeaderText = "Tên Xe";
            this.clmTenXe.Name = "clmTenXe";
            this.clmTenXe.Width = 160;
            // 
            // clmSoDK
            // 
            this.clmSoDK.DataPropertyName = "So_dang_ky";
            this.clmSoDK.HeaderText = "Số Đăng Ký";
            this.clmSoDK.Name = "clmSoDK";
            // 
            // clmTenLoaiXe
            // 
            this.clmTenLoaiXe.DataPropertyName = "TenLoai";
            this.clmTenLoaiXe.HeaderText = "Tên Loại Xe";
            this.clmTenLoaiXe.Name = "clmTenLoaiXe";
            this.clmTenLoaiXe.Width = 130;
            // 
            // cbbLoaiXe
            // 
            this.cbbLoaiXe.FormattingEnabled = true;
            this.cbbLoaiXe.Location = new System.Drawing.Point(16, 75);
            this.cbbLoaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.cbbLoaiXe.Name = "cbbLoaiXe";
            this.cbbLoaiXe.Size = new System.Drawing.Size(172, 24);
            this.cbbLoaiXe.TabIndex = 1;
            this.cbbLoaiXe.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiXe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loại xe";
            // 
            // txtTenXe
            // 
            this.txtTenXe.Location = new System.Drawing.Point(540, 251);
            this.txtTenXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenXe.Name = "txtTenXe";
            this.txtTenXe.Size = new System.Drawing.Size(179, 22);
            this.txtTenXe.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(465, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tên xe";
            // 
            // txtSoDangKy
            // 
            this.txtSoDangKy.Location = new System.Drawing.Point(297, 294);
            this.txtSoDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoDangKy.Name = "txtSoDangKy";
            this.txtSoDangKy.Size = new System.Drawing.Size(159, 22);
            this.txtSoDangKy.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 297);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Số đăng ký";
            // 
            // txtMaXe
            // 
            this.txtMaXe.Location = new System.Drawing.Point(297, 251);
            this.txtMaXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaXe.Name = "txtMaXe";
            this.txtMaXe.Size = new System.Drawing.Size(105, 22);
            this.txtMaXe.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(228, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mã xe";
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(545, 326);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 41);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(425, 326);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 41);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(305, 326);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 41);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXemGhe
            // 
            this.btnXemGhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemGhe.Location = new System.Drawing.Point(16, 108);
            this.btnXemGhe.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemGhe.Name = "btnXemGhe";
            this.btnXemGhe.Size = new System.Drawing.Size(115, 41);
            this.btnXemGhe.TabIndex = 2;
            this.btnXemGhe.Text = "Xem ghế";
            this.btnXemGhe.UseVisualStyleBackColor = true;
            this.btnXemGhe.Click += new System.EventHandler(this.btnXemGhe_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(465, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Loại xe";
            // 
            // cbbLoaiXeThem
            // 
            this.cbbLoaiXeThem.FormattingEnabled = true;
            this.cbbLoaiXeThem.Location = new System.Drawing.Point(545, 289);
            this.cbbLoaiXeThem.Margin = new System.Windows.Forms.Padding(4);
            this.cbbLoaiXeThem.Name = "cbbLoaiXeThem";
            this.cbbLoaiXeThem.Size = new System.Drawing.Size(173, 24);
            this.cbbLoaiXeThem.TabIndex = 6;
            // 
            // frm_QuanLyXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 382);
            this.Controls.Add(this.btnXemGhe);
            this.Controls.Add(this.cbbLoaiXeThem);
            this.Controls.Add(this.txtTenXe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoDangKy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaXe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbLoaiXe);
            this.Controls.Add(this.dgvDSXE);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_QuanLyXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_QuanLyXe";
            this.Load += new System.EventHandler(this.frm_QuanLyXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSXE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDSXE;
        private System.Windows.Forms.ComboBox cbbLoaiXe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenXe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoDangKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaXe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID_Xe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenLoaiXe;
        private System.Windows.Forms.Button btnXemGhe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbLoaiXeThem;
    }
}