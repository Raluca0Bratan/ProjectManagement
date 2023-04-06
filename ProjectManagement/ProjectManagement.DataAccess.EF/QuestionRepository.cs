

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class QuestionRepository : BaseRepository<Question>
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }
    }
}
