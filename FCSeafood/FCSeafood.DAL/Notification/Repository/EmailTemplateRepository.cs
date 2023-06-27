namespace FCSeafood.DAL.Notification.Repository;

public class EmailTemplateRepository {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(EmailTemplateRepository));

    private readonly DbSet<EmailTemplateDbo> _entities;

    public EmailTemplateRepository(EventFCSeafoodContext context) {
        _entities = context.Set<EmailTemplateDbo>();
    }

    public (bool isSuccessful, EmailTemplate model) GetTemplate(string code) {
        try {
            var dbo = _entities.FirstOrDefault(x => x.Code == code);
            if (dbo == null) {
                return (false, new EmailTemplate());
            }

            var model = new EmailTemplate() {
                Code = dbo.Code
              , EmailBody = {
                    Subject = dbo.Subject
                  , Body = dbo.Body.Trim()
                }
            };
            return (true, model);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
            return (false, new EmailTemplate());
        }
    }
}