using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockTos.Application.Abstractions.IRepositories;
using ClockTos.Persistance.Data;
using ClockTos.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClockTos.Persistance.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistanceSevices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ClockDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString(nameof(ClockDbContext)));
            });
            services.AddScoped<ICollegeRepository, CollegeRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            return services;
        }
    }
}
