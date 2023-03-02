
using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims.Services
{
    public class ClaimantDto
    {
        public virtual string name { get; set; }
        public virtual IEnumerable<LineDto> lines { get; set; }

        public ClaimantDto()
        {
        }

        public ClaimantDto(Claimant claimant)
        {            
            name = claimant.Name;
            lines = claimant.Lines.Select(line => new LineDto(line)).ToList();
        }
    }
}
