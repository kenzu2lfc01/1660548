namespace GUI
{
    partial class frm_QuanLyTuyen
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
            this.label9 = new System.Windows.Forms.Label();
            this.cbbTenTram1 = new System.Windows.Forms.ComboBox();
            this.cbbTenTram2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThoiGianChay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKhoangCach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaTuyen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbTenTram = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTuyenXe = new System.Windows.Forms.DataGridView();
            this.clmMaTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKhoangCach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmThoiGianChay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTram1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTram2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbMonth = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaChuyen = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyenXe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(559, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(270, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "QUẢN LÝ TUYẾN XE";
            // 
            // cbbTenTram1
            // 
            this.cbbTenTram1.FormattingEnabled = true;
            this.cbbTenTram1.Location = new System.Drawing.Point(236, 375);
            this.cbbTenTram1.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTenTram1.Name = "cbbTenTram1";
            this.cbbTenTram1.Size = new System.Drawing.Size(243, 24);
            this.cbbTenTram1.TabIndex = 5;
            this.cbbTenTram1.SelectedIndexChanged += new System.EventHandler(this.cbbTenTram1_SelectedIndexChanged_2);
            // 
            // cbbTenTram2
            // 
            this.cbbTenTram2.FormattingEnabled = true;
            this.cbbTenTram2.Location = new System.Drawing.Point(488, 375);
            this.cbbTenTram2.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTenTram2.Name = "cbbTenTram2";
            this.cbbTenTram2.Size = new System.Drawing.Size(225, 24);
            this.cbbTenTram2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(793, 358);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(460, 43);
            this.button1.TabIndex = 10;
            this.button1.Text = "Quản Lý Trạm Xe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(1105, 300);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(148, 49);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(949, 300);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 49);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(793, 300);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 49);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(723, 326);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tiếng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(525, 326);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Km";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(484, 353);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tên trạm 2";
            // 
            // txtThoiGianChay
            // 
            this.txtThoiGianChay.Location = new System.Drawing.Point(565, 322);
            this.txtThoiGianChay.Margin = new System.Windows.Forms.Padding(4);
            this.txtThoiGianChay.Name = "txtThoiGianChay";
            this.txtThoiGianChay.Size = new System.Drawing.Size(148, 22);
            this.txtThoiGianChay.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(561, 298);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Thời gian chạy";
            // 
            // txtKhoangCach
            // 
            this.txtKhoangCach.Location = new System.Drawing.Point(365, 322);
            this.txtKhoangCach.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhoangCach.Name = "txtKhoangCach";
            this.txtKhoangCach.Size = new System.Drawing.Size(151, 22);
            this.txtKhoangCach.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 298);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Khoảng cách";
            // 
            // txtMaTuyen
            // 
            this.txtMaTuyen.Location = new System.Drawing.Point(236, 322);
            this.txtMaTuyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTuyen.Name = "txtMaTuyen";
            this.txtMaTuyen.Size = new System.Drawing.Size(111, 22);
            this.txtMaTuyen.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(232, 298);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mã tuyến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 351);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên trạm 1";
            // 
            // cbbTenTram
            // 
            this.cbbTenTram.FormattingEnabled = true;
            this.cbbTenTram.Location = new System.Drawing.Point(8, 76);
            this.cbbTenTram.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTenTram.Name = "cbbTenTram";
            this.cbbTenTram.Size = new System.Drawing.Size(180, 24);
            this.cbbTenTram.TabIndex = 1;
            this.cbbTenTram.SelectedIndexChanged += new System.EventHandler(this.cbbTenTram_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên trạm";
            // 
            // dgvTuyenXe
            // 
            this.dgvTuyenXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTuyenXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaTuyen,
            this.clmKhoangCach,
            this.clmThoiGianChay,
            this.clmTram1,
            this.clmTram2});
            this.dgvTuyenXe.Location = new System.Drawing.Point(235, 52);
            this.dgvTuyenXe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTuyenXe.Name = "dgvTuyenXe";
            this.dgvTuyenXe.Size = new System.Drawing.Size(1017, 241);
            this.dgvTuyenXe.TabIndex = 9;
            this.dgvTuyenXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTuyenXe_CellClick);
            // 
            // clmMaTuyen
            // 
            this.clmMaTuyen.DataPropertyName = "ID_Tuyen";
            this.clmMaTuyen.HeaderText = "Mã Tuyến";
            this.clmMaTuyen.Name = "clmMaTuyen";
            // 
            // clmKhoangCach
            // 
            this.clmKhoangCach.DataPropertyName = "KhoangCach";
            this.clmKhoangCach.HeaderText = "Khoảng Cách (km)";
            this.clmKhoangCach.Name = "clmKhoangCach";
            this.clmKhoangCach.Width = 120;
            // 
            // clmThoiGianChay
            // 
            this.clmThoiGianChay.DataPropertyName = "ThoiGianChay";
            this.clmThoiGianChay.HeaderText = "Thời Gian Chạy (tiếng)";
            this.clmThoiGianChay.Name = "clmThoiGianChay";
            this.clmThoiGianChay.Width = 140;
            // 
            // clmTram1
            // 
            this.clmTram1.DataPropertyName = "TenTram1";
            this.clmTram1.HeaderText = "Tên Trạm 1";
            this.clmTram1.Name = "clmTram1";
            this.clmTram1.Width = 180;
            // 
            // clmTram2
            // 
            this.clmTram2.DataPropertyName = "TenTram2";
            this.clmTram2.HeaderText = "Tên Trạm 2";
            this.clmTram2.Name = "clmTram2";
            this.clmTram2.Width = 180;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbMonth);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtMaChuyen);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Location = new System.Drawing.Point(8, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 128);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo cáo chuyến";
            // 
            // cbbMonth
            // 
            this.cbbMonth.FormattingEnabled = true;
            this.cbbMonth.Location = new System.Drawing.Point(89, 53);
            this.cbbMonth.Name = "cbbMonth";
            this.cbbMonth.Size = new System.Drawing.Size(66, 24);
            this.cbbMonth.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "Tháng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Mã tuyến";
            // 
            // txtMaChuyen
            // 
            this.txtMaChuyen.Location = new System.Drawing.Point(89, 23);
            this.txtMaChuyen.Name = "txtMaChuyen";
            this.txtMaChuyen.ReadOnly = true;
            this.txtMaChuyen.Size = new System.Drawing.Size(83, 22);
            this.txtMaChuyen.TabIndex = 4;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(55, 84);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 34);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frm_QuanLyTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 423);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbbTenTram1);
            this.Controls.Add(this.cbbTenTram2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtThoiGianChay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKhoangCach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaTuyen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbTenTram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTuyenXe);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_QuanLyTuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_QuanLyTuyen";
            this.Load += new System.EventHandler(this.frm_QuanLyTuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyenXe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbTenTram1;
        private System.Windows.Forms.ComboBox cbbTenTram2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThoiGianChay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKhoangCach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaTuyen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbTenTram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTuyenXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKhoangCach;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmThoiGianChay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTram1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTram2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbMonth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaChuyen;
        private System.Windows.Forms.Button btnReport;
    }
}