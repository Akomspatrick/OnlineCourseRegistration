using OnlineCourseRegistration.Application;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using OnlineCourseRegistration.Domain.Base;
using System;
using System.Threading.Tasks;
using OnlineCourseRegistration.Application.Interfaces;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;

namespace OnlineCourseRegistration.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _dbContext;

        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
           // studentRepository = new StudentRepository(dbContext);

        }
      //  public IStudentRepository<Student> studentRepository { get; private set; }

 
        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            try
            {
                return _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

 
    }
}