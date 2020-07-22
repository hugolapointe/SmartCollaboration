using Application.Common.Behaviours;

using AutoMapper;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using System.Reflection;

namespace Application {

    public static class DependencyInjection {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config) {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}
