using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineCourseRegistration.Domain.Base;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
//using NewOnlineCourseReg.Infrastructure.Data.Repositories.Models;

namespace OnlineCourseRegistration.Persistence.Repositories
{
    public class EFContext : DbContext
    {
        private readonly IMediator _mediator;

        public DbSet<CourseRegistrationForm> CourseRegistrationForms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public EFContext(DbContextOptions<EFContext> options//, IConfiguration configuration
           , IMediator mediator) : base(options)
        {
            //   _configuration = configuration;
            _mediator= mediator;
        //  Database.EnsureCreated();
    }


        public void Save()
        {
            this.SaveChanges(); 
        }
        public override int SaveChanges()
        {
            var response = base.SaveChanges();
            _dispatchDomainEvents().GetAwaiter().GetResult();
            return response;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var response = await base.SaveChangesAsync(cancellationToken);
            await _dispatchDomainEvents();
            return response;
        }

        private async Task _dispatchDomainEvents()
        {
            var domainEventEntities = ChangeTracker.Entries<Student>()
                .Select(po => po.Entity)
                .Where(po => po.Events.Any())
                .ToArray();
           
            foreach (var entity in domainEventEntities)
            {
                var events = entity.Events.ToArray();
               // entity.Events.;
                foreach (var entityDomainEvent in events)
                    await _mediator.Publish(entityDomainEvent);
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        ////    var connectionString = _configuration.GetConnectionString("DDDConnectionString");
        ////    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
            //new CourseRegistrationFormConfig().Configure(builder.Entity<CourseRegistrationForm>());
            //new CourseConfig().Configure(builder.Entity<Course>());
            //new StudentConfig().Configure(builder.Entity<Student>());

        }
    }


}