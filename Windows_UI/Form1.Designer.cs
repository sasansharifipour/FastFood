namespace Windows_UI
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.محصولاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_customer_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_food_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_unit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_ingredient_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_ingredient_to_food_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.سفارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_order_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_order_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.report_ingredient_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.محصولاتToolStripMenuItem,
            this.سفارشToolStripMenuItem,
            this.گزارشToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // محصولاتToolStripMenuItem
            // 
            this.محصولاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_customer_ToolStripMenuItem,
            this.add_food_ToolStripMenuItem,
            this.add_unit_ToolStripMenuItem,
            this.add_ingredient_ToolStripMenuItem,
            this.add_ingredient_to_food_ToolStripMenuItem});
            this.محصولاتToolStripMenuItem.Name = "محصولاتToolStripMenuItem";
            this.محصولاتToolStripMenuItem.Size = new System.Drawing.Size(64, 27);
            this.محصولاتToolStripMenuItem.Text = "تنظیمات";
            // 
            // add_customer_ToolStripMenuItem
            // 
            this.add_customer_ToolStripMenuItem.Name = "add_customer_ToolStripMenuItem";
            this.add_customer_ToolStripMenuItem.Size = new System.Drawing.Size(210, 28);
            this.add_customer_ToolStripMenuItem.Text = "افزودن مشتری";
            this.add_customer_ToolStripMenuItem.Click += new System.EventHandler(this.add_customer_ToolStripMenuItem_Click);
            // 
            // add_food_ToolStripMenuItem
            // 
            this.add_food_ToolStripMenuItem.Name = "add_food_ToolStripMenuItem";
            this.add_food_ToolStripMenuItem.Size = new System.Drawing.Size(210, 28);
            this.add_food_ToolStripMenuItem.Text = "افزودن محصول";
            this.add_food_ToolStripMenuItem.Click += new System.EventHandler(this.add_food_ToolStripMenuItem_Click);
            // 
            // add_unit_ToolStripMenuItem
            // 
            this.add_unit_ToolStripMenuItem.Name = "add_unit_ToolStripMenuItem";
            this.add_unit_ToolStripMenuItem.Size = new System.Drawing.Size(210, 28);
            this.add_unit_ToolStripMenuItem.Text = "افزودن واحد شمارش";
            this.add_unit_ToolStripMenuItem.Click += new System.EventHandler(this.add_unit_ToolStripMenuItem_Click);
            // 
            // add_ingredient_ToolStripMenuItem
            // 
            this.add_ingredient_ToolStripMenuItem.Name = "add_ingredient_ToolStripMenuItem";
            this.add_ingredient_ToolStripMenuItem.Size = new System.Drawing.Size(210, 28);
            this.add_ingredient_ToolStripMenuItem.Text = "افزودن مواد اولیه";
            this.add_ingredient_ToolStripMenuItem.Click += new System.EventHandler(this.add_ingredient_ToolStripMenuItem_Click);
            // 
            // add_ingredient_to_food_ToolStripMenuItem
            // 
            this.add_ingredient_to_food_ToolStripMenuItem.Name = "add_ingredient_to_food_ToolStripMenuItem";
            this.add_ingredient_to_food_ToolStripMenuItem.Size = new System.Drawing.Size(210, 28);
            this.add_ingredient_to_food_ToolStripMenuItem.Text = "افزودن مواد اولیه به محصول";
            this.add_ingredient_to_food_ToolStripMenuItem.Click += new System.EventHandler(this.add_ingredient_to_food_ToolStripMenuItem_Click);
            // 
            // سفارشToolStripMenuItem
            // 
            this.سفارشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_order_ToolStripMenuItem,
            this.delete_order_ToolStripMenuItem});
            this.سفارشToolStripMenuItem.Name = "سفارشToolStripMenuItem";
            this.سفارشToolStripMenuItem.Size = new System.Drawing.Size(57, 27);
            this.سفارشToolStripMenuItem.Text = "سفارش";
            // 
            // add_order_ToolStripMenuItem
            // 
            this.add_order_ToolStripMenuItem.Name = "add_order_ToolStripMenuItem";
            this.add_order_ToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
            this.add_order_ToolStripMenuItem.Text = "ثبت سفارش";
            this.add_order_ToolStripMenuItem.Click += new System.EventHandler(this.add_order_ToolStripMenuItem_Click);
            // 
            // delete_order_ToolStripMenuItem
            // 
            this.delete_order_ToolStripMenuItem.Name = "delete_order_ToolStripMenuItem";
            this.delete_order_ToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
            this.delete_order_ToolStripMenuItem.Text = "ابطال سفارش";
            this.delete_order_ToolStripMenuItem.Click += new System.EventHandler(this.delete_order_ToolStripMenuItem_Click);
            // 
            // گزارشToolStripMenuItem
            // 
            this.گزارشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.report_ingredient_ToolStripMenuItem});
            this.گزارشToolStripMenuItem.Name = "گزارشToolStripMenuItem";
            this.گزارشToolStripMenuItem.Size = new System.Drawing.Size(54, 27);
            this.گزارشToolStripMenuItem.Text = "گزارش";
            // 
            // report_ingredient_ToolStripMenuItem
            // 
            this.report_ingredient_ToolStripMenuItem.Name = "report_ingredient_ToolStripMenuItem";
            this.report_ingredient_ToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
            this.report_ingredient_ToolStripMenuItem.Text = "گزارش مواد مصرفی";
            this.report_ingredient_ToolStripMenuItem.Click += new System.EventHandler(this.report_ingredient_ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 550);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem محصولاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_food_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem سفارشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_order_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_customer_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delete_order_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_unit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_ingredient_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add_ingredient_to_food_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem report_ingredient_ToolStripMenuItem;
    }
}

