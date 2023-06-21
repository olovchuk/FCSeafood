using System.Security.Cryptography;
using System.Text;

namespace FCSeafood.BLL.User.Auth.Helpers;

public static class HashHelper {
    public static string HashSha256(string word) {
        var passwordBytes = Encoding.UTF8.GetBytes(word);
        var hashedPassword = SHA256.HashData(passwordBytes);
        return Convert.ToHexString(hashedPassword);
    }
}