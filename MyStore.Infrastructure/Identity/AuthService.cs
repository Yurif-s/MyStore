using Microsoft.AspNetCore.Identity;
using MyStore.Application.DTOs.Auth;
using MyStore.Application.Interfaces;
using MyStore.Application.Messages;

namespace MyStore.Infrastructure.Identity;

public class AuthService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : IAuthService
{
    public async Task<Result<UserDto>> LoginAsync(LoginUserDto dto, CancellationToken ct = default)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);

        if (user is null)
            return Result<UserDto>.NotFound(ResourceErrorMessages.USER_NOT_FOUND);

        var signInResult = await signInManager.PasswordSignInAsync(
            user,
            dto.Password,
            isPersistent: false,
            lockoutOnFailure: false);

        if (!signInResult.Succeeded)
            return Result<UserDto>.ValidationError(ResourceErrorMessages.INVALID_CREDENTIALS);

        return Result<UserDto>.Success(new UserDto(user.Fullname, user.Email!));
    }

    public async Task<Result<UserDto>> RegisterAsync(RegisterUserDto dto, CancellationToken ct = default)
    {
        var user = new ApplicationUser
        {
            Fullname = dto.FullName,
            UserName = dto.Email,
            Email = dto.Email,
        };
        var identityResult = await userManager.CreateAsync(user, dto.Password);

        if (!identityResult.Succeeded)
            return Result<UserDto>.ValidationError(
                identityResult.Errors.Select(e => e.Description));

        await userManager.AddToRoleAsync(user, Roles.Customer);
        await signInManager.SignInAsync(user, isPersistent: false);

        return Result<UserDto>.Success(new UserDto(user.Fullname, user.Email!));
    }
}
