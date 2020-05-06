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

        private string messageToReceiver,subject,receiver;
        public Notification() { }

        public string Subject { get => subject; set => subject = value; }
        public string MessageToReceiver { get => messageToReceiver; set => messageToReceiver = value; }
        public string Receiver { get => receiver; set => receiver = value; }

        public bool sendEmail(){

            try{
            var message=new MimeMessage();
            message.From.Add(new MailboxAddress("Smart Living","smartliving321@gmail.com"));
            message.To.Add(new MailboxAddress("Notification from Smart Living System",receiver));
            message.Subject=subject;
            message.Body=new TextPart("plain"){
                Text=messageToReceiver
            };
            using (var client=new SmtpClient()){
                client.Connect("smtp.gmail.com",587,false);
                client.Authenticate("smartliving321@gmail.com","living@smart1122");
                client.Send(message);
                client.Disconnect(true);
//                client.ServerCertificateValidationCallback=();
            };
            return true;

            }catch(Exception ex){


            return false;

            }

        }
    }
}
