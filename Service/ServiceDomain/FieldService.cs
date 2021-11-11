using AutoMapper;
using Domain.Contracts;
using Domain.Model;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;
using Utility.Utilities;

namespace Service.ServiceDomain
{
    public class FieldService : IFieldService
    {
        private IUnitOfWork Unitofwork;
        private readonly IMapper Mapper;

        public FieldService(IUnitOfWork unitofwork, IMapper mapper)
        {
            Unitofwork = unitofwork;
            Mapper = mapper;
        }

        public async Task CreateField(FieldCreateDto fieldDto, CancellationToken cancellationToken)
        {
            try
            {
                var field = Mapper.Map<Field>(fieldDto);
                await Unitofwork.FieldRepository.CreateField(field, cancellationToken);
                await Unitofwork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new AppException(ApiResultStatusCode.ServerError, "در هنگام ثبت رشته های تحصیلی مشکلی رخ داده است", ex);
            }
        }

        public async Task CreateFields(List<FieldDto> fieldDtos, CancellationToken cancellationToken)
        {
            try
            {
                var fields = Mapper.Map<List<Field>>(fieldDtos);
                await Unitofwork.FieldRepository.CreateFields(fields, cancellationToken);
                await Unitofwork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new AppException(ApiResultStatusCode.ServerError, "در هنگام ثبت رشته های تحصیلی مشکلی رخ داده است", ex);
            }
        }

        public async Task<FieldDto> GetFieldByCode(int code, CancellationToken cancellationToken)
        {
            return await Unitofwork.FieldRepository.GetFieldByCode(code, cancellationToken);
        }

        public async Task<FieldDto> GetFieldByName(string Name, CancellationToken cancellationToken)
        {
            return await Unitofwork.FieldRepository.GetFieldByName(Name, cancellationToken);
        }

        public async Task<IEnumerable<FieldDto>> GetFields(CancellationToken cancellationToken)
        {
            return await Unitofwork.FieldRepository.GetFields(cancellationToken);
        }
    }
}
