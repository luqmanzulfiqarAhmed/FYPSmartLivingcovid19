using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
namespace smartLiving
{
    public class Notification
    {
        public Notification() { }


        public bool sendEmail(){
            var message=new MimeMessage();
            message.From.Add(new MailboxAddress("Smart Living","smartliving321@gmail.com"));
            message.To.Add(new MailboxAddress("Person","asadmirza547@gmail.com"));
            message.Subject="API Message";
            message.Body=new TextPart("plain"){
                Text="Bund Dy Dy!!!"
            };
            using (var client=new SmtpClient()){
                client.Connect("smtp.gmail.com",587,false);
                client.Authenticate("smartliving321@gmail.com","living@smart1122");
                client.Send(message);
                client.Disconnect(true);
//                client.ServerCertificateValidationCallback=();
            };


            return false;
        }
    }
}
