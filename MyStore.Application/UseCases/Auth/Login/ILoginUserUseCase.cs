using MyStore.Application.DTOs.Auth;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Auth.Login;

public interface ILoginUserUseCase
{
    Task<Result<UserDto>> ExecuteAsync(LoginUserDto dto, CancellationToken ct);
}
