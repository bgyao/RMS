using RMS.Devotions.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Volo.Abp.Data;
using RMS.BibleBooks;
using RMS.Verses;

namespace RMS.Devotions;

public class DevotionAppService :
    CrudAppService<Devotion,
        DevotionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateDevotionDto,
        UpdateDevotionDto>, IDevotionAppService
{
    public IRepository<BibleBook> _bibleBookRepository;
    public IRepository<Verse> _verseRepository;

    public DevotionAppService(
        IRepository<Devotion, Guid> repository,
        IRepository<BibleBook, Guid> bibleBookRepository,
        IRepository<Verse, Guid> verseRepository) : base(repository)
    {
        _bibleBookRepository = bibleBookRepository;
        _verseRepository = verseRepository;
    }

    protected override async Task<DevotionDto> MapToGetOutputDtoAsync(Devotion entity)
    {
        try
        {
            if (entity.IsDeleted)
            {
                return default;
            }
            var query = await Repository.WithDetailsAsync();

            var devotion = await query.IgnoreQueryFilters()
                .Include(x => x.BibleBooks)
                    .ThenInclude(x => x.Verses)
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (devotion is null)
            {
                return default;
            }
            return ObjectMapper.Map<Devotion, DevotionDto>(devotion);

        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    public async Task<List<DevotionDto>> GetDevotionsByCreatorId(Guid creatorId)
    {
        try
        {
            var query = await Repository.WithDetailsAsync();

            List<Devotion> devotions = new();

            foreach(var item in query.Where(x => x.CreatorId == creatorId))
            {
                devotions.Add(item);
            }

            return ObjectMapper.Map<List<Devotion>, List<DevotionDto>>(devotions);
        }
        catch (Exception ex)
        {
            string innerException = string.Empty;
            if (ex.InnerException != null)
                innerException = $"\nInnerException:{ex.InnerException.Message}";

            throw new UserFriendlyException($"{ex.Message}{innerException}");
        }
    }

    //NOTE: Using UpdateAsync.
    //      ids of devotionId, bibleBookId, and verseId should be present
    //NOTE: Deleting Bible Books and Verses
    //      - lagay dito yung delete method ng BibleBooks tsaka Verses. Check ProductMediaFiles kung paano
    //          binubura sa UpdateAsync method

    //public override async Task<DevotionDto> UpdateAsync(Guid devotionId, UpdateDevotionDto input)
    //{
    //    try
    //    {
    //        await CheckUpdatePolicyAsync();
    //        var query = await ReadOnlyRepository.GetQueryableAsync();
    //        var result = query.IgnoreQueryFilters().FirstOrDefault(x => x.Id == devotionId);

    //        ObjectMapper.Map(input, result);

    //        await CurrentUnitOfWork.SaveChangesAsync();

    //        //foreach(var bibleBook in input.BibleBooks)
    //        //{
    //        //    bibleBook.DevotionId = devotionId;

    //        //    var bibleBookQuery = query.IgnoreQueryFilters()
    //        //        .FirstOrDefault(c => c.Id == bibleBook.Id);
    //        //}

    //        return await MapToGetOutputDtoAsync(result);

    //        //        Note: Ang default ng UpdateAsync is to add lang ng add ng BibleBooks and Verses sa list.
    //        //        TODO: Dapat yung mga BibleBooks and Verses na binura ni user, magreflect as deleted.
    //        //              Yung mga bagong dagdag, pasok lang.
    //        //          Flow:
    //        //                  - user edits the Devotion
    //        //                  - Save
    //        //                  - Expected payload should have:
    //        //                      * edited Devotions
    //        //                      * edited Verses
    //        //                      * edited BibleBooks
    //        //                      * added BibleBooks+Verses
    //        //
    //        //          
    //    }
    //    catch (Exception ex)
    //    {
    //        string innerException = string.Empty;
    //        if (ex.InnerException != null)
    //            innerException = $"\nInnerException:{ex.InnerException.Message}";

    //        throw new UserFriendlyException($"{ex.Message}{innerException}");
    //    }
    //}
}
