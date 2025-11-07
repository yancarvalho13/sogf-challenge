using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;
using Solution.Application.Contracts.Security;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;

namespace Solution.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class AuthenticationController : BaseController
{
    private readonly IUserService _userService;

    public AuthenticationController( IUserService userService)
    {
        _userService = userService;
    }

    
    [HttpPost("/login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        var response = await _userService.Login(request);
        return HandleResponse(response);
    }

    [HttpPost("/Register")]
    public async Task<IActionResult> Register([FromBody]UserRequest request)
    {
        var response = await _userService.Register(request);
        return HandleResponse(response);
    }
}