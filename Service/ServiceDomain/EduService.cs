using AutoMapper;
using Domain.Contracts;
using Domain.Model;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.ServiceDomain
{
    public class EduService : IEduService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public EduService(IUnitOfWork _unitOfWork ,IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task CreateEdu(EduDto eduDto, CancellationToken cancellationToken)
        {
            var edu= mapper.Map<Edu>(eduDto);
            await unitOfWork.EduRepository.CreateEdu(edu, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
