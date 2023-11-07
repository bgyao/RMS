using System;
using Volo.Abp.Domain.Entities;

namespace RMS.Verses;

public class Verse : Entity<Guid>
{
    public virtual Guid BibleBookId { get; protected set; }
    public virtual byte VerseNumber { get; protected set; }
}
// TODO: Check ProductOption (Many) to Product (One) relationship for Verse-BibleBook