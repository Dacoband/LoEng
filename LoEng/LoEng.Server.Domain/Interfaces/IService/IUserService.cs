using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoEng.Server.Domain.Entities;

namespace LoEng.Server.Domain.Interfaces.IService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);
        Task<User> CreateUserAsync(string username, string email, string password);
        Task<User> UpdateUserAsync(Guid userId, string username, string email);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
