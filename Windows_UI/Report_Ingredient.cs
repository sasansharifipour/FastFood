using CommonCodes;
using Domain.BaseClasses;
using Domain.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Report_Ingredient : Form
    {
        private IOrderService _orderService;
        private IReportService _reportService;
        private ISendInformationService _sendInformationService;

        public Report_Ingredient(IOrderService orderService, IReportService reportService,
            ISendInformationService sendInformationService)
        {
            InitializeComponent();

            _orderService = orderService;
            _reportService = reportService;
            _sendInformationService = sendInformationService;
            dat_tim_picker_from_date.Value = DateTime.Now;
            dat_tim_picker_to_date.Value = DateTime.Now;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string date_time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            DateTime from_date = dat_tim_picker_from_date.Value.Value.Date;
            DateTime to_date = dat_tim_picker_to_date.Value.Value.Date;

            List<ConsumeViewModel> all_consume = _reportService.Get_Ingrediants_FromDate_ToDate(from_date, to_date);

            fill_dt_gd_viw_report(all_consume);

            var dt_consumes = all_consume.convert_to_datatable(from_date, to_date);

            string consume_path = string.Format("{0}-{1}.{2}", "Consume", date_time, "csv");

            dt_consumes.convert_object_to_csv(consume_path);

            List<string> files = new List<string>() { consume_path };

            Task.Factory.StartNew(() => _sendInformationService.Send_Email(files));
        }

        private void fill_dt_gd_viw_report(List<ConsumeViewModel> all_consume)
        {
            dt_gd_viw_reportlist.DataSource = all_consume;
            dt_gd_viw_reportlist.Columns["IngredientName"].HeaderText = "محصول";
            dt_gd_viw_reportlist.Columns["Volume"].HeaderText = "مقدار";
            dt_gd_viw_reportlist.Columns["UnitName"].HeaderText = "واحد";

            dt_gd_viw_reportlist.Columns["Volume"].DefaultCellStyle.Format = "N2";

            dt_gd_viw_reportlist.Columns["UnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_reportlist.Columns["Volume"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_reportlist.Columns["IngredientName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
