using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Entity.Result;
using SOGF.Domain.Exception;
using Solution.Application;
using Solution.Application.Dto;

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

    protected IActionResult Problem(List<ValidationFailureResponse> validationFailures)
    {
      

        return Problem(
            statusCode: StatusCodes.Status400BadRequest,
            title: $@"{string.Join(".",validationFailures.Select(v => v.errorMessage))}"
        );
    }
    protected IActionResult HandleResponse(Result response)
    {
        if (response.ValidationFailures != null ) return Problem(response.ValidationFailures);
        return response.isSuccess ? Ok(response) : Problem(response.Error);
    }
    
    
}