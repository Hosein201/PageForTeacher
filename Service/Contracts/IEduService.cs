using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.Contracts
{
    public interface IEduService
    {
        Task CreateEdu(EduDto eduDto, CancellationToken cancellationToken);
    }
}
