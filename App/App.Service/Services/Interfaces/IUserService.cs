using App.Service.Models.UserDTOs;

namespace App.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserDto userDto);
        Task<bool> CheckEmailExistsAsync(string email);
        Task<GetUserDto> LoginUserAsync (LoginUserDto loginUser);
        Task<bool> RenewPasswordAsync(RenewPasswordDto passwordDto);
        Task<GetUserDto> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(UpdateUserDto userDto);
    }
}
