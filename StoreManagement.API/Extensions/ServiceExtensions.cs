using Microsoft.Extensions.DependencyInjection;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ProductPagination>();
            services.AddTransient<CategoryPagination>();
            return services;
        }
    }
}
