

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class AdministratorRepository : BaseRepository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(DbContext context) : base(context)
        {
        }
    }
}
