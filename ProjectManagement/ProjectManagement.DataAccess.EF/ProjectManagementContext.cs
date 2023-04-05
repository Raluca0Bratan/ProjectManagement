using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class ProjectManagementContext:DbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
            : base(options) { }  

        DbSet<Administrator> Administrators { get; set; }   
        DbSet<Answer> Answers { get; set; }
    }
}