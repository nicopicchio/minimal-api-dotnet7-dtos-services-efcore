﻿namespace ReferralApi.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Specialty { get; set; } = default!;
        public string Department { get; set; } = default!;

    }
}
