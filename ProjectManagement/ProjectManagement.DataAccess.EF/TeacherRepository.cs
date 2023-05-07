

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly ProjectManagementContext context;
        public TeacherRepository(ProjectManagementContext context) : base(context)
        {
        }

        public Teacher AddDisciplineToTeacher (string teacherId, Discipline disciplineToAdd) 
        {
            var teacher = FindByCondition(t=>t.Id==teacherId).FirstOrDefault();
            teacher.Disciplines.Add(disciplineToAdd);
            this.context.SaveChanges();
            return teacher;
        }

        public Discipline UpdateDiscipline (Discipline disciplineToUpdate)
        {
            this.context.Set<Discipline>().Update(disciplineToUpdate); 
            this.context.SaveChanges();
            return disciplineToUpdate;
        }
        public void RemoveDisciplineFromTeacher(string teacherId,Discipline discipline) 
        { 
            var teacher = FindByCondition(t => t.Id == teacherId).FirstOrDefault();
            teacher.Disciplines.Remove(discipline);
            this.context.SaveChanges(); 
        }

        public List<Discipline> GetDisciplinesOfTeacher(string teacherId)
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

        public List<Student> GetStudentsOfProject(Guid projectId)
        {
            var project = GetProjectById(projectId);
            var studentsOfProject = project.StudentProjects
                .Select(sp=>sp.Student)
                .ToList();
            return studentsOfProject;

        }

        public List<Student> GetStudentsOfDiscipline(Guid disciplineId)
        {
            var discipline = GetDisciplineById(disciplineId);
            var studentsOfDiscipline = discipline.StudentDisciplines
                .Select(sd => sd.Student)
                .ToList();
            return studentsOfDiscipline;
        }

        public Answer GetAnswerOfQuestion(Guid questionId)
        {
            var question = context.Set<Question>().First(q=>q.Id==questionId);
            var answer = question.Answer;
            return answer;
        }

        public IEnumerable<Project> GetProjectsOfDiscipline(Guid disciplineId)
        {
            var discipline = GetDisciplineById(disciplineId);
            return discipline.Projects;
           
        }

    }
}
