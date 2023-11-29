using Microsoft.AspNetCore.Components;
using RMS.Devotions;
using RMS.Devotions.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace RMS.Blazor.Pages.Devotions;

public partial class Index
{
    public List<DevotionDto> DevotionsList = new();

    #region Injections

    // Follow this pattern:
    // [Inject]
    // private IInterface _interface { get; set; }

    [Inject]
    private IDevotionAppService _devotionAppService { get; set; }

    [Inject]
    private ICurrentUser _currentUser { get; set; }
    #endregion
    
    //Create a shareable Interface called IIsEmpty with property bool IsEmpty get set
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                var userId = _currentUser.GetId();
                //need to fix user authentication.
                DevotionsList = await _devotionAppService.GetDevotionsByCreatorId(userId);
            }
            catch(Exception ex)
            {
                string innerException = string.Empty;
                if (ex.InnerException != null)
                    innerException = $"\nInnerException:{ex.InnerException.Message}";

                Console.WriteLine($"Error: {ex.Message}{innerException}");
            }
            finally
            {

            }
                


        }
    }
}
