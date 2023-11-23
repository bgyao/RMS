using RMS.Verses.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace RMS.BibleBooks.Dtos;

public class UpdateBibleBookDto : EntityDto<Guid>
{
    public Guid DevotionId { get; set; }
    public BookName BookName { get; set; }
    public int Chapter { get; set; }
    public List<UpdateVerseDto> Verses { get; set; }
}
