


using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.DataAccess.Model
{
    public class Teacher : User
    {
        public ICollection<Discipline>? Disciplines { get; set ; }
        public ICollection<Project>? Projects { get; set ; }

        public ICollection<Answer>? Answers { get; set ; }


    }
}
