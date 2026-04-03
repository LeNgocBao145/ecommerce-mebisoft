using AuthService.Domain.Enums;

namespace AuthService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public UserRole Role { get; set; } = UserRole.User;
    }
}
