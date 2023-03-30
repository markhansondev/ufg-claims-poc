using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Poc.Claims
{
    public class LineMap : ClassMap<Line>
    {
        public LineMap()
        {
            Id(Reveal.Member<Line>("Id"));
            Map(x => x.ReserveAmount);
            Map(x => x.Type);

            HasMany(x => x.Payments)
                .Cascade.SaveUpdate()
                .Not.LazyLoad();
        }
    }
}
