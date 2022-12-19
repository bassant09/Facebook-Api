using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.Models;

namespace Facebook_Api.Services.Authantication_Folder
{
    public interface IAuthanticationRepository
    {
       Task <ServicesRespone<int>> Register (User user, string Password);
        Task<ServicesRespone<string>> Login(string Email, string Password);
        Task<ServicesRespone<UserGetDto>> UpdateProfile(UserUpdateDto user);

        Task<bool>UserExist(String Username );   

    }
}
