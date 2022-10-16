using System.Reflection;
using Application.Features.Auths.Rules;
using Application.Features.LanguageFrameworks.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.AuthService;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ProgLanguageBusinessRules>();
            services.AddScoped<LanguageFrameworkBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<UserSocialMediaAddressesRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
