using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("CodingIoDevConnectionString")));
            services.AddScoped<IProgLanguageRepository, ProgLanguageRepository>();
            services.AddScoped<ILanguageFrameworkRepository, LanguageFrameworkRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository,UserOperationClaimRepository>();
            services.AddScoped<IOperationClaimRepository,OperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserSocialMediaAddressRepository, UserSocialMediaAddressRepository>();

            return services;
        }
    }
}
