

using OnlineCourseRegistration.Application.Interfaces;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;

namespace OnlineCourseRegistration.Persistence.Repositories
{
    public class StudentRepository : RepositoryBase<Student>
        , IStudentRepository<Student>
    {
        EFContext Context;
        public StudentRepository(EFContext dbContext) : base(dbContext)
        {
            Context = dbContext;
        }

        public EFContext EFContext
        {
            get { return Context as EFContext; }
        }

        //public override void Add(Student entity)
        //{
        //    // We can override repository virtual methods in order to customize repository behavior, Template Method Pattern
        //    // Code here

        //    base.Add(entity);
        //}
    }
}