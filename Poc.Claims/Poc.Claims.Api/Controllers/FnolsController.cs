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

        public FnolsController(ILogger<FnolsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]

        public FnolDto Get(int id)
        {
            return new FnolService().GetFnol(id);
        }

        [HttpPost]
        public ActionResult<FnolDto> Create(FnolDto fnolDto)
        {
            var fnol = new FnolService().CreateFnol(fnolDto);
            return CreatedAtAction("Create", new { id = fnol.Id }, fnol);
        }

        [HttpPost("{id}/claims")]
        public ActionResult<Claim> CreateClaim(int id)
        {
            var claim = new FnolService().CreateClaim(id);
            return CreatedAtAction("Create", new { id = 1 }, claim);
        }

    }
}
