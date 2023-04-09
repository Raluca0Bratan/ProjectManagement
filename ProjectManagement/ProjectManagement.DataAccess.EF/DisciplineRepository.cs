

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class DisciplineRepository:BaseRepository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(DbContext context) : base(context) { }
    }
}
