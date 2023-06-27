using System.Net.Mail;

namespace FCSeafood.BusinessObjects.Notification;

public class EmailBody {
    public string Subject { get; set; } = "";
    public string Body { get; set; } = "";
    public List<Dictionary<string, string>> BodyItems { get; set; } = new();
    public List<Attachment> Attachments { get; set; } = new();
}