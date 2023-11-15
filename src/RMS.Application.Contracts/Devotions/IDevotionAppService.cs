using RMS.Devotions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RMS.Devotions;

public interface IDevotionAppService : ICrudAppService<DevotionDto, Guid, PagedAndSortedResultRequestDto,CreateDevotionDto,UpdateDevotionDto>
{
    Task<List<DevotionDto>> GetDevotionsByCreatorId(Guid creatorId);
    //TODO: override for UpdateAsync(Guid devotionId), check AppService
    //Task<DevotionDto> UpdateAsync(Guid devotionId);
    
}
