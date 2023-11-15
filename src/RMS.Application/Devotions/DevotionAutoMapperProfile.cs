using AutoMapper;
using RMS.BibleBooks;
using RMS.BibleBooks.Dtos;
using RMS.Devotions.Dtos;
using RMS.Verses;
using RMS.Verses.Dtos;
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
        #region Devotions
        CreateMap<Devotion, DevotionDto>().ReverseMap();
        CreateMap<CreateDevotionDto, Devotion>();
        CreateMap<UpdateDevotionDto, Devotion>();
        #endregion

        #region BibleBooks
        CreateMap<BibleBook, BibleBookDto>().ReverseMap();
        CreateMap<CreateBibleBookDto, BibleBook>();
        CreateMap<UpdateBibleBookDto, BibleBook>().ReverseMap();
        #endregion

        #region Verses
        CreateMap<Verse, VerseDto>().ReverseMap();
        CreateMap<CreateVerseDto, Verse>();
        CreateMap<UpdateVerseDto, Verse>();
        #endregion
    }
}
