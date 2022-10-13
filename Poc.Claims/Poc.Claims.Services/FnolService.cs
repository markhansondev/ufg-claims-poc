using System;

namespace Poc.Claims.Services
{
    public class FnolService
    {
        public static FnolDto GetFnol() => new() { line_type = "line type 1", claimant_name = "claimant 1"};
    }

    public class FnolDto
    {
        public string line_type { get; set; }
        public string claimant_name { get; set; }
    }
}
