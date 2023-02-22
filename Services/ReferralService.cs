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

        public async Task<ICollection<Referral>> GetAllReferrals()
        {
            var referralsList = await _context.Referrals.ToListAsync();
            if (referralsList.Count == 0)
            {
                throw new Exception("Referrals list empty");
            }
            return referralsList;
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

        public async Task<ReferralDto> AddNewReferral(Referral referral)
        {
            _context.Referrals.Add(referral);
            await _context.SaveChangesAsync();
            var response = await _context.Referrals.Where(r => r.Id == referral.Id).ProjectTo<ReferralDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (response == null)
            {
                throw new Exception("Referral not found");
            }
            return response;
        }
    }
}
