using Poc.Claims.Utils;
using System;

namespace Poc.Claims.Services
{
    public class ClaimantService
    {
        private readonly ClaimantRepository _claimantRepository;

        public ClaimantService(string connectionString)
        {
            Initer.Init(connectionString);
            _claimantRepository = new ClaimantRepository();
        }

        public ClaimantDto GetClaimant(int id)
        {
            var claimant = _claimantRepository.GetById(id);
            return new ClaimantDto(claimant);
        }

        public ClaimantDto AddLine(long id, AddLineDto addLineDto)
        {
            var claimant = _claimantRepository.GetById(id);
            claimant.AddLine(addLineDto.initial_reserve_amount, addLineDto.type);
            _claimantRepository.Save(claimant);

            return new ClaimantDto(claimant);
        }
    }
}
