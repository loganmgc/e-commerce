using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.UserDTOs;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task AddUserAsync(AddUserDto userDto)
        {
            var userEntity = new UserEntity
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                RoleId = 3
            };
            await _repositoryManager.UserRepository.AddAsync(userEntity);
            await _repositoryManager.UserRepository.SaveAsync();
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            var user = await _repositoryManager.UserRepository.GetUserByEmailAsync(email);
            if (user is not null)
            {
                return false;
            }
            return true;
        }

        public async Task<GetUserDto> GetUserByIdAsync(int id)
        {
            var existingUser = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (existingUser is null)
            {
                return null;
            }
            var user = new GetUserDto
            {
                Email = existingUser.Email,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                RoleName = existingUser.Role.Name,
                CreatedAt = existingUser.CreatedAt
            };
            return user;
        }

        public async Task<GetUserDto> LoginUserAsync(LoginUserDto loginUser)
        {
            var existingUser = await _repositoryManager.UserRepository.GetUserByEmailAsync(loginUser.Email);
            if (existingUser is null || existingUser.Password != loginUser.Password || existingUser.Enabled == false)
            {
                return null;
            }
            var user = new GetUserDto
            {
                UserId = existingUser.UserId,
                Email = existingUser.Email,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                RoleName = existingUser.Role.Name,
            };
            return user;
        }

        public async Task<bool> RenewPasswordAsync(RenewPasswordDto passwordDto)
        {
            var existingUser = await _repositoryManager.UserRepository.GetByIdAsync(passwordDto.UserId);
            if (existingUser is null || existingUser.Password != passwordDto.OldPassword)
            {
                return false;
            }
            existingUser.Password = passwordDto.NewPassword;
            _repositoryManager.UserRepository.Update(existingUser);
            await _repositoryManager.UserRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto userDto)
        {
            var existingUser = await _repositoryManager.UserRepository.GetByIdAsync(userDto.UserId);
            if (existingUser is null)
            {
                return false;
            }
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            _repositoryManager.UserRepository.Update(existingUser);
            await _repositoryManager.UserRepository.SaveAsync();
            return true;
        }
    }
}
