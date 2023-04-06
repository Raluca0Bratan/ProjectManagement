

namespace ProjectManagement.DataAccess.Model
{
    public class Teacher : ModelEntity,IUser
    {
        public string Name { get ; set ; }
        public string Email { get ; set; }
        public string Password { get; set ; }
        public string? Address { get ; set ; }
        public string? Description { get ; set ; }
        public string? ProfilePicturePath { get ; set ; }
        public string Role => "Teacher";
        ICollection<Discipline>? Disciplines { get; set ; }
        ICollection<Project>? Projects { get; set ; }

        ICollection<Answer>? Answers { get; set ; }


    }
}
