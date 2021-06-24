using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public class Custom_Form : Form
    {
        private Form _login_Form;

        public Custom_Form([Dependency("login_form")] Form login_form)
        {
            _login_Form = login_form;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!LoginInfo.IsLoggedIn())
            {
                var result = _login_Form.ShowDialog();

                if (result == DialogResult.Cancel)
                    Application.Exit();
            }

            base.OnLoad(e);

        }

    }
}
