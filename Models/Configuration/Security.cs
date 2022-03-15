namespace jwt_implement.Models.Configuration;

public class Security
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpireTime { get; set; } = 0;
}
