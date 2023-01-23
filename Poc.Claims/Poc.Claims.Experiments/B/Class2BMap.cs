using FluentNHibernate.Mapping;

namespace Poc.Claims.Experiments.B
{
    public class Class2BMap : ClassMap<Class2B>
    {
        public Class2BMap()
        {
            Id(x => x.Id);

            HasMany(x => x.Class3Bs)
                .Cascade.SaveUpdate()
                .Not.LazyLoad();
        }
    }
}
