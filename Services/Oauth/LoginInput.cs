namespace jwt_implement.Services.Oauth;

public class LoginInput
{
    public LoginInput(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; }
    public string Password { get; set; }

}
