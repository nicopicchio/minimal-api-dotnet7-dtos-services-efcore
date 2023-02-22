namespace ReferralApi.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string HospitalNumber { get; set; } = default!;
    }
}
