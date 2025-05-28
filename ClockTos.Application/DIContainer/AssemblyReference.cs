using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClockTos.Application.Abstractions.IService;
using ClockTos.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClockTos.Application.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICollegeService, CollegeService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}
