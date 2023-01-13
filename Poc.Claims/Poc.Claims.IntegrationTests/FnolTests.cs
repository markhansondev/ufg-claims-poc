using Poc.Claims.Services;
using Shouldly;
using Xunit;

namespace Poc.Claims.IntegrationTests
{
    [Collection("Sequential")]
    public class FnolTests : BaseTests
    {
        private readonly FnolService _fnolService;

        public FnolTests()
        {
            _fnolService = new FnolService(ConnectionString);
        }

        [Fact]
        public void Can_create_and_get_an_fnol()
        {
            //setup
            var fnolDto = new FnolDto()
            {
                claimant_name = "claimant 1",
                is_ready_to_be_completed = true,
                line_liability_amount = 123,
                line_type = "line type 1"
            };

            //execute
            var newFnol = _fnolService.CreateFnol(fnolDto);
            var getFnolDto = _fnolService.GetFnol(newFnol.id);

            //verify
            fnolDto.id = 10;
            getFnolDto.ShouldBeEquivalentTo(fnolDto);
        }
    }
}
