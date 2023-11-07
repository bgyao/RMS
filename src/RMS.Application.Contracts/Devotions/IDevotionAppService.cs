using RMS.Devotions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RMS.Devotions;

public interface IDevotionAppService : ICrudAppService<DevotionDto, Guid, PagedAndSortedResultRequestDto,CreateDevotionDto,UpdateDevotionDto>
{
}
