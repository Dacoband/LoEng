using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class Tag
{
    public Guid TagId { get; set; }

    public string TagName { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public virtual ICollection<WordTag> WordTags { get; set; } = new List<WordTag>();
}
