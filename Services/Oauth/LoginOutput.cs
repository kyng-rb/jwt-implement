namespace jwt_implement.Services.Oauth;

public class LoginOutput
{
    public string Token { get; }

    public LoginOutput(string token)
    {
        Token = token;
    }
}
