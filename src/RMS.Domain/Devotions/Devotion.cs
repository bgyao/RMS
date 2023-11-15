using RMS.BibleBooks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace RMS.Devotions;

public class Devotion : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }
    public virtual string? Title { get; protected set; }
    public virtual string? Notes { get; protected set; }
    public virtual ICollection<BibleBook> BibleBooks { get; protected set; }
    public virtual DevotionType Type { get; protected set; }

    protected Devotion()
    {
        BibleBooks = new Collection<BibleBook>();
    }

    //NOTE: Might be needed later.
    //public virtual void AddBibleBooks(List<BibleBook> bibleBooks)
    //{
    //  BibleBooks.Clear();
    //  bibleBooks.ForEach(BibleBooks.Add);
    //}
}

// TODO: Check Product (One) to ProductOption (Many) relationship for Devotion-BibleBook