﻿namespace Windows_UI
{
    partial class Add_User
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
            this.cmb_data_list = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_family = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chb_Is_Admin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmb_data_list
            // 
            this.cmb_data_list.FormattingEnabled = true;
            this.cmb_data_list.Location = new System.Drawing.Point(132, 34);
            this.cmb_data_list.Name = "cmb_data_list";
            this.cmb_data_list.Size = new System.Drawing.Size(309, 32);
            this.cmb_data_list.TabIndex = 6;
            this.cmb_data_list.SelectedIndexChanged += new System.EventHandler(this.cmb_customer_list_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "انتخاب کاربر : ";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(132, 220);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(108, 45);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "ثبت";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "نام خانوادگی : ";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(132, 109);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(309, 31);
            this.txt_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام  : ";
            // 
            // txt_family
            // 
            this.txt_family.Location = new System.Drawing.Point(132, 146);
            this.txt_family.Name = "txt_family";
            this.txt_family.Size = new System.Drawing.Size(309, 31);
            this.txt_family.TabIndex = 2;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(132, 183);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_password.Size = new System.Drawing.Size(309, 31);
            this.txt_password.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "کلمه عبور :";
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(333, 220);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(108, 45);
            this.btn_delete.TabIndex = 20;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txt_code
            // 
            this.txt_code.Enabled = false;
            this.txt_code.Location = new System.Drawing.Point(132, 72);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(309, 31);
            this.txt_code.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "کد کاربر  : ";
            // 
            // chb_Is_Admin
            // 
            this.chb_Is_Admin.AutoSize = true;
            this.chb_Is_Admin.Location = new System.Drawing.Point(468, 36);
            this.chb_Is_Admin.Name = "chb_Is_Admin";
            this.chb_Is_Admin.Size = new System.Drawing.Size(80, 28);
            this.chb_Is_Admin.TabIndex = 23;
            this.chb_Is_Admin.Text = "کاربر مدیر";
            this.chb_Is_Admin.UseVisualStyleBackColor = true;
            // 
            // Add_User
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 326);
            this.Controls.Add(this.chb_Is_Admin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_family);
            this.Controls.Add(this.cmb_data_list);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Add_User";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کاربران";
            this.Load += new System.EventHandler(this.Add_Customer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_data_list;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_family;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chb_Is_Admin;
    }
}