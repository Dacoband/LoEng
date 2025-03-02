using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class Level
{
    public Guid LevelId { get; set; }

    public string LevelName { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public virtual ICollection<UserWord> UserWords { get; set; } = new List<UserWord>();

    public virtual ICollection<Word> Words { get; set; } = new List<Word>();
}
