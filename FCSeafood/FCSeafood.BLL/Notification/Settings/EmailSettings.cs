using Microsoft.Extensions.Configuration;

namespace FCSeafood.BLL.Notification.Settings;

public class EmailSettings : IEmailSettings {
    private readonly IConfiguration _configuration;

    public EmailSettings(IConfiguration configuration) {
        _configuration = configuration;
    }

    private string? _userName;

    public string UserName {
        get {
            if (string.IsNullOrWhiteSpace(_userName))
                _userName = _configuration.GetValue<string>("SMTP:UserName");
            return _userName ?? "";
        }
    }

    private string? _password;

    public string Password {
        get {
            if (string.IsNullOrWhiteSpace(_password))
                _password = _configuration.GetValue<string>("SMTP:Password");
            return _password ?? "";
        }
    }

    private string? _server;

    public string Server {
        get {
            if (string.IsNullOrWhiteSpace(_server))
                _server = _configuration.GetValue<string>("SMTP:Server");
            return _server ?? "";
        }
    }

    private int? _port;

    public int Port {
        get {
            _port ??= _configuration.GetValue<int>("SMTP:Port");
            return _port ?? 0;
        }
    }
}