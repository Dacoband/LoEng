using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class Example
{
    public Guid ExampleId { get; set; }

    public Guid? WordId { get; set; }

    public string EnglishExample { get; set; } = null!;

    public string VietnameseMeaning { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public virtual Word? Word { get; set; }
}
