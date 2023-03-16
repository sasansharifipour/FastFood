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
    public partial class Add_Food : SpecialForm
    {
        private IConfigService _configFile;
        private IUnitOfWork _unitOfWork;

        public Add_Food(IConfigService configFile, IUnitOfWork unitOfWork, [Dependency("login_form")]
        Form login_form) 
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
            int ID = (int)cmb_food_list.SelectedValue;
            double Price = 0;
            double.TryParse(txt_price.Text, out Price);
            string Name = txt_name.Text.Trim();
            Food data;

            bool register = false;

            if (ID > 0)
            {
                data = _unitOfWork.Foods.Get(ID);
                data.Name = Name;
                data.Price = Price;
            }
            else
                _unitOfWork.Foods.Add(new Food() { Name = Name, Price = Price });

            register = _unitOfWork.Complete() > 0 ? true : false;

            if (register)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_info();
                clean_form();
            }
            else
            {
                MessageBox.Show(null,"در ثبت اطلاعات خطایی رخ داده است","خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_info()
        {
            cmb_food_list.DisplayMember = "Name";
            cmb_food_list.ValueMember = "ID";
            var data = _unitOfWork.Foods.GetAll().ToList();

            data.Insert(0, new Food() { ID = 0, Name = "افزودن محصول", Price = 0 });

            cmb_food_list.DataSource = data;
        }

        private void Add_Food_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_food_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_food_list.SelectedValue;
            var food = _unitOfWork.Foods.Get(selected_id);

            if (food == null || food.ID <= 0)
            {
                clean_form();
                return;
            }
            
            set_data(food);
        }

        private void clean_form()
        {
            txt_name.Text = "";
            txt_price.Text = "";
            txt_name.Focus();
        }

        private void set_data(Food data)
        {
            txt_name.Text = data.Name;
            txt_price.Text = data.Price.ToString();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {

                int selected_id = (int)cmb_food_list.SelectedValue;

                Food food = _unitOfWork.Foods.Get(selected_id);

                bool deleted = false;

                if (food == null || food.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                food.Deleted = true;

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
