using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class DBContext: DbContext
    {
        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options): base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"server=.;database=EchoTechnology;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
