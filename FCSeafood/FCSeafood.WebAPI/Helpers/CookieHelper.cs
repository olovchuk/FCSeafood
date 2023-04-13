namespace FCSeafood.WebAPI.Helpers;

public class CookieHelper {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(CookieHelper));

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieHelper(IHttpContextAccessor HttpContextAccessor) {
        _httpContextAccessor = HttpContextAccessor;
    }

    public void SetCookie(string key, string value, TimeSpan expired, bool serverOnly) {
        var options = new CookieOptions {
            Expires = DateTime.Now.Add(expired)
          , HttpOnly = serverOnly
        };

        try {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
        } catch (Exception ex) { log.LogError($"Failed to set cookie\r\nKey: [{key}]\r\nValue: [{value}]\r\nError: [{ex.Message}]"); }
    }

    public string? GetCookie(string key) {
        try { return _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(key) ? _httpContextAccessor.HttpContext.Request.Cookies[key] : null; } catch (Exception ex) {
            log.LogError($"Failed to get cookie\r\nKey: [{key}]\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public void RemoveCookie(string key) {
        try { _httpContextAccessor.HttpContext.Response.Cookies.Delete(key); } catch (Exception ex) { log.LogError($"Failed to remove cookie\r\nKey: [{key}]\r\nError: [{ex.Message}]"); }
    }
}