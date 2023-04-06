

namespace ProjectManagement.DataAccess.Model
{
    public class Administrator : ModelEntity,IUser
    {

        public string Name { get ; set ; }
        public string Email { get ; set ; }
        public string Password { get ; set ; }
        public string? Address { get; set ; }
        public string? Description { get ; set ; }
        public string? ProfilePicturePath { get ; set ; }
        public string Role => "Administrator";
        public ICollection<Student>? Students { get; set ; }
        public ICollection<Teacher>? Teachers { get; set ; }


    }
}
