using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simple_CRM_system_C_Sharp_.Models;

namespace Simple_CRM_system_C_Sharp_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HeadOfdepartment> DepartmentHeads { get; set; }
        public DbSet<Complaint> Complaints { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 


            modelBuilder.Entity<Department>()
                .HasOne(d => d.Head)
                .WithOne(h => h.Department)
                .HasForeignKey<HeadOfdepartment>(h => h.DepartmentId);
        }
    }
}