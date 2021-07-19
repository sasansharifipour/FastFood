namespace Windows_UI
{
    partial class Add_FoodOption
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_foodoption_list = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txt_IfExist = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_IfNotExist = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chb_default_exist = new System.Windows.Forms.CheckBox();
            this.txt_percent_price = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام افزودنی محصول : ";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(167, 61);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(219, 31);
            this.txt_name.TabIndex = 1;
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(167, 231);
            this.txt_price.Name = "txt_price";
            this.txt_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_price.Size = new System.Drawing.Size(219, 31);
            this.txt_price.TabIndex = 5;
            this.txt_price.TextChanged += new System.EventHandler(this.txt_price_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "قیمت اگر اضافه شود : ";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(86, 320);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(108, 45);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "ثبت";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_currency_title
            // 
            this.lbl_currency_title.AutoSize = true;
            this.lbl_currency_title.Location = new System.Drawing.Point(403, 234);
            this.lbl_currency_title.Name = "lbl_currency_title";
            this.lbl_currency_title.Size = new System.Drawing.Size(0, 24);
            this.lbl_currency_title.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "انتخاب افزودنی محصول : ";
            // 
            // cmb_foodoption_list
            // 
            this.cmb_foodoption_list.FormattingEnabled = true;
            this.cmb_foodoption_list.Location = new System.Drawing.Point(167, 23);
            this.cmb_foodoption_list.Name = "cmb_foodoption_list";
            this.cmb_foodoption_list.Size = new System.Drawing.Size(219, 32);
            this.cmb_foodoption_list.TabIndex = 9;
            this.cmb_foodoption_list.SelectedIndexChanged += new System.EventHandler(this.cmb_food_list_SelectedIndexChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(317, 320);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(108, 45);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txt_IfExist
            // 
            this.txt_IfExist.Location = new System.Drawing.Point(167, 102);
            this.txt_IfExist.Name = "txt_IfExist";
            this.txt_IfExist.Size = new System.Drawing.Size(219, 31);
            this.txt_IfExist.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "عنوان اگر اضافه شود : ";
            // 
            // txt_IfNotExist
            // 
            this.txt_IfNotExist.Location = new System.Drawing.Point(167, 140);
            this.txt_IfNotExist.Name = "txt_IfNotExist";
            this.txt_IfNotExist.Size = new System.Drawing.Size(219, 31);
            this.txt_IfNotExist.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "عنوان اگر اضافه نشود : ";
            // 
            // chb_default_exist
            // 
            this.chb_default_exist.AutoSize = true;
            this.chb_default_exist.Location = new System.Drawing.Point(167, 187);
            this.chb_default_exist.Name = "chb_default_exist";
            this.chb_default_exist.Size = new System.Drawing.Size(136, 28);
            this.chb_default_exist.TabIndex = 4;
            this.chb_default_exist.Text = "پیش فرض اضافه شود";
            this.chb_default_exist.UseVisualStyleBackColor = true;
            // 
            // txt_percent_price
            // 
            this.txt_percent_price.Location = new System.Drawing.Point(167, 268);
            this.txt_percent_price.Name = "txt_percent_price";
            this.txt_percent_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_percent_price.Size = new System.Drawing.Size(219, 31);
            this.txt_percent_price.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "درصد قیمت اگر اضافه شود : ";
            // 
            // Add_FoodOption
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 418);
            this.Controls.Add(this.txt_percent_price);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chb_default_exist);
            this.Controls.Add(this.txt_IfNotExist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_IfExist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.cmb_foodoption_list);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_currency_title);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Add_FoodOption";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف افزودنی محصول";
            this.Load += new System.EventHandler(this.Add_FoodOption_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_foodoption_list;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_IfExist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_IfNotExist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chb_default_exist;
        private System.Windows.Forms.TextBox txt_percent_price;
        private System.Windows.Forms.Label label6;
    }
}