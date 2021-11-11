using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Domain.Contracts
{
    public interface IFieldRepository : IRepository<Field>
    {
        Task CreateField(Field field, CancellationToken cancellationToken);
        Task CreateFields(List<Field> fields, CancellationToken cancellationToken);
        Task<IEnumerable<FieldDto>> GetFields(CancellationToken cancellationToken);
        Task<FieldDto> GetFieldByCode(int code, CancellationToken cancellationToken);
        Task<FieldDto> GetFieldByName(string Name, CancellationToken cancellationToken);
    }
}
