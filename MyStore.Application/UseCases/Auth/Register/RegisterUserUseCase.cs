using MyStore.Application.DTOs.Auth;
using MyStore.Application.Interfaces;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Auth.Register;

public class RegisterUserUseCase(IAuthService authService) : IRegisterUserUseCase
{
    public async Task<Result<UserDto>> ExecuteAsync(RegisterUserDto dto, CancellationToken ct)
    {
        var validationResult = await new RegisterUserValidator().ValidateAsync(dto, ct);
        if (!validationResult.IsValid)
            return Result<UserDto>.ValidationError(
                validationResult.Errors.Select(e => e.ErrorMessage));

        return await authService.RegisterAsync(dto, ct);
    }
}
