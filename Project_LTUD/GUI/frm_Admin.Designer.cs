namespace GUI
{
    partial class frm_Admin
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxQLChuyen = new System.Windows.Forms.CheckBox();
            this.cbxQLKhach = new System.Windows.Forms.CheckBox();
            this.cbxQLXe = new System.Windows.Forms.CheckBox();
            this.cbxQLTuyen = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxQLDatBanVe = new System.Windows.Forms.CheckBox();
            this.cbxQLTaiXe = new System.Windows.Forms.CheckBox();
            this.clmUsersID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreatedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsvQuyen = new System.Windows.Forms.ListView();
            this.columnQuyen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUsersID,
            this.clmPassword,
            this.clmEmail,
            this.clmCreatedate});
            this.dgvUsers.Location = new System.Drawing.Point(12, 12);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(751, 271);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(156, 21);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(176, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(156, 49);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(176, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(156, 77);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(176, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(349, 417);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 49);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(438, 417);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 49);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(527, 417);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 49);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(120, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 114);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin người dùng";
            // 
            // cbxQLChuyen
            // 
            this.cbxQLChuyen.AutoSize = true;
            this.cbxQLChuyen.Location = new System.Drawing.Point(30, 23);
            this.cbxQLChuyen.Name = "cbxQLChuyen";
            this.cbxQLChuyen.Size = new System.Drawing.Size(147, 21);
            this.cbxQLChuyen.TabIndex = 3;
            this.cbxQLChuyen.Text = "Quản lý chuyến xe";
            this.cbxQLChuyen.UseVisualStyleBackColor = true;
            // 
            // cbxQLKhach
            // 
            this.cbxQLKhach.AutoSize = true;
            this.cbxQLKhach.Location = new System.Drawing.Point(30, 52);
            this.cbxQLKhach.Name = "cbxQLKhach";
            this.cbxQLKhach.Size = new System.Drawing.Size(157, 21);
            this.cbxQLKhach.TabIndex = 3;
            this.cbxQLKhach.Text = "Quản lý khách hàng";
            this.cbxQLKhach.UseVisualStyleBackColor = true;
            // 
            // cbxQLXe
            // 
            this.cbxQLXe.AutoSize = true;
            this.cbxQLXe.Location = new System.Drawing.Point(30, 80);
            this.cbxQLXe.Name = "cbxQLXe";
            this.cbxQLXe.Size = new System.Drawing.Size(97, 21);
            this.cbxQLXe.TabIndex = 3;
            this.cbxQLXe.Text = "Quản lý xe";
            this.cbxQLXe.UseVisualStyleBackColor = true;
            // 
            // cbxQLTuyen
            // 
            this.cbxQLTuyen.AutoSize = true;
            this.cbxQLTuyen.Location = new System.Drawing.Point(214, 24);
            this.cbxQLTuyen.Name = "cbxQLTuyen";
            this.cbxQLTuyen.Size = new System.Drawing.Size(136, 21);
            this.cbxQLTuyen.TabIndex = 3;
            this.cbxQLTuyen.Text = "Quản lý tuyến xe";
            this.cbxQLTuyen.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxQLTaiXe);
            this.groupBox2.Controls.Add(this.cbxQLKhach);
            this.groupBox2.Controls.Add(this.cbxQLTuyen);
            this.groupBox2.Controls.Add(this.cbxQLDatBanVe);
            this.groupBox2.Controls.Add(this.cbxQLChuyen);
            this.groupBox2.Controls.Add(this.cbxQLXe);
            this.groupBox2.Location = new System.Drawing.Point(481, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 114);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phân quyền";
            // 
            // cbxQLDatBanVe
            // 
            this.cbxQLDatBanVe.AutoSize = true;
            this.cbxQLDatBanVe.Location = new System.Drawing.Point(214, 80);
            this.cbxQLDatBanVe.Name = "cbxQLDatBanVe";
            this.cbxQLDatBanVe.Size = new System.Drawing.Size(150, 21);
            this.cbxQLDatBanVe.TabIndex = 3;
            this.cbxQLDatBanVe.Text = "Quản lý đặt bán vé";
            this.cbxQLDatBanVe.UseVisualStyleBackColor = true;
            // 
            // cbxQLTaiXe
            // 
            this.cbxQLTaiXe.AutoSize = true;
            this.cbxQLTaiXe.Location = new System.Drawing.Point(214, 52);
            this.cbxQLTaiXe.Name = "cbxQLTaiXe";
            this.cbxQLTaiXe.Size = new System.Drawing.Size(116, 21);
            this.cbxQLTaiXe.TabIndex = 3;
            this.cbxQLTaiXe.Text = "Quản lý tài xế";
            this.cbxQLTaiXe.UseVisualStyleBackColor = true;
            // 
            // clmUsersID
            // 
            this.clmUsersID.DataPropertyName = "UserID";
            this.clmUsersID.HeaderText = "Tên đăng nhập";
            this.clmUsersID.Name = "clmUsersID";
            this.clmUsersID.Width = 140;
            // 
            // clmPassword
            // 
            this.clmPassword.DataPropertyName = "Password";
            this.clmPassword.HeaderText = "Mật khẩu";
            this.clmPassword.Name = "clmPassword";
            this.clmPassword.Width = 120;
            // 
            // clmEmail
            // 
            this.clmEmail.DataPropertyName = "Email";
            this.clmEmail.HeaderText = "Email";
            this.clmEmail.Name = "clmEmail";
            this.clmEmail.Width = 130;
            // 
            // clmCreatedate
            // 
            this.clmCreatedate.DataPropertyName = "CreateDate";
            this.clmCreatedate.HeaderText = "Ngày khởi tạo";
            this.clmCreatedate.Name = "clmCreatedate";
            this.clmCreatedate.Width = 140;
            // 
            // lsvQuyen
            // 
            this.lsvQuyen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnQuyen});
            this.lsvQuyen.Location = new System.Drawing.Point(769, 12);
            this.lsvQuyen.Name = "lsvQuyen";
            this.lsvQuyen.Size = new System.Drawing.Size(207, 271);
            this.lsvQuyen.TabIndex = 6;
            this.lsvQuyen.UseCompatibleStateImageBehavior = false;
            this.lsvQuyen.View = System.Windows.Forms.View.Details;
            // 
            // columnQuyen
            // 
            this.columnQuyen.Text = "Quyền";
            this.columnQuyen.Width = 180;
            // 
            // frm_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 479);
            this.Controls.Add(this.lsvQuyen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvUsers);
            this.Name = "frm_Admin";
            this.Text = "frm_Admin";
            this.Load += new System.EventHandler(this.frm_Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox cbxQLChuyen;
        private System.Windows.Forms.CheckBox cbxQLKhach;
        private System.Windows.Forms.CheckBox cbxQLXe;
        private System.Windows.Forms.CheckBox cbxQLTuyen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxQLTaiXe;
        private System.Windows.Forms.CheckBox cbxQLDatBanVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUsersID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreatedate;
        private System.Windows.Forms.ListView lsvQuyen;
        private System.Windows.Forms.ColumnHeader columnQuyen;
    }
}