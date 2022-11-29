
using LanguageExt;
using OnlineCourseRegistration.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Application.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<T> GetAsyncOrdinary(Expression<Func<T, bool>> expression);
        Task<Either<string, Task<T?>>> GetAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);


        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
       
        Task<Either<string, IEnumerable<T>>> GetWtExtension(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");



    }
}