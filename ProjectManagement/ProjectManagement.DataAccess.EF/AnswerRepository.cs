

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class AnswerRepository : BaseRepository<Answer>
    {
        public AnswerRepository(DbContext context) : base(context)
        {
        }
    }
}
