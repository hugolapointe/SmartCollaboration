using Application.Common.Interfaces;

using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure {
    public static class DependencyInjection {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection"),
                    context => context.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
