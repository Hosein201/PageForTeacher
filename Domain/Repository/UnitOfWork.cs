using Domain.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TeacherDbContext _dbContext;

        public IUserRepository UserRepository { get; set; }
        public ISupportRepository SupportRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }
        public ITeacherRepository TeacherRepository { get; set; }
        public IFieldRepository FieldRepository { get; set; }
        public IPaymentRepository PaymentRepository { get; set; }
        public IEduRepository EduRepository { get; set; }

        public UnitOfWork(TeacherDbContext dbContext)
        {
            this._dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
            SupportRepository = new SupportRepository(_dbContext);
            StudentRepository = new StudentRepository(_dbContext);
            TeacherRepository = new TeacherRepository(_dbContext);
            FieldRepository = new FieldRepository(_dbContext);
            PaymentRepository = new PaymentRepository(_dbContext);
            EduRepository = new EduRepository(_dbContext);
        }
        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
