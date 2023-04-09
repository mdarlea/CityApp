using City.Application.Common.Interfaces;
using City.Domain.Entities;
using City.Domain.Entities.Buildings;
using City.Domain.Entities.NeighborhoodEntities;
using City.Infrastructure.Common;
using City.Infrastructure.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace City.Infrastructure
{
    public class CityContext: ApiAuthorizationDbContext<IdentityUser>, ICityContext
	{
		private readonly IMediator mediator;
		private readonly AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor;

		public CityContext(DbContextOptions<CityContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions, IMediator mediator, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
			: base(options, operationalStoreOptions)
		{
			this.mediator = mediator;
			this.auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
		}

		public DbSet<Neighborhood> Neighborhoods { get; set; }
		public DbSet<NeighborhoodEntity> NeighborhoodEntities { get; set; }
        public DbSet<Boulevard> Boulevards{ get; set; }
        public DbSet<Market> Markets{ get; set; }
        public DbSet<Street> Streets{ get; set; }

		public DbSet<Building> Buildings { get; set; }
		public DbSet<BlockOfFlatsStair> BlockOfFlatsStairs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			//modelBuilder.Entity<Boulevard>();
			//modelBuilder.Entity<Market>();
			//modelBuilder.Entity<Street>();

			modelBuilder.Entity<BlockOfFlats>();
			modelBuilder.Entity<House>();

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			await mediator.DispatchDomainEvents(this);

			return await base.SaveChangesAsync(cancellationToken);
		}

	}
}
