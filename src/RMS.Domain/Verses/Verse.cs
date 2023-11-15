using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace RMS.Verses;

public class Verse : FullAuditedEntity<Guid>
{
    public virtual Guid BibleBookId { get; protected set; }
    public virtual byte VerseNumber { get; protected set; }
}
// TODO: Check ProductOption (Many) to Product (One) relationship for Verse-BibleBook