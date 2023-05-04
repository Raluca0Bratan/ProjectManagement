

using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.Abstractions
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        public List<Discipline> GetDisciplinesOfStudent(Guid studentId);


        public List<Project> GetProjectsOfStudentOfDiscipline(Guid studentId, Guid disciplineId);


        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId);
        
    }
}
