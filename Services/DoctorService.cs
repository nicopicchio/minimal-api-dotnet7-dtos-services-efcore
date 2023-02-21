using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ReferralApi.Data;
using ReferralApi.DTO;
using ReferralApi.Models;

namespace ReferralApi.Services
{
    public class DoctorService
    {
        private readonly ReferralContext _context;
        private readonly IMapper _mapper;
        public DoctorService(ReferralContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors.Where(doctor => doctor.Id == id).ProjectTo<DoctorDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            return doctor;
        }
    }
}
