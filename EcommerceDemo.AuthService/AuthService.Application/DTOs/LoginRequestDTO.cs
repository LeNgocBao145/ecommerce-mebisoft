using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
    public record LoginRequestDTO(
        [Required, EmailAddress] string Email,
        [Required, MinLength(8)] string Password
    );
}
