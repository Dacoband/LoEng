using LoEng.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoEng.Server.Domain.Interfaces.IRepository
{
    public interface IUserRepository : IRepositoryGeneric<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
    }
}
