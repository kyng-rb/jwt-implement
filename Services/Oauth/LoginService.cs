using FluentResults;
using jwt_implement.Auth;
using jwt_implement.Repositories;

namespace jwt_implement.Services.Oauth;

public class Login : ILogin
{
    private readonly IRepository _repository;
    private readonly ICreateToken _createToken;

    public Login(IRepository repository, ICreateToken createToken)
    {
        _repository = repository;
        _createToken = createToken;
    }

    Result<LoginOutput> ILogin.Login(LoginInput input)
    {
        var user = _repository.GetBy(input.UserName);

        if (user is null)
            return Result.Fail("User not found");

        var token = _createToken.Create(user);
        var output = new LoginOutput(token);

        return Result.Ok(output);
    }
}
