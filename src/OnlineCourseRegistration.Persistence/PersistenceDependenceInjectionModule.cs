using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourseRegistration.Application.Interfaces;
using OnlineCourseRegistration.Domain;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
using OnlineCourseRegistration.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Persistence
{
    public static  class PersistenceDependenceInjectionModule
    {
        public static IServiceCollection AddPersistenceDependenceInjection(this IServiceCollection services,  IConfiguration configuration)
        {

            //services.AddMediatR(typeof(PersistenceDependenceInjectionModule));
            services.AddScoped<IAsyncRepository<Student>, RepositoryBase<Student>>();
            services.AddScoped<IStudentRepository<Student>, StudentRepository>();

              services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
              .AddScoped<IUnitOfWork, UnitOfWork>()


            .AddDbContext<EFContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DDDConnectionString"));
                // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });



            return services;
        }
    }
}


