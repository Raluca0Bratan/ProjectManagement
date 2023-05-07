

using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.Abstractions
{
    public interface ITeacherRepository:IBaseRepository<Teacher>
    {
        public Teacher AddDisciplineToTeacher(string teacherId, Discipline disciplineToAdd);


        public Discipline UpdateDiscipline(Discipline disciplineToUpdate);

        public void RemoveDisciplineFromTeacher(string teacherId, Discipline discipline);


        public List<Discipline> GetDisciplinesOfTeacher(string teacherId);


        public Discipline GetDisciplineById(Guid disciplineId);


        public Project AddProject(Guid disciplineId, Project projectToAdd);


        public void RemoveProject(Guid disciplineId, Project projectToRemove);


        public Project UpdateProject(Project projectToUpdate);


        public Project GetProjectById(Guid projectId);


        public List<Student> GetStudentsOfProject(Guid projectId);


        public List<Student> GetStudentsOfDiscipline(Guid disciplineId);


        public Answer GetAnswerOfQuestion(Guid questionId);


        public IEnumerable<Project> GetProjectsOfDiscipline(Guid disciplineId);
        
    }
}
