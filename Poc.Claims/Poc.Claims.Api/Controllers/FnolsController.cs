using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<FnolDto> Create(FnolDto fnolDto)
        {
            var fnol = _fnolService.CreateFnol(fnolDto);
            return CreatedAtAction("Create", new { id = fnol.Id }, fnol);
        }

        [HttpPost("{id}/claims")]
        public ActionResult<Claim> CreateClaim(int id)
        {
            var claim = _fnolService.CreateClaim(id);
            return CreatedAtAction("Create", new { id = 1 }, claim);
        }

    }
}
