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

        public async Task<ICollection<Doctor>> GetAllDoctors()
        {
            var doctorsList = await _context.Doctors.ToListAsync();
            if (doctorsList.Count == 0)
            {
                throw new Exception("Doctors list empty");
            }
            return doctorsList;
        }

        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors.Where(d => d.Id == id).ProjectTo<DoctorDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
            return doctor;
        }

        public async Task<DoctorDto> AddNewDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            var response = await _context.Doctors.Where(d => d.Id == doctor.Id).ProjectTo<DoctorDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (response == null)
            {
                throw new Exception("Patient not found");
            }
            return response;
        }
    }
}
