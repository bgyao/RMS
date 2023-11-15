using RMS.Verses.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace RMS.BibleBooks.Dtos;

public class BibleBookDto : ExtensibleAuditedEntityDto<Guid>
{
    public Guid DevotionId { get; set; }
    public BookName BookName { get; set; }
    public int Chapter { get; set; }
    public List<VerseDto> Verses { get; set; }
}
