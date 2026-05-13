using System.Net;
using System.Net.Mail;


async void SendEmailAsync()
{

    string smtpAddress = "smtp.gmail.com";
    int port = 587;
    string userName = "maks.fedak334@gmail.com";
    string appPassword = "rtsh kxyc jsdy ncio";

    string emailFrom = "maks.fedak334@gmail.com";
    string emailTo = "testprogemail1@gmail.com";

    string subject = "Hello, its subject";
    string body = "<b style='color: red; background-color: orange'>Hi, today is a nice day!!!</b>";

    MailAddress from = new MailAddress(emailFrom);
    MailAddress to = new MailAddress(emailTo);
    MailMessage message = new MailMessage(from, to);

    message.Subject = subject;
    message.Body = body;

    /*string filePath1 = @"C:\Users\admin\Downloads\depositphotos_8573604-stock-photo-field-of-sunflowers.png";*/
    string filePath2 = @"C:\Users\admin\Downloads\depositphotos_8573604-stock-photo-field-of-sunflowers.jpg";
    /*message.Attachments.Add(new Attachment(filePath1));*/
    message.Attachments.Add(new Attachment(filePath2));

    SmtpClient smtpClient = new SmtpClient(smtpAddress, port);

    smtpClient.Credentials = new NetworkCredential(userName, appPassword);
    smtpClient.EnableSsl = true;
    await smtpClient.SendMailAsync(message);

    Console.WriteLine("Message Send Successfully!");
}


SendEmailAsync();

Console.WriteLine("Main Thread is not blocked!");

Console.ReadKey();