using Microsoft.Extensions.DependencyInjection;
using SparkybitTestTask.Services.Implamentation;
using SparkybitTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkybitTestTask.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IFibonacciService, FibonacciService>();
            services.AddSingleton<IFileService, FileService>();

            return services;
        }
    }
}
