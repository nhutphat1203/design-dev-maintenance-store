namespace CuahangNongduoc
{
    partial class frmManage
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
            this.btnBussiness = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBussiness
            // 
            this.btnBussiness.Location = new System.Drawing.Point(116, 117);
            this.btnBussiness.Name = "btnBussiness";
            this.btnBussiness.Size = new System.Drawing.Size(209, 64);
            this.btnBussiness.TabIndex = 0;
            this.btnBussiness.Text = " Quản lý nghiệp vụ";
            this.btnBussiness.UseVisualStyleBackColor = true;
            this.btnBussiness.Click += new System.EventHandler(this.btnBussiness_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(116, 212);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(209, 64);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = " Quản lý người dùng";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // frmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 432);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnBussiness);
            this.Name = "frmManage";
            this.Text = "Tùy chọn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBussiness;
        private System.Windows.Forms.Button btnUser;
    }
}