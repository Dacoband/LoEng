using AutoMapper;
using LoEng.Server.Application.DTOs.User;
using LoEng.Server.Domain.Interfaces.IService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoEng.Server.Application.Commands.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDTO>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserResponseDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.CreateUserAsync(
                request.UserCreateDTO.Username,
                request.UserCreateDTO.Email,
                request.UserCreateDTO.Password
            );

            // Ánh xạ thủ công từ User sang UserResponseDto
            return new UserResponseDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
            };
        }
    }
}

