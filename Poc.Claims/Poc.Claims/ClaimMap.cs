using FluentNHibernate.Mapping;

namespace Poc.Claims
{
    public class ClaimMap : ClassMap<Claim>
    {
        public ClaimMap()
        {
            Id(x => x.Id);
            //Map(x => x.IsReadyToBeCompleted);
            //Map(x => x.FnolLineLiabilityAmount);
            //Map(x => x.LineType);
            //Map(x => x.ClaimantName);
        }
    }
}
