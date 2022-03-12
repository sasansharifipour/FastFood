namespace Windows_UI
{
    partial class Report_Orders
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
            this.label4 = new System.Windows.Forms.Label();
            this.chkblst_customers = new System.Windows.Forms.CheckedListBox();
            this.dat_tim_picker_to_date = new Atf.UI.DateTimeSelector();
            this.dat_tim_picker_from_date = new Atf.UI.DateTimeSelector();
            this.btn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dt_gd_viw_reportlist = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dt_gd_viw_payment_data = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_reportlist)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_payment_data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkblst_customers);
            this.panel1.Controls.Add(this.dat_tim_picker_to_date);
            this.panel1.Controls.Add(this.dat_tim_picker_from_date);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 159);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(582, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "مشتریان : ";
            // 
            // chkblst_customers
            // 
            this.chkblst_customers.FormattingEnabled = true;
            this.chkblst_customers.Location = new System.Drawing.Point(214, 39);
            this.chkblst_customers.Name = "chkblst_customers";
            this.chkblst_customers.Size = new System.Drawing.Size(362, 108);
            this.chkblst_customers.TabIndex = 19;
            // 
            // dat_tim_picker_to_date
            // 
            this.dat_tim_picker_to_date.CustomFormat = "dddd dd MMMM ماه yyyy";
            this.dat_tim_picker_to_date.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.dat_tim_picker_to_date.Location = new System.Drawing.Point(698, 89);
            this.dat_tim_picker_to_date.Name = "dat_tim_picker_to_date";
            this.dat_tim_picker_to_date.Size = new System.Drawing.Size(219, 32);
            this.dat_tim_picker_to_date.TabIndex = 18;
            this.dat_tim_picker_to_date.UsePersianFormat = true;
            // 
            // dat_tim_picker_from_date
            // 
            this.dat_tim_picker_from_date.CustomFormat = "dddd dd MMMM ماه yyyy";
            this.dat_tim_picker_from_date.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.dat_tim_picker_from_date.Location = new System.Drawing.Point(698, 39);
            this.dat_tim_picker_from_date.Name = "dat_tim_picker_from_date";
            this.dat_tim_picker_from_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dat_tim_picker_from_date.Size = new System.Drawing.Size(219, 32);
            this.dat_tim_picker_from_date.TabIndex = 17;
            this.dat_tim_picker_from_date.UsePersianFormat = true;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(63, 30);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 43);
            this.btn_search.TabIndex = 15;
            this.btn_search.Text = "جستجو";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(923, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "تا تاریخ : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(923, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "از تاریخ : ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(987, 249);
            this.panel3.TabIndex = 2;
            // 
            // dt_gd_viw_reportlist
            // 
            this.dt_gd_viw_reportlist.AllowUserToAddRows = false;
            this.dt_gd_viw_reportlist.AllowUserToDeleteRows = false;
            this.dt_gd_viw_reportlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gd_viw_reportlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_gd_viw_reportlist.Location = new System.Drawing.Point(0, 0);
            this.dt_gd_viw_reportlist.Name = "dt_gd_viw_reportlist";
            this.dt_gd_viw_reportlist.ReadOnly = true;
            this.dt_gd_viw_reportlist.Size = new System.Drawing.Size(987, 249);
            this.dt_gd_viw_reportlist.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dt_gd_viw_reportlist);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 249);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dt_gd_viw_payment_data);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 249);
            this.panel4.TabIndex = 4;
            // 
            // dt_gd_viw_payment_data
            // 
            this.dt_gd_viw_payment_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gd_viw_payment_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_gd_viw_payment_data.Location = new System.Drawing.Point(0, 0);
            this.dt_gd_viw_payment_data.Name = "dt_gd_viw_payment_data";
            this.dt_gd_viw_payment_data.Size = new System.Drawing.Size(407, 249);
            this.dt_gd_viw_payment_data.TabIndex = 0;
            // 
            // Report_Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 408);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Report_Orders";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "گزارش فروش محصولات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Report_Orders_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_reportlist)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_payment_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dt_gd_viw_reportlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_search;
        private Atf.UI.DateTimeSelector dat_tim_picker_from_date;
        private Atf.UI.DateTimeSelector dat_tim_picker_to_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkblst_customers;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dt_gd_viw_payment_data;
        private System.Windows.Forms.Panel panel2;
    }
}