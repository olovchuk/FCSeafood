namespace FCSeafood.BusinessObjects.Notification;

public class EmailTemplate {
    public string Code { get; set; } = "";
    public List<string> Addresses { get; set; } = new();
    public List<string> CcAddresses { get; set; } = new();
    public List<string> BccAddresses { get; set; } = new();
    public EmailBody EmailBody { get; set; } = new();
}