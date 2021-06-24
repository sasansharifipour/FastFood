namespace Windows_UI
{
    partial class Loggin_Form
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
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this._thePanel = new System.Windows.Forms.Panel();
            this._thePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(49, 53);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_password.Size = new System.Drawing.Size(309, 31);
            this.txt_password.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 60);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "کلمه عبور :";
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(49, 16);
            this.txt_code.Name = "txt_code";
            this.txt_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_code.Size = new System.Drawing.Size(309, 31);
            this.txt_code.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(250, 90);
            this.btn_login.Name = "btn_login";
            this.btn_login.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_login.Size = new System.Drawing.Size(108, 45);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "ورود به نرم افزار";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 19);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "کد کاربر  : ";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(49, 90);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_exit.Size = new System.Drawing.Size(108, 45);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "خروج از نرم افزار";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // _thePanel
            // 
            this._thePanel.Controls.Add(this.btn_login);
            this._thePanel.Controls.Add(this.label4);
            this._thePanel.Controls.Add(this.label5);
            this._thePanel.Controls.Add(this.btn_exit);
            this._thePanel.Controls.Add(this.txt_code);
            this._thePanel.Controls.Add(this.txt_password);
            this._thePanel.Location = new System.Drawing.Point(12, 12);
            this._thePanel.Name = "_thePanel";
            this._thePanel.Size = new System.Drawing.Size(470, 160);
            this._thePanel.TabIndex = 23;
            // 
            // Loggin_Form
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 184);
            this.Controls.Add(this._thePanel);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Loggin_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود به نرم افزار";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResizeEnd += new System.EventHandler(this.Loggin_Form_ResizeEnd);
            this._thePanel.ResumeLayout(false);
            this._thePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel _thePanel;
    }
}