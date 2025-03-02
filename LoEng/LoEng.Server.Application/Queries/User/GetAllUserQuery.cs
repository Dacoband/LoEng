using LoEng.Server.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoEng.Server.Application.Queries.User
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserResponseDTO>>
    {
    }
}
