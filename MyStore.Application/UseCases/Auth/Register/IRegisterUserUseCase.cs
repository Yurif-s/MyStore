using MyStore.Application.DTOs.Auth;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Auth.Register;

public interface IRegisterUserUseCase
{
    Task<Result<UserDto>> ExecuteAsync(RegisterUserDto dto, CancellationToken ct); 
}
