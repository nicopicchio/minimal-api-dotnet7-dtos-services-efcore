namespace ReferralApi.DTO
{
    public class ReferralDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = default!;
        public string ReasonForReferral { get; set; } = default!;

    }
}
