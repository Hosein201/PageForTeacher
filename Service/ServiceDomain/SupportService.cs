using AutoMapper;
using Domain.Contracts;
using Domain.Model;
using Service.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;
using Utility.Utilities;

namespace Service.ServiceDomain
{
    public class SupportService : ISupportService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task CreateSupport(SupportCreateDto supportDto,int userId, CancellationToken cancellationToken)
        {
            var support = _mapper.Map<Support>(supportDto);
            support.UserId = userId;
            await _unitOfWork.SupportRepository.CreateSupport(support, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<SupportDto> GetSupport(int id, CancellationToken cancellationToken)
        {
            var support = await _unitOfWork.SupportRepository.GetSupport(id, cancellationToken);
            return _mapper.Map<SupportDto>(support);
        }

        public async Task<IEnumerable<SupportDto>> GetSupports(int userId, int skip, int take, CancellationToken cancellationToken)
        {
            var supports = await _unitOfWork.SupportRepository.GetSupports(userId, skip, take, cancellationToken);
            return _mapper.Map<IEnumerable<Support>, IEnumerable<SupportDto>>(supports);
        }

        public async Task<IEnumerable<SupportDto>> GetSupports(int skip, int take, CancellationToken cancellationToken)
        {
            var supports = await _unitOfWork.SupportRepository.GetSupports(skip, take, cancellationToken);
            return _mapper.Map<IEnumerable<Support>, IEnumerable<SupportDto>>(supports);
        }

        public async Task<bool> UpdateSupport(UpdateSupportDto updateSupportDto, CancellationToken cancellationToken)
        {
            var support = await _unitOfWork.SupportRepository.GetSupport(updateSupportDto.Id, cancellationToken);
            if (support != null)
            {
                support.Answer = updateSupportDto.Answer;
                support.IsReadAdmin = updateSupportDto.IsReadAdmin;
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return true;
            }
            throw new AppException(ApiResultStatusCode.NotFound, "مورد نظر یافت نشد");
        }
    }
}
