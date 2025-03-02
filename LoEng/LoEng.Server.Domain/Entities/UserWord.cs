using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class UserWord
{
    public int UserWordId { get; set; }

    public int? UserId { get; set; }

    public int? WordId { get; set; }

    public bool? IsLearned { get; set; }

    public DateTime? LastReviewedDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public int? LevelId { get; set; }

    public virtual Level? Level { get; set; }

    public virtual User? User { get; set; }

    public virtual Word? Word { get; set; }
}
