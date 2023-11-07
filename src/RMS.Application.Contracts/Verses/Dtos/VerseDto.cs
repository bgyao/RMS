using System;
using Volo.Abp.Application.Dtos;

namespace RMS.Verses.Dtos;

public class VerseDto : EntityDto<Guid>
{
    public Guid BibleBookId { get; set; }
    public byte VerseNumber { get; set; }
}
