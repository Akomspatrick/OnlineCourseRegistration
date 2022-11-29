using MediatR;
using OnlineCourseRegistration.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Domain.EventHandlers
{
    public interface IBaseDomainEventHandler<T> where T : BaseDomainEvent
    {
        Task  HandleAsync(T @event);
    }
    public abstract class BaseDomainEventHandler<T> : IBaseDomainEventHandler<T>, INotificationHandler<T> where T : BaseDomainEvent
    {
        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            await HandleAsync(notification);
        }

        public abstract Task HandleAsync(T @event);
      
    }
}
