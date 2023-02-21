using AutoMapper;
using ReferralApi.DTO;
using ReferralApi.Models;

namespace ReferralApi.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}
