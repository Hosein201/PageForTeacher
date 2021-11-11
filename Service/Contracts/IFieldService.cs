using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.Contracts
{
    public interface IFieldService
    {
        Task CreateField(FieldCreateDto fieldDto, CancellationToken cancellationToken);
        Task CreateFields(List<FieldDto> fieldDtos, CancellationToken cancellationToken);
        Task<IEnumerable<FieldDto>> GetFields(CancellationToken cancellationToken);
        Task<FieldDto> GetFieldByCode(int code, CancellationToken cancellationToken);
        Task<FieldDto> GetFieldByName(string Name, CancellationToken cancellationToken);
    }
}
