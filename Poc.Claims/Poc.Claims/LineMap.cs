using FluentNHibernate.Mapping;

namespace Poc.Claims
{
    public class LineMap : ClassMap<Line>
    {
        public LineMap()
        {
            Id(x => x.Id);
            Map(x => x.ReserveAmount);
            Map(x => x.Type);
        }
    }
}
