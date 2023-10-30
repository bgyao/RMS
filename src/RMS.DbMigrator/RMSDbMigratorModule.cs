using RMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace RMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(RMSEntityFrameworkCoreModule),
    typeof(RMSApplicationContractsModule)
    )]
public class RMSDbMigratorModule : AbpModule
{
}
