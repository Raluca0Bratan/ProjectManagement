using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models
{
    public class AccountInfoViewModel
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
