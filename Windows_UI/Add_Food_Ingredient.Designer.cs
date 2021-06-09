namespace Windows_UI
{
    partial class Add_Food_Ingredient
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
            this.cmb_food_list = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_data_list = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_unit_name = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.dt_gd_viw_consume = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_consume)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_food_list
            // 
            this.cmb_food_list.FormattingEnabled = true;
            this.cmb_food_list.Location = new System.Drawing.Point(127, 20);
            this.cmb_food_list.Name = "cmb_food_list";
            this.cmb_food_list.Size = new System.Drawing.Size(219, 32);
            this.cmb_food_list.TabIndex = 9;
            this.cmb_food_list.SelectedIndexChanged += new System.EventHandler(this.cmb_food_list_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "انتخاب محصول : ";
            // 
            // cmb_data_list
            // 
            this.cmb_data_list.FormattingEnabled = true;
            this.cmb_data_list.Location = new System.Drawing.Point(127, 58);
            this.cmb_data_list.Name = "cmb_data_list";
            this.cmb_data_list.Size = new System.Drawing.Size(219, 32);
            this.cmb_data_list.TabIndex = 10;
            this.cmb_data_list.SelectedIndexChanged += new System.EventHandler(this.cmb_data_list_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "انتخاب مواد اولیه : ";
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(423, 58);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(86, 31);
            this.txt_amount.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "مقدار : ";
            // 
            // lbl_unit_name
            // 
            this.lbl_unit_name.AutoSize = true;
            this.lbl_unit_name.Location = new System.Drawing.Point(529, 61);
            this.lbl_unit_name.Name = "lbl_unit_name";
            this.lbl_unit_name.Size = new System.Drawing.Size(0, 24);
            this.lbl_unit_name.TabIndex = 14;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(660, 51);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(108, 45);
            this.btn_save.TabIndex = 15;
            this.btn_save.Text = "ثبت";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dt_gd_viw_consume
            // 
            this.dt_gd_viw_consume.AllowUserToAddRows = false;
            this.dt_gd_viw_consume.AllowUserToDeleteRows = false;
            this.dt_gd_viw_consume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gd_viw_consume.Location = new System.Drawing.Point(27, 113);
            this.dt_gd_viw_consume.Name = "dt_gd_viw_consume";
            this.dt_gd_viw_consume.ReadOnly = true;
            this.dt_gd_viw_consume.Size = new System.Drawing.Size(741, 306);
            this.dt_gd_viw_consume.TabIndex = 16;
            // 
            // Add_Food_Ingredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 431);
            this.Controls.Add(this.dt_gd_viw_consume);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_unit_name);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_data_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_food_list);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Add_Food_Ingredient";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "افزودن مواد اولیه به محصولات";
            this.Load += new System.EventHandler(this.Add_Food_Ingredient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_gd_viw_consume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_food_list;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_data_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_unit_name;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dt_gd_viw_consume;
    }
}