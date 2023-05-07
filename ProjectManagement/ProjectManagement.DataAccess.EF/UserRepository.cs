

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjectManagementContext context) : base(context)
        {
        }
    }
}
