using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
namespace smartLiving
{
    public class Notification
    {
        public Notification() { }
        private string emailSubject,receiverEmail,emailBody;

        public string EmailSubject { get => emailSubject; set => emailSubject = value; }
        public string ReceiverEmail { get => receiverEmail; set => receiverEmail = value; }
        public string EmailBody { get => emailBody; set => emailBody = value; }

        public async Task<bool> sendEmail(){
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Smart Living", "smartliving321@gmail.com"));
                message.To.Add(new MailboxAddress("Person", receiverEmail));
                message.Subject = emailSubject;
                message.Body = new TextPart("plain")
                {
                    Text = emailBody
                };
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("smartliving321@gmail.com", "living@smart1122");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    //                client.ServerCertificateValidationCallback=();
                };
                return true;
            }
            catch (Exception ex) {

                return false;
            }
        }
    }
}