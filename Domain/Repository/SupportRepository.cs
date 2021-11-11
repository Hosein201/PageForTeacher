using Domain.Contracts;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
   public class SupportRepository: Repository<Support>, ISupportRepository
    {
        public SupportRepository(TeacherDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Support>>GetSupports(int userId , int skip , int take , CancellationToken cancellationToken)
        {
            return await AsNoTracking().Where(w => w.UserId == userId).OrderByDescending(o => new { o.IsReadAdmin, o.RegisterDate })
                                                                      .Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Support>> GetSupports(int skip, int take, CancellationToken cancellationToken)
        {
            return await AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public async Task CreateSupport(Support support , CancellationToken cancellationToken)
        {
            await AddAsync(support, cancellationToken);
        }

        public void UpdateSupport(Support support)
        {
            Update(support);
        }

        public async Task<Support> GetSupport(int id, CancellationToken cancellationToken)
        {
            return await Tracking().Where(w => w.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
   }
}
