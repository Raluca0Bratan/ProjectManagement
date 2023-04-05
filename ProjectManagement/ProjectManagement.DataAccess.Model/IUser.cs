
namespace ProjectManagement.DataAccess.Model
{
   public interface IUser
    {
        string Name { get; set; }   
        string Email { get; set; }  
        string Password { get; set; }
        string Address { get; set; }   
        string Description { get; set; }
        string ProfilePicturePath { get; set; } 
        string Role { get; }   

    }
}
