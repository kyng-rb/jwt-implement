using FluentResults;
using jwt_implement.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace jwt_implement.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsFailed)
            return new ObjectResult(new ApiResponse<T>(result.GetErrorMessages()))
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

        return new ObjectResult(new ApiResponse<T>(result.Value))
        {
            StatusCode = StatusCodes.Status200OK
        };
    }

    public static IEnumerable<string> GetErrorMessages<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return new List<string>();

        return result.Errors.Select(x => x.Message).ToList();
    }
}
