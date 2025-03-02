using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class Synonym
{
    public Guid SynonymId { get; set; }

    public Guid? WordId { get; set; }

    public string SynonymWord { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public virtual Word? Word { get; set; }
}
