using RMS.Localization;
using Volo.Abp.AspNetCore.Components;

namespace RMS.Blazor;

public abstract class RMSComponentBase : AbpComponentBase
{
    protected RMSComponentBase()
    {
        LocalizationResource = typeof(RMSResource);
    }
}
