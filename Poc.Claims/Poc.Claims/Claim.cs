using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims
{
    public class Claim
    {
        public IEnumerable<Claimant> Claimants => _claimants;
        public decimal TotalReserveAmount => Claimants.Sum(claimant => claimant.TotalReserveAmount);

        private readonly IList<Claimant> _claimants;

        public Claim(Claimant claimant)
        {
            _claimants = new List<Claimant>() { claimant };
        }

        public void AddClaimant(string name)
        {
            _claimants.Add(new Claimant(name));
        }

        public Claimant GetClaimant(string name)
        {
            return _claimants.Single(claimant => claimant.Name == name);
        }
    }
}