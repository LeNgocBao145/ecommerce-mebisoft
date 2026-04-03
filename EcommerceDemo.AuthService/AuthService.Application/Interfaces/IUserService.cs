using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserResponseDTO> Register(UserRequestDTO userRequestDTO);
        Task<UserResponseDTO> GetUserById(Guid userId);
    }
}
