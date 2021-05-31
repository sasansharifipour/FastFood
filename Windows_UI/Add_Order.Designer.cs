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
            this.dt_gd_viw_orderlist = new System.Windows.Forms.DataGridView();
            this.cmb_customers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Foods = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_orderlist)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.dt_gd_viw_orderlist);
            this.panel1.Controls.Add(this.cmb_customers);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 830);
            this.panel1.TabIndex = 0;
            // 
            // dt_gd_viw_orderlist
            // 
            this.dt_gd_viw_orderlist.AllowUserToAddRows = false;
            this.dt_gd_viw_orderlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gd_viw_orderlist.Location = new System.Drawing.Point(6, 129);
            this.dt_gd_viw_orderlist.Name = "dt_gd_viw_orderlist";
            this.dt_gd_viw_orderlist.Size = new System.Drawing.Size(474, 411);
            this.dt_gd_viw_orderlist.TabIndex = 3;
            this.dt_gd_viw_orderlist.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dt_gd_viw_orderlist_CellParsing);
            // 
            // cmb_customers
            // 
            this.cmb_customers.FormattingEnabled = true;
            this.cmb_customers.Location = new System.Drawing.Point(62, 65);
            this.cmb_customers.Name = "cmb_customers";
            this.cmb_customers.Size = new System.Drawing.Size(328, 32);
            this.cmb_customers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "مشتری :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "مشخصات سفارش";
            // 
            // pnl_Foods
            // 
            this.pnl_Foods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Foods.Location = new System.Drawing.Point(501, 0);
            this.pnl_Foods.Name = "pnl_Foods";
            this.pnl_Foods.Size = new System.Drawing.Size(832, 830);
            this.pnl_Foods.TabIndex = 1;
            // 
            // Add_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 830);
            this.Controls.Add(this.pnl_Foods);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Add_Order";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Order_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_orderlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Foods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_customers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dt_gd_viw_orderlist;
    }
}