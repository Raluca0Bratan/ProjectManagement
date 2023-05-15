

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ProjectManagementContext context;

        public UserRepository(ProjectManagementContext context) : base(context)
        {
        }

        public User GetById(string userId)
        {
            return FindByCondition(u=>u.Id == userId).FirstOrDefault();
        }
        public List<Discipline> GetDisciplinesOfStudent(string studentId)
        {
           
            var disciplines = context.Set<StudentDiscipline>()
       .Where(sd => sd.StudentId == studentId)
       .Select(sd => sd.Discipline)
       .ToList();
            return disciplines;
        }
        public List<Project> GetProjectsOfStudentOfDiscipline(string studentId, Guid disciplineId)
        {
            var student = GetById(studentId);
            var studentProjects = student.StudentProjects.Select(sp => sp.Project).ToList();
            var studentProjectsOfDiscipline = studentProjects
                .Where(sp => sp.Discipline.Id == disciplineId)
                .ToList();
            return studentProjectsOfDiscipline;
        }
        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId)
        {
            var discipline = this.context.Set<Discipline>().First(d => d.Id == disciplineId);
            return discipline.Questions;
        }

        public Project AddProjectToStudent(Project project, string studentId)
        {
            var student = GetById(studentId);
            var studentProject = new StudentProject
            {
                Project = project,
                StudentId = studentId,
                Student = student,
                ProjectId = project.Id,
            };
            student.StudentProjects.Add(studentProject);
            this.context.Set<StudentProject>().Add(studentProject);
            return project;
        }

        public Discipline AddDisciplineToStudent(Discipline discipline, string studentId)
        {
            var student = GetById(studentId);
            var studentDiscipline = new StudentDiscipline
            {
                Discipline = discipline,
                StudentId = studentId,
                Student = student,
                DisciplineId = discipline.Id,
            };
            student.StudentDisciplines.Add(studentDiscipline);
            this.context.Set<StudentDiscipline>().Add(studentDiscipline);
            return discipline;
        }

        public User AddDisciplineToTeacher(string teacherId, Discipline disciplineToAdd)
        {
            var teacher = FindByCondition(t => t.Id == teacherId).FirstOrDefault();
            teacher.Disciplines.Add(disciplineToAdd);
            this.context.SaveChanges();
            return teacher;
        }

        public Discipline UpdateDiscipline(Discipline disciplineToUpdate)
        {
            this.context.Set<Discipline>().Update(disciplineToUpdate);
            this.context.SaveChanges();
            return disciplineToUpdate;
        }
        public void RemoveDisciplineFromTeacher(string teacherId, Discipline discipline)
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
            var discipline = this.context.Set<Discipline>().FirstOrDefault(d => d.Id == disciplineId);
            return discipline;
        }

        public Project AddProject(Guid disciplineId, Project projectToAdd)
        {
            var discipline = GetDisciplineById(disciplineId);
            discipline.Projects.Add(projectToAdd);
            this.context.SaveChanges();
            return projectToAdd;
        }

        public void RemoveProject(Guid disciplineId, Project projectToRemove)
        {
            var discipline = GetDisciplineById(disciplineId);
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
            return this.context.Set<Project>().FirstOrDefault(p => p.Id == projectId);
        }

        public List<User> GetStudentsOfProject(Guid projectId)
        {
            var project = GetProjectById(projectId);
            var studentsOfProject = project.StudentProjects
                .Select(sp => sp.Student)
                .ToList();
            return studentsOfProject;

        }

        public List<User> GetStudentsOfDiscipline(Guid disciplineId)
        {
            var discipline = GetDisciplineById(disciplineId);
            var studentsOfDiscipline = discipline.StudentDisciplines
                .Select(sd => sd.Student)
                .ToList();
            return studentsOfDiscipline;
        }

        public Answer GetAnswerOfQuestion(Guid questionId)
        {
            var question = context.Set<Question>().First(q => q.Id == questionId);
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
