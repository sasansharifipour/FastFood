using CommonCodes;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IPrintService
    {
        void Print(Order order);
    }

    public class PrintService : IPrintService
    {
        private Order _order { get; set; }

        public void Print(Order order)
        {
            if (order == null || order.ID <= 0 || order.Deleted)
                return;

            _order = order;

            Print_For_Customer();
            Print_For_Kitchen();
        }

        private void Print_For_Customer()
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += PrintDocument1_PrintPage;

            printDocument1.PrintController = new StandardPrintController();
            printDocument1.Print();
            printDocument1.Dispose();
        }

        private void Print_For_Kitchen()
        {
            if (_order.OrderItems.Count <= 0)
                return;

            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += PrintDocument_Kitchen_PrintPage;

            printDocument1.PrintController = new StandardPrintController();
            printDocument1.Print();
            printDocument1.Dispose();
        }

        private void PrintDocument_Kitchen_PrintPage(object sender, PrintPageEventArgs e)

        {
            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);

            float fontHeight = font.GetHeight();

            Font b_nazanin_18 = new Font("B Nazanin", 32, FontStyle.Bold);
            Font b_nazanin_14 = new Font("B Nazanin", 14, FontStyle.Bold);
            Font b_nazanin_12 = new Font("B Nazanin", 12, FontStyle.Bold);
            Font b_nazanin_10 = new Font("B Nazanin", 10);
            int max_paper_width = 275;

            string greeting = "*  به چی چی خوش آمدید  *";

            int greeting_Y = 0;
            int Offset = 0;

            Offset = print_center(graphics, b_nazanin_14, greeting, max_paper_width, greeting_Y) + 5;
            //e.PageSettings.PaperSize.Width = 4;

            string data = _order.Number.ToString();
            int x = Offset;
            Offset = print_center(graphics, b_nazanin_18, data, max_paper_width, Offset) + 5;

            graphics.DrawRectangle(Pens.Black, 95, x - 5, 75, Offset - x - 5);
            graphics.DrawRectangle(Pens.Black, 100, x - 2, 75, Offset - x - 5);

            data = string.Format("{0} : {1} - {2} : {3}", "تاریخ", _order.Insert_time.
                ToPersianLongDateString(), "ساعت", _order.Insert_time.ToShortTimeString());

            Offset = print_right(graphics, b_nazanin_10, data, max_paper_width, Offset) + 5;

            string custumer_name = string.Format("{0}:{1}/{2}-{3}", "مشتری محترم", "جناب آقای", "سرکار خانم", _order.Customer.FullName);

            Offset = print_right(graphics, b_nazanin_10, custumer_name, max_paper_width, Offset) + 5;

            int start_offset = Offset;

            graphics.DrawLine(Pens.Black, new Point(0, Offset), new Point(275, Offset));

            print_cell(graphics, b_nazanin_10, "", Offset, (int)table_position.row, (int)table_size.row);
            print_cell(graphics, b_nazanin_10, "عنوان", Offset, (int)table_position.title, (int)table_size.title);
            print_cell(graphics, b_nazanin_10, "تعداد", Offset, (int)table_position.fee, (int)table_size.fee);
            print_cell(graphics, b_nazanin_10, "", Offset, (int)table_position.cnt, (int)table_size.cnt);

            Offset += 20;
            int max_offset = 20;
            int temp_value = 0;

            for (int i = 0; i < _order.OrderItems.Count; i++)
            {
                max_offset = 20;

                graphics.DrawLine(Pens.Black, new Point(0, Offset), new Point(275, Offset));
                temp_value = print_cell(graphics, b_nazanin_10, (i + 1).ToString(), Offset
                    , (int)table_position.row, (int)table_size.row);
                max_offset = Math.Max(max_offset, temp_value);

                temp_value = print_cell(graphics, b_nazanin_10, _order.OrderItems[i].Name, Offset
                    , (int)table_position.title, (int)table_size.title);
                max_offset = Math.Max(max_offset, temp_value);

                print_cell_left(graphics, b_nazanin_10, _order.OrderItems[i].Count.ToString()
                    , Offset, (int)table_position.cnt + 1);

                print_cell_left(graphics, b_nazanin_10, "", Offset, 1);

                Offset += max_offset;
            }

            int end_offset = Offset;

            graphics.DrawLine(Pens.Black, new Point(1, start_offset), new Point(1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.row + 1, start_offset), new Point((int)table_position.row + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.title + 1, start_offset), new Point((int)table_position.title + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.fee + 1, start_offset), new Point((int)table_position.fee + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.cnt + 1, start_offset), new Point((int)table_position.cnt + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.price + 1, start_offset), new Point((int)table_position.price + 1, end_offset));

            graphics.DrawLine(Pens.Black, new Point(0, Offset), new Point(275, Offset));


            string Message = "حد فاصل چهارراه جهاد و چهارراه دانشگاه ساندویچی چی چی";
            Offset = print_right(graphics, b_nazanin_10, Message, max_paper_width, Offset) + 5;

            string Mobile = "سفارش : 09139497717 و 09057103100";
            Offset = print_right(graphics, b_nazanin_12, Mobile, max_paper_width, Offset) + 5;

            string management = "با مدیریت : علی شریفی";
            Offset = print_center(graphics, b_nazanin_12, management, max_paper_width, Offset) + 5;
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);

            float fontHeight = font.GetHeight();

            string greeting = "*  به چی چی خوش آمدید  *";
            Font b_nazanin_18 = new Font("B Nazanin", 32, FontStyle.Bold);
            Font b_nazanin_14 = new Font("B Nazanin", 14, FontStyle.Bold);
            Font b_nazanin_12 = new Font("B Nazanin", 12, FontStyle.Bold);
            Font b_nazanin_10 = new Font("B Nazanin", 10);
            int max_paper_width = 275;

            int Offset = 0;
            int greeting_Y = 0;

            //e.PageSettings.PaperSize.Width = 4;

            Offset = print_center(graphics, b_nazanin_14, greeting, max_paper_width, greeting_Y) + 5;

            string data = _order.Number.ToString();
            int x = Offset;
            Offset = print_center(graphics, b_nazanin_18, data, max_paper_width, Offset) + 5;

            graphics.DrawRectangle(Pens.Black, 95, x - 5, 75, Offset - x - 5);
            graphics.DrawRectangle(Pens.Black, 100, x - 2, 75, Offset - x - 5);

            data = string.Format("{0} : {1} - {2} : {3}", "تاریخ", _order.Insert_time.
                ToPersianLongDateString(), "ساعت", _order.Insert_time.ToShortTimeString());

            Offset = print_right(graphics, b_nazanin_10, data, max_paper_width, Offset) + 5;

            string custumer_name = string.Format("{0}:{1}/{2}-{3}", "مشتری محترم", "جناب آقای", "سرکار خانم", _order.Customer.FullName);

            Offset = print_right(graphics, b_nazanin_10, custumer_name, max_paper_width, Offset) + 5;

            int start_offset = Offset;

            graphics.DrawLine(Pens.Black, new Point(0, Offset), new Point(275, Offset));

            print_cell(graphics, b_nazanin_10, "", Offset, (int)table_position.row, (int)table_size.row);
            print_cell(graphics, b_nazanin_10, "عنوان", Offset, (int)table_position.title, (int)table_size.title);
            print_cell(graphics, b_nazanin_10, "فی (ریال)", Offset, (int)table_position.fee, (int)table_size.fee);
            print_cell(graphics, b_nazanin_10, "تعداد", Offset, (int)table_position.cnt, (int)table_size.cnt);
            print_cell(graphics, b_nazanin_10, "قیمت (ریال)", Offset, (int)table_position.price, (int)table_size.price);

            Offset += 20;
            int max_offset = 20;
            int temp_value = 0;

            for (int i = 0; i < _order.OrderItems.Count; i++)
            {
                max_offset = 20;

                graphics.DrawLine(Pens.Black, new Point(0, Offset), new Point(275, Offset));
                temp_value = print_cell(graphics, b_nazanin_10, (i + 1).ToString(), Offset
                    , (int)table_position.row, (int)table_size.row);
                max_offset = Math.Max(max_offset, temp_value);

                temp_value = print_cell(graphics, b_nazanin_10, _order.OrderItems[i].Name, Offset, (int)table_position.title
                    , (int)table_size.title);
                max_offset = Math.Max(max_offset, temp_value);

                print_cell_left(graphics, b_nazanin_10, _order.OrderItems[i].Price.ToString("N0")
                    , Offset, (int)table_position.cnt + 1);

                print_cell_left(graphics, b_nazanin_10, _order.OrderItems[i].Count.ToString()
                    , Offset, (int)table_position.price + 1);

                print_cell_left(graphics, b_nazanin_10, (_order.OrderItems[i].All_Price).ToString("N0"), Offset, 1);

                Offset += max_offset;
            }

            int end_offset = Offset;

            graphics.DrawLine(Pens.Black, new Point(1, start_offset), new Point(1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.row + 1, start_offset), new Point((int)table_position.row + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.title + 1, start_offset), new Point((int)table_position.title + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.fee + 1, start_offset), new Point((int)table_position.fee + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.cnt + 1, start_offset), new Point((int)table_position.cnt + 1, end_offset));
            graphics.DrawLine(Pens.Black, new Point((int)table_position.price + 1, start_offset), new Point((int)table_position.price + 1, end_offset));

            graphics.DrawLine(Pens.Black, new Point(0, Offset), new Point(275, Offset));

            double sum = _order.OrderItems.Sum(s => s.All_Price);
            double discount = _order.discount;
            double paying_amount = _order.paying_amount;

            string Grosstotal = "جمع کل : " + sum.ToString("N0") + "ریال";
            Offset = print_right(graphics, b_nazanin_10, Grosstotal, max_paper_width, Offset) + 5;

            if (discount > 0)
            {
                string discounttotal = "تخفیف : " + discount.ToString("N0") + "ریال";
                Offset = print_right(graphics, b_nazanin_10, discounttotal, max_paper_width, Offset) + 5;

                string paytotal = "قابل پرداخت : " + (sum - discount).ToString("N0") + "ریال";
                Offset = print_right(graphics, b_nazanin_10, paytotal, max_paper_width, Offset) + 5;
            }

            string payingamount = "مبلغ پرداختی : " + paying_amount.ToString("N0") + "ریال";
            Offset = print_right(graphics, b_nazanin_12, payingamount, max_paper_width, Offset) + 5;

            string Message = "حد فاصل چهارراه جهاد و چهارراه دانشگاه ساندویچی چی چی";
            Offset = print_right(graphics, b_nazanin_10, Message, max_paper_width, Offset) + 5;

            string Mobile = "سفارش : 09139497717 و 09057103100";
            Offset = print_right(graphics, b_nazanin_12, Mobile, max_paper_width, Offset) + 5;

            string management = "با مدیریت : علی شریفی";
            Offset = print_center(graphics, b_nazanin_12, management, max_paper_width, Offset) + 5;
        }

        private enum table_position
        {
            row = 275,
            title = 260,
            fee = 145,
            cnt = 95,
            price = 65
        }

        private enum table_size
        {
            row = 15,
            title = 115,
            fee = 50,
            cnt = 30,
            price = 65
        }

        private int print_center(Graphics graphics, Font font, string data, int max_paper_width, int height_offset)
        {
            SolidBrush black = new SolidBrush(Color.Black);

            SizeF greeting_size = get_string_size(graphics, font, data);

            var startX_center = Math.Max(0, (int)(max_paper_width - greeting_size.Width) / 2);

            graphics.DrawString(data, font, black, startX_center, height_offset);

            return (int)(height_offset + greeting_size.Height);
        }

        private int print_right(Graphics graphics, Font font, string data, int max_paper_width, int height_offset)
        {
            SolidBrush black = new SolidBrush(Color.Black);

            SizeF greeting_size = get_string_size(graphics, font, data);

            graphics.DrawString(data, font, black, max_paper_width, height_offset, new StringFormat(StringFormatFlags.DirectionRightToLeft));

            return (int)(height_offset + greeting_size.Height);
        }

        private int print_cell(Graphics graphics, Font font, string data, int height_offset, int x_position, int cell_width)
        {
            SolidBrush black = new SolidBrush(Color.Black);
            
            SizeF text_size = get_string_size(graphics, font, data);
            int number_of_lines = (int)Math.Ceiling(text_size.Width / cell_width);

            graphics.DrawString(data, font, black, new Rectangle(x_position - cell_width, height_offset, cell_width
                , number_of_lines * (int)text_size.Height), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            
            return number_of_lines * (int)text_size.Height;
        }

        private void print_cell_left(Graphics graphics, Font font, string data, int height_offset, int x_position)
        {
            SolidBrush black = new SolidBrush(Color.Black);

            graphics.DrawString(data, font, black, x_position, height_offset);
        }

        private SizeF get_string_size(Graphics graphics, Font font, string data)
        {
            return graphics.MeasureString(data, font);
        }

    }
}
