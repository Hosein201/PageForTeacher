using Domain.Contracts;
using Service.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.ServiceDomain
{
    public class TeacherService : ITeacherService
    {

        public IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<TeacherDto> GetTeacher(int userId, CancellationToken cancellationToken)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetTeacher(userId, cancellationToken);
            return teacher;
        }

        public async Task<IEnumerable<TeacherDto>> GetTeachers(int skip, int take, CancellationToken cancellationToken)
        {
            var teachers = await _unitOfWork.TeacherRepository.GetTeachers(skip, take, cancellationToken);
            return teachers;
        }

        public async Task<IEnumerable<TeachersDto>> GetTeachersByField(int codeField, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TeacherRepository.GetTeachersByField(codeField, cancellationToken);
        }
    }
}
