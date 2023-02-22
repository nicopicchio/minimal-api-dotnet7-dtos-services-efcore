using ReferralApi.Data;
using ReferralApi.DTO;
using ReferralApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ReferralApi.Services
{
    public class PatientService
    {
        private readonly ReferralContext _context;
        private readonly IMapper _mapper;
        public PatientService(ReferralContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // this converts my patient entity to the dto by mapping (automapper)

        public async Task<ICollection<Patient>> GetAllPatients()
        {
            var patientList = await _context.Patients.ToListAsync();
            if (patientList.Count == 0)
            {
                throw new Exception("Patients list empty");
            }
            return patientList;
        }

        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _context.Patients.Where(p => p.Id == id).ProjectTo<PatientDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }
            return patient;
        }

        public async Task<PatientDto> AddNewPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            var response = await _context.Patients.Where(p => p.Id == patient.Id).ProjectTo<PatientDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (response == null)
            {
                throw new Exception("Something went wrong");
            }
            return response;
        }
    }
}
