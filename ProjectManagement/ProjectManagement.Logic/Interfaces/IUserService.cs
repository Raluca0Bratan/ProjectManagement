

using ProjectManagement.DataAccess.Model;
using System.Linq.Expressions;

namespace ProjectManagement.Logic.Interfaces
{
    public interface IUserService
    {
        public User GetById(string userId);

        public List<Discipline> GetDisciplinesOfStudent(string studentId);

        public List<Project> GetProjectsOfStudentOfDiscipline(string studentId, Guid disciplineId);

        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId);


        public Project AddProjectToStudent(Project project, string studentId);


        public Discipline AddDisciplineToStudent(Discipline discipline, string studentId);


        public Discipline AddDisciplineToTeacher(string teacherId, Discipline disciplineToAdd);


        public Discipline UpdateDiscipline(Discipline disciplineToUpdate);

        public void RemoveDisciplineFromTeacher(string teacherId, Discipline discipline);


        public List<Discipline> GetDisciplinesOfTeacher(string teacherId);


        public Discipline GetDisciplineById(Guid disciplineId);


        public Project AddProject(Guid disciplineId, Project projectToAdd);


        public void RemoveProject(Guid disciplineId, Project projectToRemove);


        public Project UpdateProject(Project projectToUpdate);


        public Project GetProjectById(Guid projectId);


        public List<User> GetStudentsOfProject(Guid projectId);


        public List<User> GetStudentsOfDiscipline(Guid disciplineId);


        public Answer GetAnswerOfQuestion(Guid questionId);


        public IEnumerable<Project> GetProjectsOfDiscipline(Guid disciplineId);

        public IEnumerable<User> GetAll();
        User Add(User entity);
        User Update(User entity);
        void Remove(User entity);
        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression);

    }
}
