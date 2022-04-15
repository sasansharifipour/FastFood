using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public class SpecialForm : Form
    {
        private Form _login_form;

        public SpecialForm([Dependency("login_form")] Form login_form)
        {
            _login_form = login_form;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                while (!LoginInfo.IsLoggedIn())
                {
                    var result = _login_form.ShowDialog();

                    if (result == DialogResult.Cancel)
                        Application.Exit();
                }

                base.OnLoad(e);
            }
            catch (Exception ex) { }
        }/**/
    }
}
