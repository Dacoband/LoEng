using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public bool? DelFlg { get; set; }

    public virtual ICollection<UserWord> UserWords { get; set; } = new List<UserWord>();
}
