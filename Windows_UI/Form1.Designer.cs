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
            this.add_food_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.سفارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add_order_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.محصولاتToolStripMenuItem,
            this.سفارشToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // محصولاتToolStripMenuItem
            // 
            this.محصولاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_food_ToolStripMenuItem});
            this.محصولاتToolStripMenuItem.Name = "محصولاتToolStripMenuItem";
            this.محصولاتToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.محصولاتToolStripMenuItem.Text = "محصولات";
            // 
            // add_food_ToolStripMenuItem
            // 
            this.add_food_ToolStripMenuItem.Name = "add_food_ToolStripMenuItem";
            this.add_food_ToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
            this.add_food_ToolStripMenuItem.Text = "افزودن محصول";
            this.add_food_ToolStripMenuItem.Click += new System.EventHandler(this.add_food_ToolStripMenuItem_Click);
            // 
            // سفارشToolStripMenuItem
            // 
            this.سفارشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_order_ToolStripMenuItem});
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
    }
}

