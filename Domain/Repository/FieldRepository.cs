using Domain.Contracts;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Domain.Repository
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        public FieldRepository(TeacherDbContext dbContext)
           : base(dbContext)
        { }

        public async Task CreateField(Field field, CancellationToken cancellationToken)
        {
            await AddAsync(field, cancellationToken);
        }

        public async Task CreateFields(List<Field> fields, CancellationToken cancellationToken)
        {
            await AddRangeAsync(fields, cancellationToken);
        }

        public async Task<IEnumerable<FieldDto>> GetFields(CancellationToken cancellationToken)
        {
            return await AsNoTracking().OrderBy(o => o.Code).Select(s => new FieldDto { Code = s.Code, Name = s.Name }).ToListAsync(cancellationToken);
        }

        public async Task<FieldDto> GetFieldByCode(int code, CancellationToken cancellationToken)
        {
            return await AsNoTracking().Where(f => f.Code == code).Select(s => new FieldDto { Code = s.Code, Name = s.Name })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<FieldDto> GetFieldByName(string Name, CancellationToken cancellationToken)
        {
            return await AsNoTracking().Where(f => f.Name == Name).Select(s => new FieldDto { Code = s.Code, Name = s.Name })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
