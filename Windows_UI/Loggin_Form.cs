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
        private IUserService _userService;
        private IHashing _hashing;

        public Loggin_Form(IUserService userService, IHashing hashing)
        {
            InitializeComponent();

            _userService = userService;
            _hashing = hashing;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            int ID = 0;

            int.TryParse(txt_code.Text.Trim(), out ID);
            string Password = _hashing.Hash(txt_password.Text.Trim());

            var user = _userService.find(ID);

            if (user == null || user.ID <= 0 || !string.Equals(user.Password, Password))
            {
                MessageBox.Show("امکان ورود به نرم افزار وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoginInfo.User = user;
                this.Close();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
