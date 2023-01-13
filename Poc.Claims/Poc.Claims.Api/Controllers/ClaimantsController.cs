using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poc.Claims.Services;

namespace Poc.Claims.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimantsController : ControllerBase
    {
        private readonly ILogger<ClaimantsController> _logger;
        private readonly ClaimantService _claimantService;

        public ClaimantsController(ILogger<ClaimantsController> logger)
        {
            _logger = logger;
            _claimantService = new ClaimantService(@"Server=.;Database=ClaimsPoc;Trusted_Connection=true");
        }

        [HttpGet("{id}")]

        public ClaimantDto Get(int id)
        {
            return _claimantService.GetClaimant(id);
        }

        [HttpPost("{id}/lines")]
        public ActionResult<ClaimantDto> AddLine(long id, AddLineDto addLineDto)
        {
            var claimantDto = _claimantService.AddLine(id, addLineDto);
            return CreatedAtAction(nameof(Get), new { id = claimantDto.id }, claimantDto);
        }
    }
}
