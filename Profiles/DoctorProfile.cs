using AutoMapper;
using ReferralApi.DTO;
using ReferralApi.Models;

namespace ReferralApi.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();
        }
    }
}
