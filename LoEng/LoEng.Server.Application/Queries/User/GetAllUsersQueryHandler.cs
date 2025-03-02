using LoEng.Server.Application.DTOs.User;
using LoEng.Server.Domain.Interfaces.IService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoEng.Server.Application.Queries.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserResponseDTO>>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserResponseDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync();

            // Ánh xạ thủ công từ IEnumerable<User> sang IEnumerable<UserResponseDto>
            return users.Select(user => new UserResponseDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                CreatedDate = (DateTime)user.CreatedDate
            });
        }
    }
}
