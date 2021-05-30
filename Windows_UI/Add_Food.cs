using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Add_Food : Form
    {
        public Add_Food()
        {
            InitializeComponent();
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            string text = txt_price.Text;
            double value = 0;
            double.TryParse(text, out value);
            string formated_text = String.Format("{0:C2}", value.ToString());
            txt_price.Text = formated_text;
        }
    }
}
