

using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Application.Interfaces
{
    public interface IStudentRepository<T> : IAsyncRepository<Student>
    {
      
    }

}
