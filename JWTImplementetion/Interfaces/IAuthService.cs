using JWTImplementetion.Model;
using JWTImplementetion.RequestModel;

namespace JWTImplementetion.Interfaces
{
    public interface IAuthService
    {
        User AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}
