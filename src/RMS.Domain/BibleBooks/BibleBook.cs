using RMS.Verses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace RMS.BibleBooks;

public class BibleBook : FullAuditedEntity<Guid>
{
    public virtual Guid DevotionId { get; protected set; }
    public virtual BookName BookName { get; protected set; }
    public virtual int Chapter { get; protected set; }
    public virtual ICollection<Verse> Verses { get; protected set; }

    protected BibleBook()
    {
        Verses = new Collection<Verse>();
    }
}