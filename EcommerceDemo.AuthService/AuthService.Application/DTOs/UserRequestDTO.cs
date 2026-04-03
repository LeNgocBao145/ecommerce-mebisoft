using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
    public record UserRequestDTO(
        [Required] string Username,
        [Required, EmailAddress] string Email,
        [Required, MinLength(8)] string Password
    );
}
