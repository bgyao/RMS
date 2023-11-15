using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Devotions.Dtos;

public class DevotionListDto
{
    public Guid? CreatorId { get; set; }
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public string? Title { get; set; }
    public string? Notes { get; set; }
    //public Guid BibleVerseId { get; set; }
    public bool IsDeleted { get; set; }
}
