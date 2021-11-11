using Domain.Contracts;
using Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EduRepository : Repository<Edu>, IEduRepository
    {
        public EduRepository(TeacherDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task CreateEdu(Edu eduDto, CancellationToken cancellationToken)
        {
            await AddAsync(eduDto , cancellationToken);
        }
    }
}
