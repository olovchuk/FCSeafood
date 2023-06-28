using System.Net;
using System.Net.Mail;
using FCSeafood.DAL.Notification.Repository;

namespace FCSeafood.BLL.Services;

public class EmailService : EmailTemplate {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(EmailService));

    private readonly EmailSettings _emailSettings;
    private readonly EmailTemplateRepository _emailTemplateRepository;

    public EmailService(EmailSettings emailSettings, EmailTemplateRepository emailTemplateRepository) {
        _emailSettings = emailSettings;
        _emailTemplateRepository = emailTemplateRepository;
    }

    private void SendEmail() {
        try {
            using var client = new SmtpClient(_emailSettings.Server, _emailSettings.Port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);
            client.EnableSsl = true;

            using var message = new MailMessage();
            message.From = new MailAddress(_emailSettings.UserName);
            foreach (var address in Addresses) {
                message.To.Add(address);
            }

            foreach (var ccAddress in CcAddresses) {
                message.CC.Add(ccAddress);
            }

            foreach (var bccAddress in BccAddresses) {
                message.Bcc.Add(bccAddress);
            }

            message.Subject = EmailBody.Subject;
            message.Body = EmailBody.Body;
            message.IsBodyHtml = true;
            foreach (var attachment in EmailBody.Attachments) {
                message.Attachments.Add(attachment);
            }

            client.Send(message);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
        }
    }

    public void SendEmailResetPassword(string address, string userFullName, string confirmUrl) {
        var (isSuccessful, model) = _emailTemplateRepository.GetTemplate(EmailTemplateCode.ResetPasswordConfirm);
        if (!isSuccessful)
            return;

        model.EmailBody.Body = model.EmailBody.Body.Replace(EmailTemplateParameters.UserFullName, userFullName);
        model.EmailBody.Body = model.EmailBody.Body.Replace(EmailTemplateParameters.ConfirmUrl, confirmUrl);

        this.Code = model.Code;
        this.EmailBody = model.EmailBody;
        Addresses.Add(address);
        this.SendEmail();
    }

    public void SendEmailForgotPassword(string address, string userFullName, string newPassword) {
        var (isSuccessful, model) = _emailTemplateRepository.GetTemplate(EmailTemplateCode.ForgotPassword);
        if (!isSuccessful)
            return;

        model.EmailBody.Body = model.EmailBody.Body.Replace(EmailTemplateParameters.UserFullName, userFullName);
        model.EmailBody.Body = model.EmailBody.Body.Replace(EmailTemplateParameters.NewPassword, newPassword);

        this.Code = model.Code;
        this.EmailBody = model.EmailBody;
        Addresses.Add(address);
        this.SendEmail();
    }
}