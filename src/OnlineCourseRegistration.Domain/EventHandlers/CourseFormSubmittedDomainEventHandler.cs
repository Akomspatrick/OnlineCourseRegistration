using Microsoft.Extensions.Logging;
using OnlineCourseRegistration.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Domain.EventHandlers
{
    public class CourseFormSubmittedDomainEventHandler : BaseDomainEventHandler<CourseFormSubmittedDomainEvent>
    {
        private readonly ILogger _logger;
        public CourseFormSubmittedDomainEventHandler()//ILogger logger)
        {
           // _logger= logger;    
        }
        public override Task HandleAsync(CourseFormSubmittedDomainEvent @event)
        {

          Console.WriteLine($"Event Id {@event.EventId } Course ID{@event.courseRegistrationForm.coursesForm.ToString()}");
            Console.WriteLine($"I am currently Handling {typeof(CourseFormSubmittedDomainEvent)}");
            return Task.CompletedTask;

        }
    }
}
