namespace DrawLuckyWheel
{
    partial class FormDangNhap
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labTaiKhoan = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.labMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 61);
            this.label1.TabIndex = 9;
            this.label1.Text = "GAME VÒNG QUAY MAY MẮN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrawLuckyWheel.Properties.Resources.anh;
            this.pictureBox1.Location = new System.Drawing.Point(309, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // labTaiKhoan
            // 
            this.labTaiKhoan.AutoSize = true;
            this.labTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTaiKhoan.Location = new System.Drawing.Point(24, 297);
            this.labTaiKhoan.Name = "labTaiKhoan";
            this.labTaiKhoan.Size = new System.Drawing.Size(130, 25);
            this.labTaiKhoan.TabIndex = 11;
            this.labTaiKhoan.Text = "TÀI KHOẢN";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(195, 290);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(451, 36);
            this.txtTaiKhoan.TabIndex = 15;
            // 
            // labMatKhau
            // 
            this.labMatKhau.AutoSize = true;
            this.labMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMatKhau.Location = new System.Drawing.Point(29, 376);
            this.labMatKhau.Name = "labMatKhau";
            this.labMatKhau.Size = new System.Drawing.Size(125, 25);
            this.labMatKhau.TabIndex = 16;
            this.labMatKhau.Text = "MẬT KHẨU";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(195, 369);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(451, 36);
            this.txtMatKhau.TabIndex = 17;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(195, 448);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(161, 64);
            this.btnDangNhap.TabIndex = 18;
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(500, 448);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(146, 64);
            this.btnThoat.TabIndex = 19;
            this.btnThoat.Text = "HỦY";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.labMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.labTaiKhoan);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormDangNhap";
            this.Text = "FormDangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labTaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label labMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
    }
}