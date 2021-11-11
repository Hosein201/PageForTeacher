using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISupportRepository :IRepository<Support>
    {
        Task<IEnumerable<Support>> GetSupports(int userId, int skip, int take, CancellationToken cancellationToken);
        Task<IEnumerable<Support>> GetSupports(int skip, int take, CancellationToken cancellationToken);
        Task CreateSupport(Support support, CancellationToken cancellationToken);
        void UpdateSupport(Support support);
        Task<Support> GetSupport(int id, CancellationToken cancellationToken);
    }
}
