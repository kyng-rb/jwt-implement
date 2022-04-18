using FluentResults;

namespace jwt_implement.Services.Oauth;

public interface ILogin
{
    Result<LoginOutput> Login(LoginInput input);
}
