using AutoMapper;
using ReferralApi.DTO;
using ReferralApi.Models;

namespace ReferralApi.Profiles
{
    public class ReferralProfile : Profile
    {
        public ReferralProfile()
        {
            CreateMap<Referral, ReferralDto>().ReverseMap();
        }
    }
}
