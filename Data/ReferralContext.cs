using ReferralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ReferralApi.Data
{
    public class ReferralContext : DbContext
    {
        public ReferralContext(DbContextOptions<ReferralContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Referral> Referrals { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
    }
}
