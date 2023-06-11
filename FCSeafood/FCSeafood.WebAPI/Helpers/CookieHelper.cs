namespace FCSeafood.WebAPI.Helpers;

public class CookieHelper {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                     .CreateLogger(typeof(CookieHelper));

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieHelper(IHttpContextAccessor httpContextAccessor) {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetCookie(
        string key
      , string value
      , TimeSpan expired
      , bool serverOnly
    ) {
        var options = new CookieOptions {
            Expires = DateTime.Now.Add(expired)
          , HttpOnly = serverOnly
        };

        try {
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(key, value, options);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Cookie.Global, ex.Message);
        }
    }

    public string GetCookie(string key) {
        try {
            if (_httpContextAccessor.HttpContext?.Request.Cookies.ContainsKey(key) ?? false)
                return _httpContextAccessor.HttpContext?.Request.Cookies[key] ?? string.Empty;

            return string.Empty;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Cookie.Global, ex.Message);
            return string.Empty;
        }
    }

    public void RemoveCookie(string key) {
        try {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete(key);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Cookie.Global, ex.Message);
        }
    }
}