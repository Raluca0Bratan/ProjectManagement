
namespace ProjectManagement.DataAccess.Model
{
    public class Student : ModelEntity,IUser
    {
        public string Name { get ; set ; }
        public string Email { get ; set ; }
        public string Password { get ; set ; }
        public string Address { get ; set ; }
        public string Description { get ; set; }
        public string ProfilePicturePath { get ; set ; }
        public string Role => "Student";
        public List<StudentDiscipline> StudentDiscipline { get; set; }
        public List<StudentProject> StudentProjects { get; set; }

        public List<Question> Questions { get; set; }

    }
}
