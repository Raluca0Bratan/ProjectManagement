

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class DisciplineRepository:BaseRepository<Discipline>
    {
        public DisciplineRepository(DbContext context) : base(context) { }
    }
}
