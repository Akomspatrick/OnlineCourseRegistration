using OnlineCourseRegistration.Domain.Base;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Domain.Events
{
    public class CourseFormSubmittedDomainEvent: BaseDomainEvent
    {
        public CourseRegistrationForm courseRegistrationForm { get; set; }
    }
}
