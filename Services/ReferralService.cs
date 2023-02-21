using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ReferralApi.Data;
using ReferralApi.DTO;
using ReferralApi.Models;

namespace ReferralApi.Services
{
    public class ReferralService
    {
        private readonly ReferralContext _context;
        private readonly IMapper _mapper;
        public ReferralService(ReferralContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReferralDto> GetReferralById(int id)
        {
            var referral = await _context.Referrals.Where(referral => referral.Id == id).ProjectTo<ReferralDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (referral == null)
            {
                throw new Exception("Referral not found");
            }
            return referral;
        }
    }
}
