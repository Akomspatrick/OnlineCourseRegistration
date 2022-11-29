using System.Collections.Generic;

namespace OnlineCourseRegistration.Domain.Base
{
    public abstract class BaseEntity
    {
        private List<BaseDomainEvent> _eventsList;
        public IReadOnlyList<BaseDomainEvent> Events => _eventsList.AsReadOnly();

        protected void AddEventToList(BaseDomainEvent @event)
        {
            _eventsList = _eventsList ?? new List<BaseDomainEvent>();
            _eventsList.Add(@event);
        }

        protected void RemoveEvent(BaseDomainEvent @event)
        {
            _eventsList.Remove(@event);
        }

        public void ClearDomainevents()
        {
            _eventsList?.Clear();
        }
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public TKey StudentId { get; set; }
    }
}