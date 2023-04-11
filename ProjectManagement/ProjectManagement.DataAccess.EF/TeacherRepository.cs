

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly DbContext context;
        public TeacherRepository(DbContext context) : base(context)
        {
        }

        public Teacher AddDisciplineToTeacher (Guid teacherId, Discipline disciplineToAdd) 
        {
            var teacher = GetById(teacherId);
            teacher.Disciplines.Add(disciplineToAdd);
            this.context.SaveChanges();
            return teacher;
        }

        public Discipline UpdateDiscipline ( Discipline disciplineToUpdate)
        {
            this.context.Set<Discipline>().Update(disciplineToUpdate); 
            this.context.SaveChanges();
            return disciplineToUpdate;
        }
        public void RemoveDisciplineFromTeacher(Guid teacherId,Discipline discipline) 
        { 
            var teacher = GetById(teacherId);
            teacher.Disciplines.Remove(discipline);
            this.context.SaveChanges(); 
        }

        public List<Discipline> GetDisciplinesOfTeacher(Guid teacherId)
        {
            var disciplines = this.context.Set<Discipline>()
                .Where(d => d.TeacherId == teacherId)
                .Include(d => d.Projects)
                .Include(d => d.Questions)
                .Include(d => d.StudentDisciplines)
                .ToList();
            return disciplines;
        }

        public Discipline GetDisciplineById(Guid disciplineId)
        {
            var discipline = this.context.Set<Discipline>().FirstOrDefault(d=>d.Id==disciplineId);
            return discipline;
        }

        public Project AddProject (Guid disciplineId,Project projectToAdd)
        {
            var discipline = GetDisciplineById(disciplineId);
            discipline.Projects.Add(projectToAdd);
            this.context.SaveChanges();
            return projectToAdd;
        }

        public void RemoveProject (Guid disciplineId, Project projectToRemove)
        {
            var discipline = GetDisciplineById (disciplineId);  
            discipline.Projects.Remove(projectToRemove); 
            this.context.SaveChanges();
        }

        public Project UpdateProject(Project projectToUpdate)
        {
            this.context.Set<Project>().Update(projectToUpdate);
            return projectToUpdate;
        }

        public Project GetProjectById(Guid projectId)
        {
            return this.context.Set<Project>().FirstOrDefault(p=>p.Id==projectId); 
        }

        //public List<Student> GetStudentsOfProject(Guid projectId)
        //{
        //    var project = GetProjectById(projectId);
        //    project.StudentProjects
        //}
    }
}
