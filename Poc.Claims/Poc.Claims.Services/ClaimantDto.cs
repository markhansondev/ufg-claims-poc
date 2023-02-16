
using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims.Services
{
    public class ClaimantDto
    {
        public virtual long id { get; set; }
        public virtual string name { get; set; }
        public virtual IEnumerable<LineDto> lines { get; set; }

        public ClaimantDto()
        {
        }

        public ClaimantDto(Claimant claimant)
        {            
            id = claimant.Id;
            name = claimant.Name;
            lines = claimant.Lines.Select(line => new LineDto(line)).ToList();
        }
    }
}
