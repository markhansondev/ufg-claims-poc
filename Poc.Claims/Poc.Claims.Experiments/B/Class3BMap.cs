using FluentNHibernate.Mapping;

namespace Poc.Claims.Experiments.B
{
    public class Class3BMap : ClassMap<Class3B>
    {
        public Class3BMap()
        {
            Id(x => x.Id);
        }
    }
}
