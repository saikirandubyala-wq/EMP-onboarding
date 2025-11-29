using Microsoft.EntityFrameworkCore;
using Onboarding.Api.Models;

namespace Onboarding.Api.Data
{
    public class OnboardingDbContext : DbContext
    {
        public OnboardingDbContext(DbContextOptions<OnboardingDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } 
    }
}
