using App.Service.Models.UserDTOs;

namespace App.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserDto userDto);
        Task<bool> CheckEmailExistsAsync(string email);
        Task<GetUserWithIdDto> LoginUserAsync (LoginUserDto loginUser);
        Task<bool> RenewPasswordAsync(RenewPasswordDto passwordDto);
        Task<GetUserWithoutIdDto> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(UpdateUserDto userDto);
        Task<IEnumerable<GetUserWithIdDto>> GetAllUsersAsync();
        Task<bool> ApproveSellerAsync(int id);
    }
}
