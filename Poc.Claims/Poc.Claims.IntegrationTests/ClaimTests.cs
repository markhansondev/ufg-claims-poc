using System.Collections.Generic;
using Poc.Claims.Services;
using Shouldly;
using Xunit;

namespace Poc.Claims.IntegrationTests
{
    [Collection("Sequential")]
    public class ClaimTests : BaseTests
    {
        private readonly FnolService _fnolService;
        private readonly ClaimService _claimService;

        public ClaimTests()
        {
            _fnolService = new FnolService(ConnectionString);
            _claimService = new ClaimService(ConnectionString);
        }

        [Fact(Skip = "run on demand")]
        public void Can_create_and_get_a_claim()
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
            var fnol = _fnolService.CreateFnol(fnolDto);
            var newClaimDto = _fnolService.CreateClaim(fnol.id);
            var getClaimDto = _claimService.GetClaim(newClaimDto.id);

            //verify
            getClaimDto.ShouldBeEquivalentTo(
                new ClaimDto
                {
                    id = 10,
                    claimants = new List<ClaimantDto>
                    {
                        new()
                        {
                            name = "claimant 1",
                            lines = new List<LineDto>
                            {
                                new()
                                {
                                    reserve_amount = 123,
                                    type = "line type 1",
                                    line_number = 1
                                }
                            }
                        }
                    }
                });
        }
    }
}
