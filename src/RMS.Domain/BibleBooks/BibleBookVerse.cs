using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace RMS.BibleBooks;

public class BibleBookVerse : Entity<Guid>
{
    public virtual Guid BibleBookId { get; protected set; }
    public virtual Guid VerseId { get; protected set; }

    internal BibleBookVerse(Guid bibleBookId, Guid verseId)
    {
        BibleBookId = bibleBookId;
        VerseId = verseId;
    }
}
