

using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic.Interfaces;
using System.Linq.Expressions;

namespace ProjectManagement.Logic
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetById(string userId)
        {
            return userRepository.GetById(userId);
        }
        public List<Discipline> GetDisciplinesOfStudent(string studentId)
        {
           return userRepository.GetDisciplinesOfStudent(studentId);
        }
        public List<Project> GetProjectsOfStudentOfDiscipline(string studentId, Guid disciplineId)
        {
          return userRepository.GetProjectsOfStudentOfDiscipline(studentId, disciplineId);  
        }
        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId)
        {
          return userRepository.GetQuestionsOfDiscipline(disciplineId);
        }

        public Project AddProjectToStudent(Project project, string studentId)
        {
           return userRepository.AddProjectToStudent(project, studentId);   
        }

        public Discipline AddDisciplineToStudent(Discipline discipline, string studentId)
        {
          return userRepository.AddDisciplineToStudent(discipline, studentId);      
        }

        public Discipline AddDisciplineToTeacher(string teacherId, Discipline disciplineToAdd)
        {
           return userRepository.AddDisciplineToStudent(disciplineToAdd, teacherId);    
        }

        public Discipline UpdateDiscipline(Discipline disciplineToUpdate)
        {
            return userRepository.UpdateDiscipline(disciplineToUpdate);
        }
        public void RemoveDisciplineFromTeacher(string teacherId, Discipline discipline)
        {
            userRepository.RemoveDisciplineFromTeacher(teacherId, discipline);   
        }

        public List<Discipline> GetDisciplinesOfTeacher(string teacherId)
        {
            return userRepository.GetDisciplinesOfTeacher(teacherId);
        }

        public Discipline GetDisciplineById(Guid disciplineId)
        {
            return userRepository.GetDisciplineById(disciplineId);
        }

        public Project AddProject(Guid disciplineId, Project projectToAdd)
        {
            return userRepository.AddProject(disciplineId, projectToAdd);   
        }

        public void RemoveProject(Guid disciplineId, Project projectToRemove)
        {
            userRepository.RemoveProject(disciplineId, projectToRemove);  
        }

        public Project UpdateProject(Project projectToUpdate)
        {
           return userRepository.UpdateProject(projectToUpdate);
        }

        public Project GetProjectById(Guid projectId)
        {
          return userRepository.GetProjectById(projectId);
        }

        public List<User> GetStudentsOfProject(Guid projectId)
        {
            return userRepository.GetStudentsOfProject(projectId);

        }

        public List<User> GetStudentsOfDiscipline(Guid disciplineId)
        {
           return userRepository.GetStudentsOfDiscipline(disciplineId);
        }

        public Answer GetAnswerOfQuestion(Guid questionId)
        {
            return userRepository.GetAnswerOfQuestion(questionId);
        }

        public IEnumerable<Project> GetProjectsOfDiscipline(Guid disciplineId)
        {
            return userRepository.GetProjectsOfDiscipline(disciplineId);
        }

        public IEnumerable<User> GetAll()
        {
           return userRepository.GetAll();  
        }

        public User Add(User entity)
        {
            return userRepository.Add(entity);
        }

        public User Update(User entity)
        {
            return userRepository.Update(entity);   
        }

        public void Remove(User entity)
        {
            userRepository.Remove(entity);  
        }

        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return userRepository.FindByCondition(expression); 
        }
    }
}
