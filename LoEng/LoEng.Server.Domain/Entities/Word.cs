using System;
using System.Collections.Generic;

namespace LoEng.Server.Domain.Entities;

public partial class Word
{
    public Guid WordId { get; set; }

    public string EnglishWord { get; set; } = null!;

    public string VietnameseMeaning { get; set; } = null!;

    public string? Pronunciation { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public Guid? TopicId { get; set; }

    public Guid? WordTypeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DelFlg { get; set; }

    public Guid? LevelId { get; set; }

    public virtual ICollection<Example> Examples { get; set; } = new List<Example>();

    public virtual Level? Level { get; set; }

    public virtual ICollection<Synonym> Synonyms { get; set; } = new List<Synonym>();

    public virtual Topic? Topic { get; set; }

    public virtual ICollection<UserWord> UserWords { get; set; } = new List<UserWord>();

    public virtual ICollection<WordTag> WordTags { get; set; } = new List<WordTag>();

    public virtual WordType? WordType { get; set; }
}
