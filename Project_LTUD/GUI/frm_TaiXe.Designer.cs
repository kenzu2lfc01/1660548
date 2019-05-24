namespace GUI
{
    partial class frm_TaiXe
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
            this.dgvTaiXe = new System.Windows.Forms.DataGridView();
            this.clmMaTaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenTaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBangLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaTaiXe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenTaiXe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBangLai = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTaiXe
            // 
            this.dgvTaiXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaTaiXe,
            this.clmTenTaiXe,
            this.clmBangLai});
            this.dgvTaiXe.Location = new System.Drawing.Point(16, 44);
            this.dgvTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTaiXe.Name = "dgvTaiXe";
            this.dgvTaiXe.Size = new System.Drawing.Size(620, 185);
            this.dgvTaiXe.TabIndex = 0;
            // 
            // clmMaTaiXe
            // 
            this.clmMaTaiXe.DataPropertyName = "ID_TaiXe";
            this.clmMaTaiXe.HeaderText = "Mã Tài Xế";
            this.clmMaTaiXe.Name = "clmMaTaiXe";
            this.clmMaTaiXe.Width = 120;
            // 
            // clmTenTaiXe
            // 
            this.clmTenTaiXe.DataPropertyName = "TenTaiXe";
            this.clmTenTaiXe.HeaderText = "Tên Tài Xế";
            this.clmTenTaiXe.Name = "clmTenTaiXe";
            this.clmTenTaiXe.Width = 180;
            // 
            // clmBangLai
            // 
            this.clmBangLai.DataPropertyName = "BangLai";
            this.clmBangLai.HeaderText = "Bằng Lái";
            this.clmBangLai.Name = "clmBangLai";
            this.clmBangLai.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ TÀI XẾ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 251);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã tài xế";
            // 
            // txtMaTaiXe
            // 
            this.txtMaTaiXe.Location = new System.Drawing.Point(117, 251);
            this.txtMaTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTaiXe.Name = "txtMaTaiXe";
            this.txtMaTaiXe.Size = new System.Drawing.Size(100, 22);
            this.txtMaTaiXe.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 283);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên tài xế";
            // 
            // txtTenTaiXe
            // 
            this.txtTenTaiXe.Location = new System.Drawing.Point(117, 283);
            this.txtTenTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenTaiXe.Name = "txtTenTaiXe";
            this.txtTenTaiXe.Size = new System.Drawing.Size(185, 22);
            this.txtTenTaiXe.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 315);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bằng lái";
            // 
            // txtBangLai
            // 
            this.txtBangLai.Location = new System.Drawing.Point(117, 315);
            this.txtBangLai.Margin = new System.Windows.Forms.Padding(4);
            this.txtBangLai.Name = "txtBangLai";
            this.txtBangLai.Size = new System.Drawing.Size(185, 22);
            this.txtBangLai.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(329, 240);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 43);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(441, 240);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 43);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(381, 290);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 43);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frm_TaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 363);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBangLai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenTaiXe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaTaiXe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTaiXe);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_TaiXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_TaiXe";
            this.Load += new System.EventHandler(this.frm_TaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaiXe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaTaiXe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenTaiXe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBangLai;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaTaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenTaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBangLai;
    }
}