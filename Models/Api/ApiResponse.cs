namespace jwt_implement.Models.Api;

public class ApiResponse
{
    public IEnumerable<string> Messages { get; set; } = new List<string>();
}

public class ApiResponse<Result> : ApiResponse
{
    public Result? Data { get; set; }
}
