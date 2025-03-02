using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class WordType
{
    public Guid WordTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public virtual ICollection<Word> Words { get; set; } = new List<Word>();
}
