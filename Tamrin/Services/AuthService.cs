using Tamrin.Models;

namespace Tamrin.Services;

public class AuthService
{
    private static readonly Dictionary<string, (string Password, Guid Token, DateTime Expiry)> Users = 
        new Dictionary<string, (string, Guid, DateTime)>();

    public Guid Login(Login login)
    {
        if (!Users.TryGetValue(login.UserName, out var user))
            throw new UnauthorizedAccessException("کاربر یافت نشد");
        if (user.Password != login.PassWord)
            throw new UnauthorizedAccessException("رمز عبور نادرست است");

        var token = Guid.NewGuid();
        
        Users[login.UserName] = (login.PassWord, token, DateTime.UtcNow.AddSeconds(20));

        return token;
    }

    public void Register(Login login)
    {
        if (Users.ContainsKey(login.UserName))
            throw new InvalidOperationException("کاربر قبلاً ثبت شده است");

        if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.PassWord))
            throw new ArgumentException("نام کاربری و رمز عبور الزامی است");

        Users[login.UserName] = (login.PassWord, Guid.Empty, DateTime.MinValue);
    }

    public bool IsValidGuid(string username, Guid token)
    {
        if (!Users.TryGetValue(username, out var user))
            return false;
        return user.Token == token && DateTime.UtcNow < user.Expiry;
    }
}