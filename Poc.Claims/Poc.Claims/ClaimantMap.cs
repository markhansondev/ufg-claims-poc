using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Poc.Claims
{
    public class ClaimantMap : ClassMap<Claimant>
    {
        public ClaimantMap()
        {
            Id(Reveal.Member<Claimant>("Id"));
            Map(x => x.Name).Nullable();

            HasMany(x => x.Lines)
                .Cascade.SaveUpdate()
                .Not.LazyLoad();
        }
    }
}
