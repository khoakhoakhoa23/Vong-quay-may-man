namespace DrawLuckyWheel
{
    partial class FormVongQuay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVongQuay));
            this.btnPlay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.Green;
            this.btnPlay.Location = new System.Drawing.Point(835, 319);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(267, 162);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(928, 207);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 53);
            this.label1.TabIndex = 2;
            this.label1.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(835, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Result:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(839, 526);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(263, 22);
            this.textBoxNumber.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(900, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 37);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add number";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(412, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(502, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 17;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(900, 710);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(137, 37);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(900, 648);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(137, 37);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DrawLuckyWheel.Properties.Resources.placeholder;
            this.pictureBox2.Location = new System.Drawing.Point(336, 75);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(-126, -44);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(878, 771);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(189, 37);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormVongQuay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 820);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormVongQuay";
            this.Text = "[C#] Lucky Game - https://laptrinhvb.net";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExit;
    }
}

