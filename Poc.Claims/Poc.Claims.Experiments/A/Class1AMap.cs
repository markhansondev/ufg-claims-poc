using FluentNHibernate.Mapping;

namespace Poc.Claims.Experiments.A
{
    public class Class1AMap : ClassMap<Class1A>
    {
        public Class1AMap()
        {
            Id(x => x.Id);

            HasMany(x => x.Class2As)
                .Cascade.SaveUpdate()
                .LazyLoad();
        }
    }
}
