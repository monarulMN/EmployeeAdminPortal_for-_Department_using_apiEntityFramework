using EmployeeAdminProtal.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminProtal.Data
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<SubDepartment> SubDepartments { get; set; }
    }

    
}
