using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace FCSeafood.BLL.Helpers;

public class EmailHelper {
    public static bool IsValidateEmail(string email) {
        try {
            var mailAddress = new MailAddress(email);
            return true;
        } catch (Exception ex) {
            return false;
        }
    }
}