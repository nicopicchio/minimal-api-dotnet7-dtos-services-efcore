﻿namespace ReferralApi.Models
{
    public class Referral
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = default!;
        public string ReasonForReferral { get; set; } = default!;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
