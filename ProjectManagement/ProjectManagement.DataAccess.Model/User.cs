

namespace ProjectManagement.DataAccess.Model
{
    public abstract class User:ModelEntity
    {
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string? Address { get; set; }
        string? Description { get; set; }
        string? ProfilePicturePath { get; set; }
       
    }
}
