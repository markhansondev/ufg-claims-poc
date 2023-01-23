using FluentNHibernate.Mapping;

namespace Poc.Claims.Experiments.A
{
    public class Class3AMap : ClassMap<Class3A>
    {
        public Class3AMap()
        {
            Id(x => x.Id);
        }
    }
}
