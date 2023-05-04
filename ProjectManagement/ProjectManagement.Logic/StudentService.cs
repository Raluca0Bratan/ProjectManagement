using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Logic
{
    public class StudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return studentRepository.GetAll();
        }
        public void AddStudent(Student student)
        {
            studentRepository.Add(student);
            
        }
        public void RemoveStudent(Guid studentId)
        {
            var student = studentRepository.GetById(studentId);
            if (student != null)
            {
                studentRepository.Remove(studentId);
            }
            else
            {
                throw new ArgumentException($"Student with id {studentId} does not exist.");
            }
        }
        public Student GetStudentById(Guid studentId)
        {
            var student = studentRepository.GetById(studentId);
            if (student != null)
            {
                return student;
            }
            else
            {
                throw new ArgumentException($"Student with id {studentId} does not exist.");
            }
        }
        public void UpdateStudent(Student updatedStudent)
        {
           studentRepository.Update(updatedStudent);    
        }

        public List<Discipline> GetDisciplinesOfStudent(Guid studentId)
        {
           return studentRepository.GetDisciplinesOfStudent(studentId);
        }
        public List<Project> GetProjectsOfStudentOfDiscipline(Guid studentId, Guid disciplineId)
        {
          return studentRepository.GetProjectsOfStudentOfDiscipline(studentId, disciplineId);
        }
        public IEnumerable<Question> GetQuestionsOfDiscipline(Guid disciplineId)
        {
            return studentRepository.GetQuestionsOfDiscipline(disciplineId);
        }
    }
}