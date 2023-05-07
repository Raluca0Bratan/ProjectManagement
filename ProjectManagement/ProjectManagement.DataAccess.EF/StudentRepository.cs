﻿

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;


namespace ProjectManagement.DataAccess.EF
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly ProjectManagementContext context; 
        public StudentRepository(ProjectManagementContext context) : base(context)
        {
        }

        public Student GetStudentById(string studentId)
        {
            var student = this.context.Set<Student>().FirstOrDefault(s=>s.Id == studentId);    
            return student;
        }
        
        public List<Discipline> GetDisciplinesOfStudent (string studentId)
        {
            var student = GetStudentById(studentId);
            var disciplines = student.StudentDisciplines.Select(sd=>sd.Discipline).ToList();
            return disciplines;
        }
        public List<Project> GetProjectsOfStudentOfDiscipline(string studentId,Guid disciplineId)
        {
            var student = GetStudentById(studentId);
            var studentProjects = student.StudentProjects.Select(sp=>sp.Project).ToList();
            var studentProjectsOfDiscipline = studentProjects
                .Where(sp=>sp.Discipline.Id == disciplineId)
                .ToList();
            return studentProjectsOfDiscipline;
        }
        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId)
        {
            var discipline = this.context.Set<Discipline>().First(d => d.Id == disciplineId);
            return discipline.Questions;
        }

    }
}
