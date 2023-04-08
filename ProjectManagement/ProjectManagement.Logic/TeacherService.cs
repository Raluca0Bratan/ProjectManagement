using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System;

namespace ProjectManagement.Logic
{
    public class TeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return teacherRepository.GetAll();
        }

        public void AddTeacher(Teacher teacher)
        {
            teacherRepository.Add(teacher);
            teacherRepository.SaveChanges();
        }

        public Teacher GetTeacherById(int teacherId)
        {
            var teacher = teacherRepository.GetById(teacherId);
            if (teacher != null)
            {
                return teacher;
            }
            else
            {
                throw new ArgumentException($"Teacher with id {teacherId} does not exist.");
            }
        }

        public void UpdateTeacher(Teacher updatedTeacher)
        {
            var teacher = teacherRepository.GetById(updatedTeacher.Id);
            if (teacher != null)
            {
                teacher.Title = updatedTeacher.Title;
                teacher.Description = updatedTeacher.Description;
                teacherRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Teacher with id {updatedTeacher.Id} does not exist.");
            }
        }

        public void RemoveTeacher(int teacherId)
        {
            var teacher = teacherRepository.GetById(teacherId);
            if (teacher != null)
            {
                teacherRepository.Remove(teacher);
                teacherRepository.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Teacher with id {teacherId} does not exist.");
            }
        }
    }
}
