using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;

namespace CalTron3k
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Mailer(string username, string password)
        {
            string status = "Message has been sent";
            
            MailMessage message = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com");           
            SmtpServer.EnableSsl = true;
            
            // Message params
            message.From = new MailAddress(username);
            message.To.Add(username);
            message.Subject = "TEST Subject";
            message.Body = "Body Test";
            
            SmtpServer.Port = 587;           
            SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);

            try
            {
                SmtpServer.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateCopyMessage(): {0}",
                            ex.ToString());
            }
            
            
            return status; 
        }
    }
}
