
namespace Poc.Claims.Services
{
    public class ClaimantDto
    {
        public virtual long id { get; set; }
        public virtual string name { get; set; }


        public ClaimantDto(Claimant claimant)
        {
            id = claimant.Id;
            name = claimant.Name;
        } 
    }
}
