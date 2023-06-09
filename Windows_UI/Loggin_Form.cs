﻿using CommonCodes;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Loggin_Form : Form
    {
        private IUnitOfWork _unitOfWork;

        public Loggin_Form(IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;

            _thePanel.Location = new Point(
                this.ClientSize.Width / 2 - _thePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);
            _thePanel.Anchor = AnchorStyles.None;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            int ID = 0;

            int.TryParse(txt_code.Text.Trim(), out ID);
            string Password = Hashing.Hash(txt_password.Text.Trim());

            var user = _unitOfWork.Users.Get(ID);

            if (user == null || user.ID <= 0 || !string.Equals(user.Password, Password))
            {
                MessageBox.Show("امکان ورود به نرم افزار وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoginInfo.User = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void Loggin_Form_ResizeEnd(object sender, EventArgs e)
        {
            _thePanel.Location = new Point(
                this.ClientSize.Width / 2 - _thePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);
            _thePanel.Anchor = AnchorStyles.None;
        }

        private void Loggin_Form_Load(object sender, EventArgs e)
        {
            txt_code.Text = "";
            txt_password.Text = "";
        }
    }
}
