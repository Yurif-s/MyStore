using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.DTOs.Auth;
using MyStore.Application.Messages;
using MyStore.Application.UseCases.Auth.Login;
using MyStore.Application.UseCases.Auth.Register;
using MyStore.Infrastructure.Identity;

namespace MyStore.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(
    IRegisterUserUseCase registerUser,
    ILoginUserUseCase loginUser) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto, CancellationToken ct)
    {
        var result = await registerUser.ExecuteAsync(dto, ct);

        return result.Status switch
        {
            ResultStatus.ValidationError => BadRequest(result.Errors),
            _ => Created(string.Empty, result.Value)
        };
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto, CancellationToken ct)
    {
        var result = await loginUser.ExecuteAsync(dto, ct);

        return result.Status switch
        {
            ResultStatus.ValidationError => BadRequest(result.Errors),
            ResultStatus.NotFound => NotFound(result.Errors),
            _ => Ok(result.Value)
        };
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromServices] SignInManager<ApplicationUser> signInManager)
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }
}
