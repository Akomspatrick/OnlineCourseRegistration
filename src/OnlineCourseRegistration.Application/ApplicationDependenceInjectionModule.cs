using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourseRegistration.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Application
{

    public static class ApplicationDependenceInjectionModule
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            //  services.AddAutoMapper(typeof(ApplicationDependenceInjectionModule));
           
            services.AddMediatR(typeof(ApplicationDependenceInjectionModule));
            // var assembly = Assembly.GetExecutingAssembly();
            return services;

        }
    }
}
