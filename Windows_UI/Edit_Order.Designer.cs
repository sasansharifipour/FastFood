namespace Windows_UI
{
    partial class Edit_Order
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dt_gd_viw_orderlist = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_save_order = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_sum_price = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_search = new System.Windows.Forms.Button();
            this.dat_tim_picker_order_date = new Atf.UI.DateTimeSelector();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_order_number = new System.Windows.Forms.TextBox();
            this.cmb_customers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Foods = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_net_price = new System.Windows.Forms.Label();
            this.TB_discount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_orderlist)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 749);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dt_gd_viw_orderlist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 178);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(522, 281);
            this.panel4.TabIndex = 6;
            // 
            // dt_gd_viw_orderlist
            // 
            this.dt_gd_viw_orderlist.AllowUserToAddRows = false;
            this.dt_gd_viw_orderlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gd_viw_orderlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_gd_viw_orderlist.Location = new System.Drawing.Point(0, 0);
            this.dt_gd_viw_orderlist.Name = "dt_gd_viw_orderlist";
            this.dt_gd_viw_orderlist.Size = new System.Drawing.Size(522, 281);
            this.dt_gd_viw_orderlist.TabIndex = 3;
            this.dt_gd_viw_orderlist.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_gd_viw_orderlist_CellEndEdit);
            this.dt_gd_viw_orderlist.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dt_gd_viw_orderlist_CellParsing);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 459);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 290);
            this.panel3.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_delete);
            this.panel6.Controls.Add(this.btn_print);
            this.panel6.Controls.Add(this.btn_save_order);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 196);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(522, 94);
            this.panel6.TabIndex = 5;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(97, 31);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(111, 47);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "حذف سفارش";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_print
            // 
            this.btn_print.Enabled = false;
            this.btn_print.Location = new System.Drawing.Point(214, 31);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(111, 47);
            this.btn_print.TabIndex = 6;
            this.btn_print.Text = "چاپ";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_save_order
            // 
            this.btn_save_order.Location = new System.Drawing.Point(331, 31);
            this.btn_save_order.Name = "btn_save_order";
            this.btn_save_order.Size = new System.Drawing.Size(111, 47);
            this.btn_save_order.TabIndex = 5;
            this.btn_save_order.Text = "ذخیره";
            this.btn_save_order.UseVisualStyleBackColor = true;
            this.btn_save_order.Click += new System.EventHandler(this.btn_save_order_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.lbl_net_price);
            this.panel5.Controls.Add(this.TB_discount);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.lbl_sum_price);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(522, 196);
            this.panel5.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "جمع کل : ";
            // 
            // lbl_sum_price
            // 
            this.lbl_sum_price.AutoSize = true;
            this.lbl_sum_price.Location = new System.Drawing.Point(97, 38);
            this.lbl_sum_price.Name = "lbl_sum_price";
            this.lbl_sum_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_sum_price.Size = new System.Drawing.Size(0, 24);
            this.lbl_sum_price.TabIndex = 3;
            this.lbl_sum_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.dat_tim_picker_order_date);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_order_number);
            this.panel2.Controls.Add(this.cmb_customers);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 178);
            this.panel2.TabIndex = 4;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(48, 80);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 31);
            this.btn_search.TabIndex = 23;
            this.btn_search.Text = "جستجو";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dat_tim_picker_order_date
            // 
            this.dat_tim_picker_order_date.CustomFormat = "dddd dd MMMM ماه yyyy";
            this.dat_tim_picker_order_date.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.dat_tim_picker_order_date.Location = new System.Drawing.Point(186, 42);
            this.dat_tim_picker_order_date.Name = "dat_tim_picker_order_date";
            this.dat_tim_picker_order_date.Size = new System.Drawing.Size(219, 32);
            this.dat_tim_picker_order_date.TabIndex = 99;
            this.dat_tim_picker_order_date.UsePersianFormat = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 24);
            this.label4.TabIndex = 21;
            this.label4.Text = "انتخاب تاریخ : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "شماره سفارش : ";
            // 
            // txt_order_number
            // 
            this.txt_order_number.Location = new System.Drawing.Point(186, 80);
            this.txt_order_number.Name = "txt_order_number";
            this.txt_order_number.Size = new System.Drawing.Size(219, 31);
            this.txt_order_number.TabIndex = 1;
            this.txt_order_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_customers
            // 
            this.cmb_customers.FormattingEnabled = true;
            this.cmb_customers.Location = new System.Drawing.Point(27, 126);
            this.cmb_customers.Name = "cmb_customers";
            this.cmb_customers.Size = new System.Drawing.Size(378, 32);
            this.cmb_customers.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "مشخصات سفارش";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "مشتری :";
            // 
            // pnl_Foods
            // 
            this.pnl_Foods.AutoScroll = true;
            this.pnl_Foods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Foods.Location = new System.Drawing.Point(522, 0);
            this.pnl_Foods.Name = "pnl_Foods";
            this.pnl_Foods.Size = new System.Drawing.Size(811, 749);
            this.pnl_Foods.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "مبلغ قابل پرداخت : ";
            // 
            // lbl_net_price
            // 
            this.lbl_net_price.AutoSize = true;
            this.lbl_net_price.Location = new System.Drawing.Point(101, 121);
            this.lbl_net_price.Name = "lbl_net_price";
            this.lbl_net_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_net_price.Size = new System.Drawing.Size(0, 24);
            this.lbl_net_price.TabIndex = 11;
            this.lbl_net_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_discount
            // 
            this.TB_discount.Location = new System.Drawing.Point(101, 76);
            this.TB_discount.Name = "TB_discount";
            this.TB_discount.Size = new System.Drawing.Size(209, 31);
            this.TB_discount.TabIndex = 4;
            this.TB_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_discount.TextChanged += new System.EventHandler(this.TB_discount_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "تخفیف   :";
            // 
            // Edit_Order
            // 
            this.AcceptButton = this.btn_search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 749);
            this.Controls.Add(this.pnl_Foods);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Edit_Order";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سفارش";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_Order_FormClosing);
            this.Load += new System.EventHandler(this.Order_Load);
            this.Resize += new System.EventHandler(this.Add_Order_Resize);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_orderlist)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Foods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_customers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dt_gd_viw_orderlist;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_sum_price;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_save_order;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_delete;
        private Atf.UI.DateTimeSelector dat_tim_picker_order_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_order_number;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_net_price;
        private System.Windows.Forms.TextBox TB_discount;
        private System.Windows.Forms.Label label7;
    }
}