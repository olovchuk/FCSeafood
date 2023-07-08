namespace FCSeafood.BLL.Notification.Settings;

public interface IEmailSettings {
    string UserName { get; }
    string Password { get; }
    string Server { get; }
    int Port { get; }
}