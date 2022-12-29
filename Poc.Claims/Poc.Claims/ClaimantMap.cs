﻿using FluentNHibernate.Mapping;

namespace Poc.Claims
{
    public class ClaimantMap : ClassMap<Claimant>
    {
        public ClaimantMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Nullable();
        }
    }
}
