using RMS.Devotions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RMS.Devotions;

public class DevotionAppService :
    CrudAppService<Devotion,
        DevotionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateDevotionDto,
        UpdateDevotionDto>
{
    public DevotionAppService(IRepository<Devotion, Guid> repository) : base(repository)
    {
    }
}
