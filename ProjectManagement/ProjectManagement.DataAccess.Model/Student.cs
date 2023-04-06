
namespace ProjectManagement.DataAccess.Model
{
    public class Student : ModelEntity,IUser
    {
        public string Name { get ; set ; }
        public string Email { get ; set ; }
        public string Password { get ; set ; }
        public string? Address { get ; set ; }
        public string? Description { get ; set; }
        public string? ProfilePicturePath { get ; set ; }
        public string Role => "Student";
        public ICollection<StudentDiscipline>? StudentDisciplines { get; set; }
        public ICollection<StudentProject>? StudentProjects { get; set; }

        public ICollection<Question>? Questions { get; set; }

    }
}
