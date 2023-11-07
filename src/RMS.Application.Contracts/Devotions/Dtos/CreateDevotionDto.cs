using RMS.BibleBooks.Dtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace RMS.Devotions.Dtos;

public class CreateDevotionDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public string? Title { get; set; }
    public string? Notes { get; set; }
    public List<CreateBibleBookDto> BibleBooks { get; set; }
}
