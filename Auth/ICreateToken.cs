using jwt_implement.Models;

namespace jwt_implement.Auth;

public interface ICreateToken
{
    string Create(User user);
}
