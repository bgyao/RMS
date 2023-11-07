using AutoMapper;
using RMS.Devotions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Devotions;

public class DevotionAutoMapperProfile : Profile
{
    public DevotionAutoMapperProfile()
    {
        CreateMap<Devotion, DevotionDto>().ReverseMap();
        CreateMap<CreateDevotionDto, Devotion>();
        CreateMap<UpdateDevotionDto, Devotion>();
    }
}
