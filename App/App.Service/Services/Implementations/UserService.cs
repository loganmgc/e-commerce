using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.UserDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task AddUserAsync(AddUserDto userDto)
        {
            var userEntity = _mapper.Map<UserEntity>(userDto);
            await _repositoryManager.UserRepository.AddAsync(userEntity);
            await _repositoryManager.UserRepository.SaveAsync();
        }

        public async Task<bool> ApproveSellerAsync(int id)
        {
            var existingUser = await _repositoryManager.UserRepository.GetByIdAsync(id);
            if (existingUser is null)
            {
                return false;
            }
            existingUser.RoleId = 2;
            _repositoryManager.UserRepository.Update(existingUser);
            await _repositoryManager.UserRepository.SaveAsync();
            return true;
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

        public async Task<IEnumerable<GetUserWithIdDto>> GetAllUsersAsync()
        {
            var userList = await _repositoryManager.UserRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<GetUserWithIdDto>>(userList);
        }

        public async Task<GetUserWithoutIdDto> GetUserByIdAsync(int id)
        {
            var existingUser = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (existingUser is null)
            {
                return null;
            }
            return _mapper.Map<GetUserWithoutIdDto>(existingUser);
        }

        public async Task<GetUserWithIdDto> LoginUserAsync(LoginUserDto loginUser)
        {
            var existingUser = await _repositoryManager.UserRepository.GetUserByEmailAsync(loginUser.Email);
            if (existingUser is null || existingUser.Password != loginUser.Password || existingUser.Enabled == false)
            {
                return null;
            }
            return _mapper.Map<GetUserWithIdDto>(existingUser);
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
            existingUser = _mapper.Map(userDto, existingUser);
            _repositoryManager.UserRepository.Update(existingUser);
            await _repositoryManager.UserRepository.SaveAsync();
            return true;
        }
    }
}
