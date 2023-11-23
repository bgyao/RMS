using System;
using Volo.Abp.Application.Dtos;

namespace RMS.Verses.Dtos;

public class VerseDto : ExtensibleAuditedEntityDto<Guid>
{
    public Guid BibleBookId { get; set; }
    public byte VerseNumber { get; set; }
}
