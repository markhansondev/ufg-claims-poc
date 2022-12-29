using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poc.Claims.Services;

namespace Poc.Claims.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FnolsController : ControllerBase
    {
        private readonly ILogger<FnolsController> _logger;
        private readonly FnolService _fnolService;

        public FnolsController(ILogger<FnolsController> logger)
        {
            _logger = logger;
            _fnolService = new FnolService(@"Server=.;Database=ClaimsPoc;Trusted_Connection=true");
        } 

        [HttpGet("{id}")]

        public FnolDto Get(int id)
        {
            return _fnolService.GetFnol(id);
        }

        [HttpPost]
        public ActionResult<FnolDto> Create(FnolDto createFnolDto)
        {
            var fnolDto = _fnolService.CreateFnol(createFnolDto);
            return CreatedAtAction(nameof(Get), new { id = fnolDto.id }, fnolDto);
        }

        [HttpPost("{id}/claims")]
        public ActionResult<ClaimDto> CreateClaim(int id)
        {
            var claimDto = _fnolService.CreateClaim(id);
            return CreatedAtAction(nameof(Get), new { id = claimDto.id }, claimDto);
        }
    }
}
