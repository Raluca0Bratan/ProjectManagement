

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class AdministratorRepository : BaseRepository<Administrator>
    {
        public AdministratorRepository(DbContext context) : base(context)
        {
        }
    }
}
