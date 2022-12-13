using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims
{
    public class Claim
    {
        public virtual long Id { get; protected set; }
        public virtual IEnumerable<Claimant> Claimants => _claimants;
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