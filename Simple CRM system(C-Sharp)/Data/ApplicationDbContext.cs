using Microsoft.EntityFrameworkCore;
using Simple_CRM_system_C_Sharp_.Data;
using Simple_CRM_system_C_Sharp_.Models;


namespace Simple_CRM_system_C_Sharp_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HeadOfdepartment> DepartmentHeads { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        
    }
}
