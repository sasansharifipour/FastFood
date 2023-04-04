using CommonCodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Service
{
    public interface ISendInformationService
    {
        void Send_Email(List<string> file_paths);
    }

    public class SendEmailService : ISendInformationService
    {
        private IConfigService _configService;

        public SendEmailService(IConfigService configService)
        {
            _configService = configService;
        }

        public void Send_Email(List<string> file_paths)
        {
            try
            {
                string date_time = DateTime.Now.ToPersianLongDateString();
                string from_email_address = _configService.FromEmailAddress;
                List<string> to_email_address = _configService.ToEmailAddresses;
                string email_key = _configService.EmailKey;

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(from_email_address);

                foreach (var item in to_email_address)
                    message.To.Add(new MailAddress(item));

                message.Subject = string.Format("{0}-{1}", "گزارش", date_time);
                message.IsBodyHtml = true;
                message.Body = string.Format("{0} : {1} {2}", "گزارش تاریخ", date_time
                    , " از نرم افزار به صورت خودکار ارسال گردید.");

                foreach (var item in file_paths)
                    if (item != null && item.Trim() != "" && File.Exists(item))
                        message.Attachments.Add(new Attachment(item));

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from_email_address, email_key);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
