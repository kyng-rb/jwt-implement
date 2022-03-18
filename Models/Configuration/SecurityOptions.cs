namespace jwt_implement.Models.Configuration;

public class SecurityOptions
{
    public const string FieldName = "Security";

    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public int ExpireTime { get; set; } = 0;
}
