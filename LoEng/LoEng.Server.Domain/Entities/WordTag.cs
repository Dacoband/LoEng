using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class WordTag
{
    public Guid WordTagId { get; set; }

    public Guid? WordId { get; set; }

    public Guid? TagId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public virtual Tag? Tag { get; set; }

    public virtual Word? Word { get; set; }
}
