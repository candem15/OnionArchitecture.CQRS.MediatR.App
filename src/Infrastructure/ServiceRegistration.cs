using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt=>opt.UseInMemoryDatabase("OnionDB"));

            services.AddTransient<IProductRepository,ProductRepository>();
        }
    }
}