using City.Application.Common.Interfaces;
using City.Infrastructure.Identity;
using City.Infrastructure.Interceptors;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace City.Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<AuditableEntitySaveChangesInterceptor>();


			services.AddDbContext<CityContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
						builder => builder.MigrationsAssembly(typeof(CityContext).Assembly.FullName)));

            // services.AddScoped<ICityContext>(provider => provider.GetRequiredService<CityContext>());
            services.AddScoped<ICityContext, CityContext>();

            services.AddScoped<CityContextInitialiser>();

			services
				.AddDefaultIdentity<IdentityUser>()
                //.AddDefaultUI()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<CityContext>();

			services.AddIdentityServer()
				.AddApiAuthorization<IdentityUser, CityContext>();

			services.AddTransient<IIdentityService, IdentityService>();
			
			services.AddAuthentication()
				.AddIdentityServerJwt();

			services.AddAuthorization(options =>
				options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

			return services;
		}
	}
}
