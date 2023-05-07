using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;
using System.Data;

namespace ProjectManagement.DataAccess.EF
{
    public class ProjectManagementContext: IdentityDbContext<IdentityUser>
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
            : base(options) { }  

        DbSet<Administrator> Administrators { get; set; }   
        DbSet<Answer> Answers { get; set; }

        DbSet<Project> Projects { get; set; }

        DbSet<Student> Students { get; set; }
        
        DbSet<Teacher> Teachers { get; set; }   

        DbSet<Discipline> Disciplines { get; set; }

        DbSet<Question> Questions { get; set; }

        DbSet<StudentDiscipline> StudentsDisciplines { get; set;}

        DbSet<StudentProject> StudentProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDiscipline>()
                .HasKey(sd => new { sd.StudentId, sd.DisciplineId });
            modelBuilder.Entity<StudentDiscipline>()
                .HasOne(sd => sd.Student)
                .WithMany(d => d.StudentDisciplines)
                .HasForeignKey(sd => sd.StudentId);
            modelBuilder.Entity<StudentDiscipline>()
                .HasOne(sd => sd.Discipline)
                .WithMany(s => s.StudentDisciplines)
                .HasForeignKey(sd => sd.DisciplineId);

            modelBuilder.Entity<StudentProject>()
               .HasKey(sp => new { sp.StudentId, sp.ProjectId });
            modelBuilder.Entity<StudentProject>()
                .HasOne(sp => sp.Student)
                .WithMany(p => p.StudentProjects)
                .HasForeignKey(sp => sp.StudentId);
            modelBuilder.Entity<StudentProject>()
                .HasOne(sp => sp.Project)
                .WithMany(s => s.StudentProjects)
                .HasForeignKey(sp => sp.ProjectId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Answer)
                .WithOne(a => a.Question)
                .HasForeignKey<Answer>(a => a.QuestionId);

            
            modelBuilder.Entity<User>().ToTable("Users");
            base.OnModelCreating(modelBuilder);

        }


    }
}