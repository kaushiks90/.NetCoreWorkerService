using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Services;
using CleanArchitecture.Infrastructure.Http;
using CleanArchitecture.Infrastructure.Images;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class ServiceCollectionSetup
    {    
        public static void AddImages(this IServiceCollection services)
        {
            services.AddSingleton<IUpload, Upload>();
            services.AddSingleton<ICapture, Capture>();
        }

        public static void AddUrlCheckingServices(this IServiceCollection services)
        {
            services.AddTransient<IUrlStatusChecker, UrlStatusChecker>();
            services.AddTransient<IHttpService, HttpService>();
        }
    }
} 