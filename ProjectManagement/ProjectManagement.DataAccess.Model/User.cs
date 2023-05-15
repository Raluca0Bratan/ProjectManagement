


using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.DataAccess.Model
{
    public class User:IdentityUser
    {
        //public Guid Id { get; set; }    
        public string Name { get; set; }
       // public string Email { get; set; }
        //public string Password { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? ProfilePicturePath { get; set; }
        public ICollection<Discipline>? Disciplines { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Answer>? Answers { get; set; }
        public ICollection<StudentDiscipline>? StudentDisciplines { get; set; }
        public ICollection<StudentProject>? StudentProjects { get; set; }
        public ICollection<Question>? Questions { get; set; }

    }
}
