﻿

using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.Abstractions
{
    public interface IUserRepository:IBaseRepository<User>
    {

        public User GetById(string userId);
        
        public List<Discipline> GetDisciplinesOfStudent(string studentId);

        public List<Project> GetProjectsOfStudentOfDiscipline(string studentId, Guid disciplineId);

        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId);

        public Project AddProjectToStudent(Project project, string studentId);


        public Discipline AddDisciplineToStudent(Discipline discipline, string studentId);


        public User AddDisciplineToTeacher(string teacherId, Discipline disciplineToAdd);


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
        
    }
}
