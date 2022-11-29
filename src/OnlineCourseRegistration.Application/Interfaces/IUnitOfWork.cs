
using OnlineCourseRegistration.Application.Interfaces;
using OnlineCourseRegistration.Domain.Base;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
       // IStudentRepository<Student>  studentRepository { get; }
    }
}

