


namespace ProjectManagement.DataAccess.Model
{
    public abstract class User:ModelEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? ProfilePicturePath { get; set; }
       
    }
}
