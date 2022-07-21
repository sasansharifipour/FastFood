namespace Windows_UI
{
    partial class Person_Debt
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
            this.cmb_customers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Payable_Amount = new System.Windows.Forms.Label();
            this.lbl_Paying_Amount = new System.Windows.Forms.Label();
            this.lbl_debt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_customers
            // 
            this.cmb_customers.FormattingEnabled = true;
            this.cmb_customers.Location = new System.Drawing.Point(151, 45);
            this.cmb_customers.Name = "cmb_customers";
            this.cmb_customers.Size = new System.Drawing.Size(275, 32);
            this.cmb_customers.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "مشتری :";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(479, 44);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 32);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "جستجو";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "مبلغ قابل پرداخت :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "مبلغ پرداختی :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "بدهی قابل پرداخت :";
            // 
            // lbl_Payable_Amount
            // 
            this.lbl_Payable_Amount.AutoSize = true;
            this.lbl_Payable_Amount.Location = new System.Drawing.Point(157, 100);
            this.lbl_Payable_Amount.Name = "lbl_Payable_Amount";
            this.lbl_Payable_Amount.Size = new System.Drawing.Size(0, 24);
            this.lbl_Payable_Amount.TabIndex = 10;
            // 
            // lbl_Paying_Amount
            // 
            this.lbl_Paying_Amount.AutoSize = true;
            this.lbl_Paying_Amount.Location = new System.Drawing.Point(157, 141);
            this.lbl_Paying_Amount.Name = "lbl_Paying_Amount";
            this.lbl_Paying_Amount.Size = new System.Drawing.Size(0, 24);
            this.lbl_Paying_Amount.TabIndex = 11;
            // 
            // lbl_debt
            // 
            this.lbl_debt.AutoSize = true;
            this.lbl_debt.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_debt.ForeColor = System.Drawing.Color.Red;
            this.lbl_debt.Location = new System.Drawing.Point(157, 185);
            this.lbl_debt.Name = "lbl_debt";
            this.lbl_debt.Size = new System.Drawing.Size(0, 31);
            this.lbl_debt.TabIndex = 13;
            // 
            // Person_Debt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 245);
            this.Controls.Add(this.lbl_debt);
            this.Controls.Add(this.lbl_Paying_Amount);
            this.Controls.Add(this.lbl_Payable_Amount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.cmb_customers);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Person_Debt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بدهی مشتریان";
            this.Load += new System.EventHandler(this.Person_Debt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_customers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Payable_Amount;
        private System.Windows.Forms.Label lbl_Paying_Amount;
        private System.Windows.Forms.Label lbl_debt;
    }
}