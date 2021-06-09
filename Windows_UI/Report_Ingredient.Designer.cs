namespace Windows_UI
{
    partial class Report_Ingredient
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
            this.label3 = new System.Windows.Forms.Label();
            this.dat_tim_picker_from_date = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dt_gd_viw_reportlist = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dat_tim_picker_to_date = new System.Windows.Forms.DateTimePicker();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_reportlist)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dat_tim_picker_to_date);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dat_tim_picker_from_date);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 100);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(803, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "از تاریخ : ";
            // 
            // dat_tim_picker_from_date
            // 
            this.dat_tim_picker_from_date.Location = new System.Drawing.Point(567, 30);
            this.dat_tim_picker_from_date.Name = "dat_tim_picker_from_date";
            this.dat_tim_picker_from_date.Size = new System.Drawing.Size(219, 31);
            this.dat_tim_picker_from_date.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dt_gd_viw_reportlist);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 208);
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
            this.dt_gd_viw_reportlist.Size = new System.Drawing.Size(924, 208);
            this.dt_gd_viw_reportlist.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "تا تاریخ : ";
            // 
            // dat_tim_picker_to_date
            // 
            this.dat_tim_picker_to_date.Location = new System.Drawing.Point(234, 30);
            this.dat_tim_picker_to_date.Name = "dat_tim_picker_to_date";
            this.dat_tim_picker_to_date.Size = new System.Drawing.Size(219, 31);
            this.dat_tim_picker_to_date.TabIndex = 13;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(50, 26);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 43);
            this.btn_search.TabIndex = 15;
            this.btn_search.Text = "جستجو";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // Report_Ingredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 408);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Report_Ingredient";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "گزارش مواد اولیه مصرفی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_reportlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dat_tim_picker_from_date;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dt_gd_viw_reportlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dat_tim_picker_to_date;
        private System.Windows.Forms.Button btn_search;
    }
}