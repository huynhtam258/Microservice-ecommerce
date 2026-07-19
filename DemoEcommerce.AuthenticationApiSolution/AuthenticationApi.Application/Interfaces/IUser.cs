using AuthenticationApi.Application.DTO;
using eCommerce.ShareLibrary.Responses;

namespace AuthenticationApi.Application.Interfaces
{
    public interface IUser
    {
        Task<Response> Register(AppUserDTO appUserDTO);
        Task<Response> Login(LoginDTO LoginDTO);
        Task<GetUserDTO> GetUser(int userId);
        //Task<AppUserDTO> GetUserByEmail(string userEmail);
    }
}
