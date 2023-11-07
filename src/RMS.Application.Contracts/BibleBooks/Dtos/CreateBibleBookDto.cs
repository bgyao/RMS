using RMS.Verses.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace RMS.BibleBooks.Dtos;

public class CreateBibleBookDto : EntityDto<Guid>
{
    public Guid DevotionId { get; set; }
    public BookName BookName { get; set; }
    public int Chapter { get; set; }
    public List<CreateVerseDto> Verses { get; set; }
}
