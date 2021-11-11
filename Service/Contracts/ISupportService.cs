using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.Contracts
{
    public interface ISupportService
    {
        Task<IEnumerable<SupportDto>> GetSupports(int userId, int skip, int take, CancellationToken cancellationToken);
        Task<IEnumerable<SupportDto>> GetSupports(int skip, int take, CancellationToken cancellationToken);
        Task CreateSupport(SupportCreateDto supportDto,int userId, CancellationToken cancellationToken);
        Task<bool> UpdateSupport(UpdateSupportDto updateSupportDto, CancellationToken cancellationToken);
        Task<SupportDto> GetSupport(int id, CancellationToken cancellationToken);
    }
}
