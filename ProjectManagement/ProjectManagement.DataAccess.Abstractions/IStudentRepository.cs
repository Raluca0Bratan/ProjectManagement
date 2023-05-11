

using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.Abstractions
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        public List<Discipline> GetDisciplinesOfStudent(string studentId);


        public List<Project> GetProjectsOfStudentOfDiscipline(string studentId, Guid disciplineId);


        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId);

        public Project AddProjectToStudent(Project project, string studentId);

        public Discipline AddDisciplineToStudent(Discipline discipline, string studentId);

       
    }
}
