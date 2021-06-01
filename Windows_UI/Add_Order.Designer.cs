namespace Windows_UI
{
    partial class Add_Order
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
            this.btn_new_order = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_save_order = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_sum_price = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_order_number = new System.Windows.Forms.Label();
            this.cmb_customers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Foods = new System.Windows.Forms.Panel();
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
            this.panel1.Size = new System.Drawing.Size(501, 749);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dt_gd_viw_orderlist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 178);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(501, 281);
            this.panel4.TabIndex = 6;
            // 
            // dt_gd_viw_orderlist
            // 
            this.dt_gd_viw_orderlist.AllowUserToAddRows = false;
            this.dt_gd_viw_orderlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gd_viw_orderlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_gd_viw_orderlist.Location = new System.Drawing.Point(0, 0);
            this.dt_gd_viw_orderlist.Name = "dt_gd_viw_orderlist";
            this.dt_gd_viw_orderlist.Size = new System.Drawing.Size(501, 281);
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
            this.panel3.Size = new System.Drawing.Size(501, 290);
            this.panel3.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_new_order);
            this.panel6.Controls.Add(this.btn_print);
            this.panel6.Controls.Add(this.btn_save_order);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 88);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(501, 202);
            this.panel6.TabIndex = 5;
            // 
            // btn_new_order
            // 
            this.btn_new_order.Location = new System.Drawing.Point(66, 86);
            this.btn_new_order.Name = "btn_new_order";
            this.btn_new_order.Size = new System.Drawing.Size(111, 47);
            this.btn_new_order.TabIndex = 2;
            this.btn_new_order.Text = "سفارش جدید";
            this.btn_new_order.UseVisualStyleBackColor = true;
            this.btn_new_order.Click += new System.EventHandler(this.btn_new_order_Click);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(199, 86);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(111, 47);
            this.btn_print.TabIndex = 1;
            this.btn_print.Text = "چاپ";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // btn_save_order
            // 
            this.btn_save_order.Location = new System.Drawing.Point(337, 86);
            this.btn_save_order.Name = "btn_save_order";
            this.btn_save_order.Size = new System.Drawing.Size(111, 47);
            this.btn_save_order.TabIndex = 0;
            this.btn_save_order.Text = "ذخیره";
            this.btn_save_order.UseVisualStyleBackColor = true;
            this.btn_save_order.Click += new System.EventHandler(this.btn_save_order_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.lbl_sum_price);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(501, 88);
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
            this.panel2.Controls.Add(this.lbl_order_number);
            this.panel2.Controls.Add(this.cmb_customers);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 178);
            this.panel2.TabIndex = 4;
            // 
            // lbl_order_number
            // 
            this.lbl_order_number.AutoSize = true;
            this.lbl_order_number.Font = new System.Drawing.Font("B Nazanin", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_order_number.Location = new System.Drawing.Point(239, 103);
            this.lbl_order_number.Name = "lbl_order_number";
            this.lbl_order_number.Size = new System.Drawing.Size(0, 51);
            this.lbl_order_number.TabIndex = 3;
            // 
            // cmb_customers
            // 
            this.cmb_customers.FormattingEnabled = true;
            this.cmb_customers.Location = new System.Drawing.Point(66, 53);
            this.cmb_customers.Name = "cmb_customers";
            this.cmb_customers.Size = new System.Drawing.Size(328, 32);
            this.cmb_customers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "مشخصات سفارش";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "مشتری :";
            // 
            // pnl_Foods
            // 
            this.pnl_Foods.AutoScroll = true;
            this.pnl_Foods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Foods.Location = new System.Drawing.Point(501, 0);
            this.pnl_Foods.Name = "pnl_Foods";
            this.pnl_Foods.Size = new System.Drawing.Size(832, 749);
            this.pnl_Foods.TabIndex = 1;
            // 
            // Add_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 749);
            this.Controls.Add(this.pnl_Foods);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Add_Order";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سفارش";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Order_Load);
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
        private System.Windows.Forms.Button btn_new_order;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_save_order;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_order_number;
    }
}