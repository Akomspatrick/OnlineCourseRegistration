using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourseRegistration.Domain.Base
{
    [NotMapped]
    public abstract class BaseDomainEvent : INotification
    {
        public BaseDomainEvent()
        {
            EventId = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
        }
        [NotMapped]
        public virtual Guid EventId { get; init; }
        [NotMapped]
        public virtual DateTime CreatedOn { get; init; }
    }
}