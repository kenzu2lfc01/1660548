namespace GUI
{
    partial class frm_Ghe
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
            this.dgvGhe = new System.Windows.Forms.DataGridView();
            this.clmMaGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbTenXe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGhe
            // 
            this.dgvGhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGhe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaGhe,
            this.clmDong,
            this.clmCot,
            this.clmTang,
            this.clmSoGhe,
            this.clmTenXe});
            this.dgvGhe.Location = new System.Drawing.Point(197, 58);
            this.dgvGhe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGhe.Name = "dgvGhe";
            this.dgvGhe.Size = new System.Drawing.Size(927, 343);
            this.dgvGhe.TabIndex = 0;
            // 
            // clmMaGhe
            // 
            this.clmMaGhe.DataPropertyName = "ID_Ghe";
            this.clmMaGhe.HeaderText = "Mã ghế";
            this.clmMaGhe.Name = "clmMaGhe";
            // 
            // clmDong
            // 
            this.clmDong.DataPropertyName = "Dong";
            this.clmDong.HeaderText = "Dòng";
            this.clmDong.Name = "clmDong";
            // 
            // clmCot
            // 
            this.clmCot.DataPropertyName = "Cot";
            this.clmCot.HeaderText = "Cột";
            this.clmCot.Name = "clmCot";
            // 
            // clmTang
            // 
            this.clmTang.DataPropertyName = "Tang";
            this.clmTang.HeaderText = "Tầng";
            this.clmTang.Name = "clmTang";
            // 
            // clmSoGhe
            // 
            this.clmSoGhe.DataPropertyName = "So_Ghe";
            this.clmSoGhe.HeaderText = "Số ghế";
            this.clmSoGhe.Name = "clmSoGhe";
            // 
            // clmTenXe
            // 
            this.clmTenXe.DataPropertyName = "TenXe";
            this.clmTenXe.HeaderText = "Tên xe";
            this.clmTenXe.Name = "clmTenXe";
            this.clmTenXe.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên xe";
            // 
            // cbbTenXe
            // 
            this.cbbTenXe.FormattingEnabled = true;
            this.cbbTenXe.Location = new System.Drawing.Point(16, 82);
            this.cbbTenXe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbTenXe.Name = "cbbTenXe";
            this.cbbTenXe.Size = new System.Drawing.Size(172, 24);
            this.cbbTenXe.TabIndex = 1;
            this.cbbTenXe.SelectedIndexChanged += new System.EventHandler(this.cbbTenXe_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(557, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // frm_Ghe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 418);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbTenXe);
            this.Controls.Add(this.dgvGhe);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_Ghe";
            this.Text = "frm_Ghe";
            this.Load += new System.EventHandler(this.frm_Ghe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGhe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbTenXe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenXe;
        private System.Windows.Forms.Label label3;
    }
}