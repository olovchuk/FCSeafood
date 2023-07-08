using Microsoft.Extensions.Configuration;

namespace FCSeafood.BLL.Settings;

public class GlobalSettings {
    private readonly IConfiguration _configuration;

    public GlobalSettings(IConfiguration configuration) {
        _configuration = configuration;
    }

    private string? _domainUrl;

    public string DomainUrl {
        get {
            if (string.IsNullOrWhiteSpace(_domainUrl))
                _domainUrl = _configuration.GetValue<string>("GlobalSettings:DomainUrl");
            return _domainUrl ?? "";
        }
    }
}