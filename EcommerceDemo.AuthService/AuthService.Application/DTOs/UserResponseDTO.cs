using AuthService.Domain.Enums;

namespace AuthService.Application.DTOs
{
    public record UserResponseDTO(
        Guid Id,
        string Username,
        string Email,
        DateTime CreatedAt,
        UserRole Role
    );
}
