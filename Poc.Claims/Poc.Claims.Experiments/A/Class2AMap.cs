using FluentNHibernate.Mapping;

namespace Poc.Claims.Experiments.A
{
    public class Class2AMap : ClassMap<Class2A>
    {
        public Class2AMap()
        {
            Id(x => x.Id);

            HasMany(x => x.Class3As)
                .Cascade.SaveUpdate()
                .Not.LazyLoad();
        }
    }
}
