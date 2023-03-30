using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Poc.Claims
{
    public class PaymentMap : ClassMap<Payment>
    {
        public PaymentMap()
        {
            Id(Reveal.Member<Payment>("Id"));
            Map(x => x.Amount);
        }
    }
}
