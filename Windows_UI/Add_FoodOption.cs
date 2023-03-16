using Domain.BaseClasses;
using DTO;
using Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Add_FoodOption : SpecialForm
    {
        private IConfigService _configFile;
        private IUnitOfWork _unitOfWork;

        public Add_FoodOption(IConfigService configFile, IUnitOfWork unitOfWork
            , [Dependency("login_form")] Form login_form)
            : base(login_form)
        {
            InitializeComponent();

            _configFile = configFile;
            _unitOfWork = unitOfWork;
            lbl_currency_title.Text = _configFile.get_currency_title();

            Task.Factory.StartNew(load_info);
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            string text = txt_price.Text;
            double value = 0;
            double.TryParse(text, out value);
            string txt = string.Format("{0:#,##0}", value);

            if (txt.Trim() == "0")
                txt = "";

            txt_price.Text = txt;
            txt_price.Select(txt_price.Text.Length, 0);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int ID = (int)cmb_foodoption_list.SelectedValue;
            double Price = 0;
            double.TryParse(txt_price.Text.Replace('.', '/').Trim(), out Price);

            double percent_Price = 0;
            double.TryParse(txt_percent_price.Text.Replace('.', '/').Trim(), out percent_Price);

            string Name = txt_name.Text.Trim();
            string Title_if_Exist = txt_IfExist.Text.Trim();
            string Title_if_NotExist = txt_IfNotExist.Text.Trim();
            bool Default_exist = chb_default_exist.Checked;
            FoodOption data;

            bool register = false;

            if (ID > 0)
            {
                data = _unitOfWork.FoodOptions.Get(ID);
                data.Name = Name;
                data.DefaultExist = chb_default_exist.Checked;
                data.TitleIfExist = Title_if_Exist;
                data.TitleIfNotExist = Title_if_NotExist;
                data.PriceIfExist = Price;
                data.PercentPriceIfExist = percent_Price;
            }
            else
                _unitOfWork.FoodOptions.Add(new FoodOption()
                {
                    Name = Name,
                    PriceIfExist = Price,
                    DefaultExist = Default_exist,
                    TitleIfExist = Title_if_Exist,
                    TitleIfNotExist = Title_if_NotExist,
                    PercentPriceIfExist = percent_Price
                });

            register = _unitOfWork.Complete() > 0 ? true : false;

            if (register)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_info();
                clean_form();
            }
            else
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_info()
        {
            cmb_foodoption_list.DisplayMember = "Name";
            cmb_foodoption_list.ValueMember = "ID";
            var data = _unitOfWork.FoodOptions.GetAll().ToList();

            data.Insert(0, new FoodOption() { ID = 0, Name = "افزودن محصول" });

            cmb_foodoption_list.DataSource = data;
        }

        private void Add_FoodOption_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_food_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_foodoption_list.SelectedValue;
            var FoodOption = _unitOfWork.FoodOptions.Get(selected_id);

            if (FoodOption == null || FoodOption.ID <= 0)
            {
                clean_form();
                return;
            }

            set_data(FoodOption);
        }

        private void clean_form()
        {
            txt_name.Text = "";
            txt_price.Text = "";
            txt_IfExist.Text = "";
            txt_IfNotExist.Text = "";
            txt_percent_price.Text = "";
            chb_default_exist.Checked = false;
            txt_name.Focus();
        }

        private void set_data(FoodOption data)
        {
            txt_name.Text = data.Name;
            txt_price.Text = data.PriceIfExist.ToString();
            txt_IfExist.Text = data.TitleIfExist;
            txt_IfNotExist.Text = data.TitleIfNotExist;
            txt_percent_price.Text = data.PercentPriceIfExist.ToString();
            chb_default_exist.Checked = data.DefaultExist;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {

                int selected_id = (int)cmb_foodoption_list.SelectedValue;

                FoodOption FoodOption = _unitOfWork.FoodOptions.Get(selected_id);

                bool deleted = false;

                if (FoodOption == null || FoodOption.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FoodOption.Deleted = true;

                deleted = _unitOfWork.Complete() > 0 ? true : false;

                if (deleted)
                {
                    MessageBox.Show(null, "اطلاعات با موفقیت حذف گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_info();
                    clean_form();
                }
                else
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
