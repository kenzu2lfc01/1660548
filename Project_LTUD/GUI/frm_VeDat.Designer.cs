namespace GUI
{
    partial class frm_VeDat
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
            this.label11 = new System.Windows.Forms.Label();
            this.dgvVeDat = new System.Windows.Forms.DataGridView();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGiaTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbChonGhe = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtSoGhe = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDong = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCot = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTang = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtIDGhe = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeDat)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbChonGhe.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(413, 11);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(252, 31);
            this.label11.TabIndex = 30;
            this.label11.Text = "QUẢN LÝ VÉ ĐẶT";
            // 
            // dgvVeDat
            // 
            this.dgvVeDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeDat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmTramDi,
            this.clmTramDen,
            this.clmSoGhe,
            this.clmGiaTien,
            this.clmTenXe,
            this.clmTenLoai,
            this.clmTinhTrang,
            this.clmGhiChu});
            this.dgvVeDat.Location = new System.Drawing.Point(16, 47);
            this.dgvVeDat.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVeDat.Name = "dgvVeDat";
            this.dgvVeDat.Size = new System.Drawing.Size(1224, 185);
            this.dgvVeDat.TabIndex = 31;
            this.dgvVeDat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVeDat_CellClick);
            // 
            // clmID
            // 
            this.clmID.DataPropertyName = "ID_Ve";
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.Width = 40;
            // 
            // clmTramDi
            // 
            this.clmTramDi.DataPropertyName = "TramDi";
            this.clmTramDi.HeaderText = "Trạm đi";
            this.clmTramDi.Name = "clmTramDi";
            // 
            // clmTramDen
            // 
            this.clmTramDen.DataPropertyName = "TramDen";
            this.clmTramDen.HeaderText = "Trạm đến";
            this.clmTramDen.Name = "clmTramDen";
            // 
            // clmSoGhe
            // 
            this.clmSoGhe.DataPropertyName = "SoGhe";
            this.clmSoGhe.HeaderText = "Số ghế";
            this.clmSoGhe.Name = "clmSoGhe";
            // 
            // clmGiaTien
            // 
            this.clmGiaTien.DataPropertyName = "GiaTien";
            this.clmGiaTien.HeaderText = "Giá tiền";
            this.clmGiaTien.Name = "clmGiaTien";
            // 
            // clmTenXe
            // 
            this.clmTenXe.DataPropertyName = "TenXe";
            this.clmTenXe.HeaderText = "Tên xe";
            this.clmTenXe.Name = "clmTenXe";
            // 
            // clmTenLoai
            // 
            this.clmTenLoai.DataPropertyName = "TenLoai";
            this.clmTenLoai.HeaderText = "Tên loại";
            this.clmTenLoai.Name = "clmTenLoai";
            // 
            // clmTinhTrang
            // 
            this.clmTinhTrang.DataPropertyName = "TinhTrang";
            this.clmTinhTrang.HeaderText = "Tình trạng";
            this.clmTinhTrang.Name = "clmTinhTrang";
            // 
            // clmGhiChu
            // 
            this.clmGhiChu.DataPropertyName = "GhiChu";
            this.clmGhiChu.HeaderText = "Ghi chú";
            this.clmGhiChu.Name = "clmGhiChu";
            this.clmGhiChu.Width = 130;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSoDienThoai);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(31, 272);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(336, 126);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(123, 92);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(109, 60);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(197, 22);
            this.txtSoDienThoai.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số điện thoại";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(109, 32);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(197, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên";
            // 
            // grbChonGhe
            // 
            this.grbChonGhe.Controls.Add(this.button3);
            this.grbChonGhe.Controls.Add(this.txtSoGhe);
            this.grbChonGhe.Controls.Add(this.label21);
            this.grbChonGhe.Controls.Add(this.txtDong);
            this.grbChonGhe.Controls.Add(this.label20);
            this.grbChonGhe.Controls.Add(this.txtCot);
            this.grbChonGhe.Controls.Add(this.label19);
            this.grbChonGhe.Controls.Add(this.txtTang);
            this.grbChonGhe.Controls.Add(this.label18);
            this.grbChonGhe.Controls.Add(this.txtIDGhe);
            this.grbChonGhe.Controls.Add(this.label17);
            this.grbChonGhe.Location = new System.Drawing.Point(388, 251);
            this.grbChonGhe.Margin = new System.Windows.Forms.Padding(4);
            this.grbChonGhe.Name = "grbChonGhe";
            this.grbChonGhe.Padding = new System.Windows.Forms.Padding(4);
            this.grbChonGhe.Size = new System.Drawing.Size(304, 146);
            this.grbChonGhe.TabIndex = 33;
            this.grbChonGhe.TabStop = false;
            this.grbChonGhe.Text = "Chọn ghế";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(107, 114);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Thay đổi";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtSoGhe
            // 
            this.txtSoGhe.Location = new System.Drawing.Point(65, 84);
            this.txtSoGhe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoGhe.Name = "txtSoGhe";
            this.txtSoGhe.ReadOnly = true;
            this.txtSoGhe.Size = new System.Drawing.Size(73, 22);
            this.txtSoGhe.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 86);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 17);
            this.label21.TabIndex = 0;
            this.label21.Text = "Số ghế";
            // 
            // txtDong
            // 
            this.txtDong.Location = new System.Drawing.Point(192, 57);
            this.txtDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDong.Name = "txtDong";
            this.txtDong.ReadOnly = true;
            this.txtDong.Size = new System.Drawing.Size(73, 22);
            this.txtDong.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(144, 59);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Dòng";
            // 
            // txtCot
            // 
            this.txtCot.Location = new System.Drawing.Point(192, 26);
            this.txtCot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCot.Name = "txtCot";
            this.txtCot.ReadOnly = true;
            this.txtCot.Size = new System.Drawing.Size(73, 22);
            this.txtCot.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(144, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 17);
            this.label19.TabIndex = 0;
            this.label19.Text = "Cột";
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(65, 57);
            this.txtTang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTang.Name = "txtTang";
            this.txtTang.ReadOnly = true;
            this.txtTang.Size = new System.Drawing.Size(73, 22);
            this.txtTang.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "Tầng";
            // 
            // txtIDGhe
            // 
            this.txtIDGhe.Location = new System.Drawing.Point(65, 26);
            this.txtIDGhe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDGhe.Name = "txtIDGhe";
            this.txtIDGhe.ReadOnly = true;
            this.txtIDGhe.Size = new System.Drawing.Size(73, 22);
            this.txtIDGhe.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "ID";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(107, 58);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(12, 17);
            this.lblSoLuong.TabIndex = 0;
            this.lblSoLuong.Text = ".";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "Số lượng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTongTien);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lblSoLuong);
            this.groupBox2.Location = new System.Drawing.Point(713, 266);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(272, 132);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thanh toán";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 85);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "Báo cáo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 85);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Thanh toán";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tổng tiền";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(107, 27);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(12, 17);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = ".";
            // 
            // frm_VeDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 412);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbChonGhe);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvVeDat);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_VeDat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_VeDat";
            this.Load += new System.EventHandler(this.frm_VeDat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeDat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbChonGhe.ResumeLayout(false);
            this.grbChonGhe.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvVeDat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGiaTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGhiChu;
        private System.Windows.Forms.GroupBox grbChonGhe;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtSoGhe;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCot;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtIDGhe;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongTien;
    }
}