using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.Users.Mapping.Resolvers;

namespace Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly));
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationDependencyInjection).Assembly));
            services.AddTransient<FirstNameResolver>();
            services.AddTransient<LastNameResolver>();
            return services;
        }
    }
}