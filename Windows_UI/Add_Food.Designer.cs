namespace Windows_UI
{
    partial class Add_Food
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
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_currency_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام محصول : ";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(125, 34);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(219, 31);
            this.txt_name.TabIndex = 1;
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(125, 77);
            this.txt_price.Name = "txt_price";
            this.txt_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_price.Size = new System.Drawing.Size(219, 31);
            this.txt_price.TabIndex = 3;
            this.txt_price.TextChanged += new System.EventHandler(this.txt_price_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "قیمت محصول : ";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(151, 172);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(108, 45);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "ثبت";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_currency_title
            // 
            this.lbl_currency_title.AutoSize = true;
            this.lbl_currency_title.Location = new System.Drawing.Point(361, 80);
            this.lbl_currency_title.Name = "lbl_currency_title";
            this.lbl_currency_title.Size = new System.Drawing.Size(0, 24);
            this.lbl_currency_title.TabIndex = 5;
            // 
            // Add_Food
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 281);
            this.Controls.Add(this.lbl_currency_title);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Add_Food";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف محصول";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_currency_title;
    }
}