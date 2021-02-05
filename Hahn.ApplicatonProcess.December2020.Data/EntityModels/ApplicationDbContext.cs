using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.EntityModels
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Applicant> Applicants { get; set; }
    }
}
