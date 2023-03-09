using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Linq;
using Poc.Claims.Common;

namespace Poc.Claims
{
    public class Claim : Aggregate<long>
    {
        public virtual IEnumerable<Claimant> Claimants => _claimants;
        //todo: is there a VO here?
        public virtual decimal TotalReserveAmount => Claimants.Sum(claimant => claimant.TotalReserveAmount);

        private readonly IList<Claimant> _claimants;

        protected Claim()
        {

        }

        public Claim(Claimant claimant)
        {
            _claimants = new List<Claimant>() { claimant };
        }

        public virtual void AddClaimant(string name)
        {
            _claimants.Add(new Claimant(name));
        }

        public virtual Claimant GetClaimant(string name)
        {
            return _claimants.Single(claimant => claimant.Name == name);
        }
    }
}