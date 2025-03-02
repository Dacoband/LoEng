using LoEng.Server.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoEng.Server.Application.Commands.User
{
    public class CreateUserCommand : IRequest<UserResponseDTO>
    {
        public UserCreateDTO UserCreateDTO { get; set; }
    }
}
