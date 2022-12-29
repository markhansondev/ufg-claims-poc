using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poc.Claims.Services;

namespace Poc.Claims.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ILogger<ClaimsController> _logger;
        private readonly ClaimService _claimService;

        public ClaimsController(ILogger<ClaimsController> logger)
        {
            _logger = logger;
            _claimService = new ClaimService(@"Server=.;Database=ClaimsPoc;Trusted_Connection=true");
        } 

        [HttpGet("{id}")]

        public ClaimDto Get(int id)
        {
            return _claimService.GetClaim(id);
        }

        [HttpPost("{id}/claimants")]
        public ActionResult<ClaimDto> AddClaimant(long id, AddClaimantDto claimantDto)
        {
            var claimDto = _claimService.AddClaimant(id, claimantDto);
            return CreatedAtAction(nameof(Get), new { id = claimDto.id }, claimDto);
        }
    }
}
