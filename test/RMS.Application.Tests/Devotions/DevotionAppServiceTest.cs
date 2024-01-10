using RMS.BibleBooks;
using RMS.BibleBooks.Dtos;
using RMS.Devotions.Dtos;
using RMS.Verses.Dtos;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace RMS.Devotions;

public class DevotionAppServiceTest : RMSApplicationTestBase
{
    private readonly IDevotionAppService _devotionAppService;

    public DevotionAppServiceTest()
    {
        _devotionAppService = GetRequiredService<IDevotionAppService>();
    }
    /* WHERE I STOPPED:
     *      - Di ma-access ng test yung database??? may laman yung database na Test 123 pero di
     *      makita ng tests.
     *      
     *      - Di gumagana yung ShouldNotCreateDevotionWithOutBibleBooks
     */

    [Fact]
    public async Task ShouldGetListOfDevotions()
    {
        //Act
        var result = await _devotionAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
                {
                    MaxResultCount = 999,
                    SkipCount = 0,
                    Sorting = ""
                }
            );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(d => d.Title == "Test 123");
    }

    [Fact]
    public async Task ShouldGetDevotionById()
    {
        //Act
        var result = await _devotionAppService.GetAsync(new Guid("aaf7aeca-42fc-4974-17ed-3a0f0c342cb7"));

        //Assert
        result.Title.ShouldBe("Test 123");
    }

    [Fact]
    public async Task ShouldCreateAValidDevotion()
    {
        //Act
        var result = await _devotionAppService.CreateAsync(
            new CreateDevotionDto
            {
                TenantId = null,
                Title = "Devotions Test",
                Notes = "Test",
                BibleBooks =
                    [
                        new CreateBibleBookDto()
                        {
                            BookName = BookName.Genesis,
                            Chapter = 1,
                            Verses =
                            [
                                new CreateVerseDto()
                                {
                                    VerseNumber = 1
                                },
                                new CreateVerseDto()
                                {
                                    VerseNumber = 2
                                }
                            ]
                        },
                        new CreateBibleBookDto()
                        {
                            BookName = BookName.John,
                            Chapter = 1,
                            Verses =
                            [
                                new CreateVerseDto()
                                {
                                    VerseNumber = 1
                                },
                                new CreateVerseDto()
                                {
                                    VerseNumber = 2
                                }
                            ]
                        }
                    ]
                
            });

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.BibleBooks.ForEach(b => b.Id.ShouldNotBe(Guid.Empty));
        result.BibleBooks.ForEach(b => b.Verses.ForEach(v => v.Id.ShouldNotBe(Guid.Empty)));
        result.Title.ShouldBe("Devotions Test");
    }

    [Fact]
    public async Task ShouldNotCreateDevotionWithOutBibleBooks()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(
            async () =>
            {
                await _devotionAppService.CreateAsync(
                    new CreateDevotionDto
                    {
                        TenantId = null,
                        Title = "",
                        Notes = "Test",
                        BibleBooks = []
                    });
            }

        );

        exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "BibleBooks"));
    }
}
