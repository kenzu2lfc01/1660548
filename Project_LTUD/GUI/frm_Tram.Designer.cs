namespace GUI
{
    partial class frm_QLTramXe
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
            this.dgvTramXe = new System.Windows.Forms.DataGridView();
            this.clmMaTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiaDanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaTram = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaDanh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenTram = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramXe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý trạm xe";
            // 
            // dgvTramXe
            // 
            this.dgvTramXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTramXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaTram,
            this.clmTenTram,
            this.clmDiaDanh});
            this.dgvTramXe.Location = new System.Drawing.Point(4, 63);
            this.dgvTramXe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTramXe.Name = "dgvTramXe";
            this.dgvTramXe.Size = new System.Drawing.Size(725, 188);
            this.dgvTramXe.TabIndex = 1;
            // 
            // clmMaTram
            // 
            this.clmMaTram.DataPropertyName = "ID_Tram";
            this.clmMaTram.HeaderText = "Mã Trạm";
            this.clmMaTram.Name = "clmMaTram";
            // 
            // clmTenTram
            // 
            this.clmTenTram.DataPropertyName = "TenTram";
            this.clmTenTram.HeaderText = "Tên Trạm";
            this.clmTenTram.Name = "clmTenTram";
            this.clmTenTram.Width = 200;
            // 
            // clmDiaDanh
            // 
            this.clmDiaDanh.DataPropertyName = "Dia_Danh";
            this.clmDiaDanh.HeaderText = "Địa Danh";
            this.clmDiaDanh.Name = "clmDiaDanh";
            this.clmDiaDanh.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã trạm";
            // 
            // txtMaTram
            // 
            this.txtMaTram.Location = new System.Drawing.Point(109, 277);
            this.txtMaTram.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTram.Name = "txtMaTram";
            this.txtMaTram.Size = new System.Drawing.Size(87, 22);
            this.txtMaTram.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 342);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa danh";
            // 
            // txtDiaDanh
            // 
            this.txtDiaDanh.Location = new System.Drawing.Point(109, 341);
            this.txtDiaDanh.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiaDanh.Name = "txtDiaDanh";
            this.txtDiaDanh.Size = new System.Drawing.Size(200, 22);
            this.txtDiaDanh.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên trạm";
            // 
            // txtTenTram
            // 
            this.txtTenTram.Location = new System.Drawing.Point(109, 309);
            this.txtTenTram.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenTram.Name = "txtTenTram";
            this.txtTenTram.Size = new System.Drawing.Size(200, 22);
            this.txtTenTram.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(368, 277);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 41);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(527, 277);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 41);
            this.button2.TabIndex = 5;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(436, 325);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frm_QLTramXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTenTram);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiaDanh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaTram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTramXe);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_QLTramXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Trạm Xe";
            this.Load += new System.EventHandler(this.frm_ThemTram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTramXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaTram;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenTram;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiaDanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaTram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaDanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenTram;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}