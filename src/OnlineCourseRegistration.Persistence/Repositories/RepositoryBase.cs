
using LanguageExt;
using Microsoft.EntityFrameworkCore;

using OnlineCourseRegistration.Application.Interfaces;
using OnlineCourseRegistration.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Persistence.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(EFContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        //public virtual void Add(TEntity entity)
        //{
        //    _dbSet.Add(entity);
        //}

        public Task<Either<string, Task<T?>>> GetAsync(Expression<Func<T, bool>> expression)
        {
            var emptyEither = new Either<string, Task<T?>>();
               emptyEither = _dbSet.FirstOrDefaultAsync(expression);
            
          
            
             return Task.FromResult( emptyEither);
        }


        public Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }
        // Task<Either<QueryableQuestionEntityFailure, AnswerEntity>> PostAnswerAsync(AnswerEntity entity, CancellationToken cancellationToken);


        public Task<T> GetAsyncOrdinary(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }



    public virtual IEnumerable<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public Task<Either<string, IEnumerable<T>>> GetWtExtension(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            var emptyEither = new Either<string, IEnumerable<T>>();

            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            var result = orderBy != null ? orderBy(query).ToList() : query.ToList();

            emptyEither = result;

            
            return Task.FromResult(emptyEither);



        }
    }
}