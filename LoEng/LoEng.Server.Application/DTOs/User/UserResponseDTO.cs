using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoEng.Server.Application.DTOs.User
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
