using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Exception;
using Solution.Application;

namespace Solution.Api;

[ApiController]

public class BaseController : ControllerBase
{
    protected IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.BadRequest => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            statusCode: statusCode,
            title: error.Description
        );
    }

    protected IActionResult HandleResponse(Result response)
    {
        return response.isSuccess ? Ok(response) : Problem(response.Error);
    }
    
}