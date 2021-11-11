using Domain.Contracts;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;
using Utility.Utilities;

namespace Domain.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private TeacherDbContext dbContext;
        public TeacherRepository(TeacherDbContext _dbContext)
           : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task CreateTeacher(Teacher teacher, CancellationToken cancellationToken)
        {
            await AddAsync(teacher, cancellationToken);
        }

        public async Task<IEnumerable<TeacherDto>> GetTeachers(int skip, int take, CancellationToken cancellationToken)
        {
            var typeImg = (int)TypeImgUser.Personnel;

            var result = await dbContext.UserFields.AsNoTracking().Where(w => w.User.Teacher.UserId == w.UserId).Skip(skip).Take(take)
                .Select(s => new TeacherDto
                {
                    FieldName = s.Field.Name,
                    EducationalBackground = s.User.Teacher.EducationalBackground,
                    FName = s.User.FName,
                    LName = s.User.LName,
                    RegisterDate = s.User.Teacher.RegisterDate,
                    TeachingExperience = s.User.Teacher.TeachingExperience,
                    UserId = s.UserId,
                    Age = s.User.Teacher.Age,
                    PathImg = s.User.PathImgs.FirstOrDefault(f => f.TypeImg == typeImg).Path ?? string.Empty
                }).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<TeacherDto> GetTeacher(int userId, CancellationToken cancellationToken)
        {

            var result = await dbContext.UserFields.AsNoTracking().Where(w => w.User.Teacher.UserId == w.UserId)
                .Select(s => new TeacherDto
                {
                    FieldName = s.Field.Name,
                    EducationalBackground = s.User.Teacher.EducationalBackground,
                    FName = s.User.FName,
                    LName = s.User.LName,
                    RegisterDate = s.User.Teacher.RegisterDate,
                    TeachingExperience = s.User.Teacher.TeachingExperience,
                    UserId = s.UserId,
                    Age = s.User.Teacher.Age,
                }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }

        public async Task<IEnumerable<TeachersDto>> GetTeachersByField(int codeField, CancellationToken cancellationToken)
        {
            var data = await dbContext.UserFields.AsNoTracking().Where(w => w.FieldId == codeField && w.UserId == w.User.Teacher.UserId).Select(s => new
            {
                UserId = s.User.Id,
                FName = s.User.FName,
                LName = s.User.LName

            }).ToListAsync(cancellationToken);

            var result = data.Select(s => new TeachersDto
            {
                Code = s.UserId,
                Name = $"{s.FName} {s.LName}"
            }).ToList();

            return result;
        }
    }
}
