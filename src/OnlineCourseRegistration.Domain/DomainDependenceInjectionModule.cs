using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineCourseRegistration.Domain.Base;
using OnlineCourseRegistration.Domain.EventHandlers;
using OnlineCourseRegistration.Domain.Events;

namespace OnlineCourseRegistration.Domain
{
    public static class DomainDependenceInjectionModule

    {
        public static IServiceCollection AddDomainDependenceInjection(this IServiceCollection services)
        {

            var foo = new CourseFormSubmittedDomainEventHandler(); // The singleton instance
          //  var services = new ServiceCollection();

            services.AddSingleton<IBaseDomainEventHandler<CourseFormSubmittedDomainEvent>>(foo);
            services.AddSingleton<INotificationHandler< CourseFormSubmittedDomainEvent >> (foo);

     

            services.AddMediatR(typeof(DomainDependenceInjectionModule));
            //services.AddTransient<INotificationHandler<BaseDomainEvent>, IntegrationEventHandler>();
            // var assembly = Assembly.GetExecutingAssembly();

            return services;
        }
    }
}