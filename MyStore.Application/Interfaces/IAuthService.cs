using MyStore.Application.DTOs.Auth;
using MyStore.Application.Messages;

namespace MyStore.Application.Interfaces;

public interface IAuthService
{
    Task<Result<UserDto>> RegisterAsync(RegisterUserDto dto, CancellationToken ct = default);
    Task<Result<UserDto>> LoginAsync(LoginUserDto dto, CancellationToken ct = default);
}
