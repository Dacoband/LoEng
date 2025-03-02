using LoEng.Server.Domain.Entities;
using LoEng.Server.Domain.Interfaces.IRepository;
using LoEng.Server.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoEng.Server.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<User> CreateUserAsync(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = password // Lưu ý: Cần mã hóa mật khẩu trước khi lưu
            };
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> UpdateUserAsync(Guid userId, string username, string email)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;

            user.Username = username;
            user.Email = email;
            await _userRepository.UpdateAsync(user);
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            await _userRepository.DeleteAsync(userId);
            return true;
        }
    }
}
