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
        // error handling to be implemented
        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _context.Patients.Where(patient => patient.Id == id).ProjectTo<PatientDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return patient;
        }
    }
}
