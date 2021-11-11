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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private TeacherDbContext DbContext;
        public StudentRepository(TeacherDbContext dbContext)
           : base(dbContext)
        {
            DbContext = dbContext;
        }

        public async Task CreateStudent(int userId, CancellationToken cancellationToken)
        {
            await AddAsync(new Student() { UserId = userId }, cancellationToken);
        }

        public async Task<IEnumerable<StudentDto>> GetStudents(int skip, int take, CancellationToken cancellationToken)
        {
            var typeImg = (int)TypeImgUser.Personnel;

            var result = await DbContext.UserFields.AsNoTracking().Where(w => w.UserId == w.User.Student.UserId).Skip(skip).Take(take)
                .Select(s => new StudentDto
                {
                    FieldName = s.Field.Name,
                    FName = s.User.FName,
                    LName = s.User.LName,
                    RegisterDate = s.User.Student.RegisterDate,
                    UserId = s.UserId,
                    Address = s.User.Address,
                    BirthDate = s.User.BirthDate,
                    Email = s.User.Email,
                    NationalCode = s.User.NationalCode,
                    PhoneNumber = s.User.PhoneNumber,
                    PathImg = s.User.PathImgs.FirstOrDefault(f => f.TypeImg == typeImg).Path ?? string.Empty
                }).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Student> GetStudent(int userId, CancellationToken cancellationToken)
        {
            return await Tracking().Where(w => w.UserId == userId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
