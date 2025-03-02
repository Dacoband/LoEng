using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class Topic
{
    public Guid TopicId { get; set; }

    public string TopicName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public virtual ICollection<Word> Words { get; set; } = new List<Word>();
}
