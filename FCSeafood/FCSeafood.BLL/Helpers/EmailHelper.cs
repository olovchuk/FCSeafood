using System.Net.Mail;

namespace FCSeafood.BLL.Helpers;

public static class EmailHelper {
    public static bool IsValidateEmail(string email) {
        try {
            var mailAddress = new MailAddress(email);
            return true;
        } catch (Exception) {
            return false;
        }
    }
}