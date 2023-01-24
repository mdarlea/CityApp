using City.Application.Common.Interfaces;
using City.Services;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace City
{
    public static class ConfigureServices
	{
		public static IServiceCollection AddWebUIServices(this IServiceCollection services)
		{
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddSingleton<ICurrentUserService, CurrentUserService>();

			services.AddHttpContextAccessor();

            services.AddControllersWithViews();
            //services.AddControllersWithViews().AddFluentValidation(x => x.AutomaticValidationEnabled = false);
            //services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true).AddFluentValidationClientsideAdapters();

            services.AddRazorPages();
            //services.AddMvc();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
				options.SuppressModelStateInvalidFilter = true);

			services.AddOpenApiDocument(configure =>
			{
				configure.Title = "City API";
				configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
				{
					Type = OpenApiSecuritySchemeType.ApiKey,
					Name = "Authorization",
					In = OpenApiSecurityApiKeyLocation.Header,
					Description = "Type into the textbox: Bearer {your JWT token}."
				});

				configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
			});
            			
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
								  builder =>
								  {
									  builder.AllowAnyHeader();
									  builder.AllowAnyMethod();
									  builder.AllowAnyOrigin();
								  });
			});

			return services;
		}
	}
}
