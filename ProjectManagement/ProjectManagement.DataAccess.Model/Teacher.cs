

namespace ProjectManagement.DataAccess.Model
{
    public class Teacher : ModelEntity,IUser
    {
        public string Name { get ; set ; }
        public string Email { get ; set; }
        public string Password { get; set ; }
        public string Address { get ; set ; }
        public string Description { get ; set ; }
        public string ProfilePicturePath { get ; set ; }
        public string Role => "Teacher";
        List<Discipline> Disciplines { get; set ; }
        List<Project> Projects { get; set ; }

        List<Answer> Answers { get; set ; }


    }
}
