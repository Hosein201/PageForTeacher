using Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IEduRepository : IRepository<Edu>
    {
        Task CreateEdu(Edu eduDto, CancellationToken cancellationToken);
    }
}
