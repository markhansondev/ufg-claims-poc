using FluentNHibernate.Mapping;

namespace Poc.Claims.Experiments.B
{
    public class Class1BMap : ClassMap<Class1B>
    {
        public Class1BMap()
        {
            Id(x => x.Id);

            HasMany(x => x.Class2BBriefs)
                .Cascade.SaveUpdate()
                .Not.LazyLoad();
        }
    }
}
