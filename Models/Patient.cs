namespace ReferralApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string DateOfBirth { get; set; } = default!;
        public string HospitalNumber { get; set; } = default!;
        public string AddressLine1 { get; set; } = default!;
        public string ?AddressLine2 { get; set; }
        public string City { get; set; } = default!;
        public string Postcode { get; set; } = default!;
        public ICollection<Referral> Referrals { get; set; } = default!;
        public ICollection<Doctor> Doctors { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
