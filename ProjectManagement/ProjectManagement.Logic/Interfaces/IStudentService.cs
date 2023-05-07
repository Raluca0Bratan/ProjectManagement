using ProjectManagement.DataAccess.Model;
using System;


namespace ProjectManagement.Logic.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetStudents();

        public void AddStudent(Student student);

        public void RemoveStudent(string studentId);

        public Student GetStudentById(string studentId);

        public void UpdateStudent(Student updatedStudent);

        public List<Discipline> GetDisciplinesOfStudent(string studentId);

        public List<Project> GetProjectsOfStudentOfDiscipline(string studentId, Guid disciplineId);

        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId);

        public Project AddProjectToStudent(Project project, string studentId);

        public Discipline AddDisciplineToStudent(Discipline discipline, string studentId);

    }
}
