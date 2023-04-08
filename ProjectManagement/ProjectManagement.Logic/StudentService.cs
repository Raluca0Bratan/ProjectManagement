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
            StudentRepository.SaveChanges();
        }
        public void RemoveStudent(int studentId)
        {
            var student = studentRepository.GetById(studentId);
            if (student != null)
            {
                studentRepository.Remove(student);
                studentRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Student with id {studentId} does not exist.");
            }
        }
        public Student GetStudentById(int studentId)
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
            var student = studentRepository.GetById(updatedStudent.Id);
            if (student != null)
            {
                student.Title = updatedStudent.Title;
                student.Description = updatedStudent.Description;
                studentRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Student with id {updatedStudent.Id} does not exist.");
            }
        }

    }
}