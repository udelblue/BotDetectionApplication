using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Net.Mail;


namespace BotDetectionApplication
{
    public class Notification
    {


        public static void SendEmailGoogle(string subject, string message)
        {
            string host = ConfigurationManager.AppSettings["EmailServerHost"];
           // int port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailServerPort"]);
            string domain = ConfigurationManager.AppSettings["EmailServerDomain"];
            string username = ConfigurationManager.AppSettings["EmailServerUsername"];
            string password = ConfigurationManager.AppSettings["EmailServerPassword"];
            string fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
            string toEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"];

            MailMessage mail = new MailMessage(fromEmailAddress, toEmailAddress);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }




        public static void SendEmailNetwork(string subject, string message)
        {
            string host = ConfigurationManager.AppSettings["EmailServerHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailServerPort"]);
            string domain = ConfigurationManager.AppSettings["EmailServerDomain"];
            string username = ConfigurationManager.AppSettings["EmailServerUsername"];
            string password = ConfigurationManager.AppSettings["EmailServerPassword"];
            string fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];

            string toEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"];

            MailMessage mailMessage = new MailMessage(fromEmailAddress, toEmailAddress);
            mailMessage.Subject = subject;
           

            mailMessage.Body = message;
            mailMessage.IsBodyHtml = false;

            System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(username, password, domain);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Port = port;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = networkCredential;

            smtpClient.Send(mailMessage);

        }

    }
}
