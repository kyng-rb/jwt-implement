namespace jwt_implement.Models;
public class LoginResponse
{
    public User? User { get; set; }
    public string Token { get; set; } = string.Empty;
}
