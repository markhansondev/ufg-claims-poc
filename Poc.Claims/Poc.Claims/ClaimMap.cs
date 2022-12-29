using FluentNHibernate.Mapping;

namespace Poc.Claims
{
    public class ClaimMap : ClassMap<Claim>
    {
        public ClaimMap()
        {
            Id(x => x.Id);

            HasMany(x => x.Claimants)
                .Cascade.SaveUpdate()
                .Not.LazyLoad();
            //.Inverse();
        }
    }
}
