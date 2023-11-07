using Microsoft.EntityFrameworkCore;
using RMS.BibleBooks;
using RMS.Devotions;
using RMS.Verses;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace RMS.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class RMSDbContext :
    AbpDbContext<RMSDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Devotion> Devotions { get; set; }
    public DbSet<BibleBook> BibleBooks { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public RMSDbContext(DbContextOptions<RMSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<Devotions>(b =>
        //{
        //    b.ToTable(RMSConsts.DbTablePrefix + "YourEntities", RMSConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props


        //    //...
        //});

        ConfigureDevotions(builder);
        ConfigureBibleBooks(builder);
        ConfigureVerses(builder);
    }

    private void ConfigureDevotions(ModelBuilder builder)
    {
        builder.Entity<Devotion>(b =>
        {
            b.ToTable(RMSConsts.DbTablePrefix + "Devotions" + RMSConsts.DbSchema);
            b.ConfigureByConvention();
            //Devotion:
            //HasMany Bible Verses With One Devotion

            b.HasMany(x => x.BibleBooks).WithOne().HasForeignKey(x => x.DevotionId).IsRequired();
        });
    }

    private void ConfigureBibleBooks(ModelBuilder builder)
    {
        builder.Entity<BibleBook>(b =>
        {
            b.ToTable(RMSConsts.DbTablePrefix + "BibleBooks" + RMSConsts.DbSchema);
            b.ConfigureByConvention();
            
            //BibleBooks:
            //HasOne Devotion WithMany BibleBooks
            b.HasOne<Devotion>().WithMany(x => x.BibleBooks).HasForeignKey(x => x.DevotionId);

            //HasMany Verses WithOne BibleBook
            b.HasMany(c => c.Verses).WithOne().HasForeignKey(x => x.BibleBookId).IsRequired();
        });
    }

    private void ConfigureVerses(ModelBuilder builder)
    {
        builder.Entity<Verse>(b =>
        {
            b.ToTable(RMSConsts.DbTablePrefix + "Verses" + RMSConsts.DbSchema);
            b.ConfigureByConvention();

            //Verses:
            //HasOne BibleBook WithMany Verses
            b.HasOne<BibleBook>().WithMany(x => x.Verses).HasForeignKey(x => x.BibleBookId);
        });
    }
}
