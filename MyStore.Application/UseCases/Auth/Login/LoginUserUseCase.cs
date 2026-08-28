using MyStore.Application.DTOs.Auth;
using MyStore.Application.Interfaces;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Auth.Login;

public class LoginUserUseCase(IAuthService authService) : ILoginUserUseCase
{
    public async Task<Result<UserDto>> ExecuteAsync(LoginUserDto dto, CancellationToken ct)
    {
        var validationResult = await new LoginUserValidation().ValidateAsync(dto, ct);
        if (!validationResult.IsValid)
            return Result<UserDto>.ValidationError(
                validationResult.Errors.Select(e => e.ErrorMessage));

        return await authService.LoginAsync(dto, ct);
    }
}
