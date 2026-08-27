namespace MyStore.Application.DTOs.Auth;

public record RegisterUserDto(
    string FullName,
    string Email,
    string Password
);
