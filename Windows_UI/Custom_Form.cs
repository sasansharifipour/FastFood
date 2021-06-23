using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public class Custom_Form : Form
    {
        public string user_id { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (string.IsNullOrEmpty(user_id))
            {
                MessageBox.Show("User Should Login");
            }
        }

    }
}
