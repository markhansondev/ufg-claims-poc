using FluentNHibernate.Mapping;

namespace Poc.Claims.Experiments.B
{
    public class Class2BBriefMap : ClassMap<Class2BBrief>
    {
        public Class2BBriefMap()
        {
            Table("Class2B");
            Id(x => x.Id, "Class2BID");
        }
    }
}
