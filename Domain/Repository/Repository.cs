using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Utilities;

namespace Domain.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TeacherDbContext _dbContext;
        private DbSet<TEntity> Entities { get; set; }
        public Repository(TeacherDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.Entities = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Add(entity);
        }
        
        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
           Assert.NotNull(entities, nameof(entities));
            Entities.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            Assert.NotNull(entities, nameof(entities));
            await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        }

        public virtual void Delete(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.RemoveRange(entities);
        }


        public virtual void Update(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.UpdateRange(entities);
        }     

        protected  virtual IQueryable<TEntity> AsNoTracking()
        {
            return Entities.AsNoTracking();
        }

        protected virtual IQueryable<TEntity> Tracking()
        {
            return Entities;
        }
    }
}
