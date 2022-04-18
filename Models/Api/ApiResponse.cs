namespace jwt_implement.Models.Api;

public class ApiResponse<Result>
{
    public ApiResponse(Result data)
    {
        Data = data;
    }

    public ApiResponse(IEnumerable<string> messages)
    {
        Messages = messages;
    }

    public IEnumerable<string> Messages { get; set; } = new List<string>();

    public Result? Data { get; set; }
}
