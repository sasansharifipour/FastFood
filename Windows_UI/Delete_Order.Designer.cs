namespace Windows_UI
{
    partial class Delete_Order
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_order_number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dat_tim_picker_order_date = new Atf.UI.DateTimeSelector();
            this.btn_print = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dt_gd_viw_orderlist = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_sum_price = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_order_status = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_customer_code = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_order_number = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_customer_name = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_orderlist)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "انتخاب تاریخ : ";
            // 
            // txt_order_number
            // 
            this.txt_order_number.Location = new System.Drawing.Point(68, 113);
            this.txt_order_number.Name = "txt_order_number";
            this.txt_order_number.Size = new System.Drawing.Size(219, 31);
            this.txt_order_number.TabIndex = 1;
            this.txt_order_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "شماره سفارش : ";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(275, 164);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 43);
            this.btn_search.TabIndex = 11;
            this.btn_search.Text = "جستجو";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(37, 164);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(115, 43);
            this.btn_delete.TabIndex = 12;
            this.btn_delete.Text = "حذف سفارش";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dat_tim_picker_order_date);
            this.panel1.Controls.Add(this.btn_print);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txt_order_number);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(429, 725);
            this.panel1.TabIndex = 13;
            // 
            // dat_tim_picker_order_date
            // 
            this.dat_tim_picker_order_date.CustomFormat = "dddd dd MMMM ماه yyyy";
            this.dat_tim_picker_order_date.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.dat_tim_picker_order_date.Location = new System.Drawing.Point(68, 75);
            this.dat_tim_picker_order_date.Name = "dat_tim_picker_order_date";
            this.dat_tim_picker_order_date.Size = new System.Drawing.Size(219, 32);
            this.dat_tim_picker_order_date.TabIndex = 18;
            this.dat_tim_picker_order_date.UsePersianFormat = true;
            // 
            // btn_print
            // 
            this.btn_print.Enabled = false;
            this.btn_print.Location = new System.Drawing.Point(158, 162);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(111, 47);
            this.btn_print.TabIndex = 1;
            this.btn_print.Text = "چاپ";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(429, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 725);
            this.panel2.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dt_gd_viw_orderlist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 207);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(655, 435);
            this.panel4.TabIndex = 6;
            // 
            // dt_gd_viw_orderlist
            // 
            this.dt_gd_viw_orderlist.AllowUserToAddRows = false;
            this.dt_gd_viw_orderlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gd_viw_orderlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_gd_viw_orderlist.Location = new System.Drawing.Point(0, 0);
            this.dt_gd_viw_orderlist.Name = "dt_gd_viw_orderlist";
            this.dt_gd_viw_orderlist.Size = new System.Drawing.Size(655, 435);
            this.dt_gd_viw_orderlist.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 642);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(655, 83);
            this.panel3.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.lbl_sum_price);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(655, 83);
            this.panel5.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "جمع کل : ";
            // 
            // lbl_sum_price
            // 
            this.lbl_sum_price.AutoSize = true;
            this.lbl_sum_price.Location = new System.Drawing.Point(97, 34);
            this.lbl_sum_price.Name = "lbl_sum_price";
            this.lbl_sum_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_sum_price.Size = new System.Drawing.Size(0, 24);
            this.lbl_sum_price.TabIndex = 3;
            this.lbl_sum_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.lbl_order_status);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.lbl_customer_code);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.lbl_time);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.lbl_date);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.lbl_order_number);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.lbl_customer_name);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(655, 207);
            this.panel7.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(238, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 24);
            this.label10.TabIndex = 13;
            this.label10.Text = "وضعیت سفارش :";
            // 
            // lbl_order_status
            // 
            this.lbl_order_status.AutoSize = true;
            this.lbl_order_status.Location = new System.Drawing.Point(63, 162);
            this.lbl_order_status.Name = "lbl_order_status";
            this.lbl_order_status.Size = new System.Drawing.Size(0, 24);
            this.lbl_order_status.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(525, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 24);
            this.label9.TabIndex = 11;
            this.label9.Text = "تاریخ  :";
            // 
            // lbl_customer_code
            // 
            this.lbl_customer_code.AutoSize = true;
            this.lbl_customer_code.Location = new System.Drawing.Point(336, 61);
            this.lbl_customer_code.Name = "lbl_customer_code";
            this.lbl_customer_code.Size = new System.Drawing.Size(0, 24);
            this.lbl_customer_code.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "ساعت :";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(63, 113);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(0, 24);
            this.lbl_time.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "نام مشتری :";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(336, 116);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(0, 24);
            this.lbl_date.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "شماره سفارش :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "کد مشتری :";
            // 
            // lbl_order_number
            // 
            this.lbl_order_number.AutoSize = true;
            this.lbl_order_number.Font = new System.Drawing.Font("B Nazanin", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_order_number.Location = new System.Drawing.Point(439, 148);
            this.lbl_order_number.Name = "lbl_order_number";
            this.lbl_order_number.Size = new System.Drawing.Size(0, 51);
            this.lbl_order_number.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "مشخصات سفارش";
            // 
            // lbl_customer_name
            // 
            this.lbl_customer_name.AutoSize = true;
            this.lbl_customer_name.Location = new System.Drawing.Point(63, 61);
            this.lbl_customer_name.Name = "lbl_customer_name";
            this.lbl_customer_name.Size = new System.Drawing.Size(0, 24);
            this.lbl_customer_name.TabIndex = 1;
            // 
            // Delete_Order
            // 
            this.AcceptButton = this.btn_search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 725);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Delete_Order";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ابطال سفارش";
            this.Load += new System.EventHandler(this.Delete_Order_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_orderlist)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_order_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dt_gd_viw_orderlist;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_sum_price;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbl_order_number;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_customer_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_customer_code;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_order_status;
        private Atf.UI.DateTimeSelector dat_tim_picker_order_date;
    }
}