using City.Domain.Entities;
using City.Domain.Entities.Buildings;
using City.Domain.Entities.NeighborhoodEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace City.Infrastructure
{
    public class CityContextInitialiser
	{
		private readonly ILogger<CityContextInitialiser> logger;
		private readonly CityContext context;
		private readonly UserManager<IdentityUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public CityContextInitialiser(ILogger<CityContextInitialiser> logger, CityContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.logger = logger;
			this.context = context;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async Task InitialiseAsync()
		{
			try
			{
				if (context.Database.IsSqlServer())
				{
					await context.Database.MigrateAsync();
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "An error occurred while initialising the database.");
				throw;
			}
		}

		public async Task SeedAsync()
		{
			try
			{
				await TrySeedAsync();
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "An error occurred while seeding the database.");
				throw;
			}
		}

		public async Task TrySeedAsync()
		{
			// Default roles
			var administratorRole = new IdentityRole("Administrator");

			if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
			{
				await roleManager.CreateAsync(administratorRole);
			}

			// Default users
			var administrator = new IdentityUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

			if (userManager.Users.All(u => u.UserName != administrator.UserName))
			{
				await userManager.CreateAsync(administrator, "Administrator1!");
				if (!string.IsNullOrWhiteSpace(administratorRole.Name))
				{
					await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
				}
			}

			// Default data
			// Seed, if necessary
			if (!context.Neighborhoods.Any()) 
			{
				var neighborhood = new Neighborhood("Cetate");
				
				var market = new Market("Piata Libertatii", "12345");

				var blockOfFlats = new BlockOfFlats("100");
				blockOfFlats.AddStair(10, "A");
				blockOfFlats.AddStair(5, "B");
				blockOfFlats.AddStair(15, "C");
				market.AddNewBlockOfFlats(blockOfFlats);

				var house = new House(1, "Biblioteca Judeteana");
				market.AddNewHouse(house);

				house = new House(2, "Agora Gold");
				market.AddNewHouse(house);

				neighborhood.AddMarket(market);

				market = new Market("Piata Sf. Gheorghe", "12346");

				blockOfFlats = new BlockOfFlats("120");
				blockOfFlats.AddStair(3, "A");
				blockOfFlats.AddStair(8, "B");
				market.AddNewBlockOfFlats(blockOfFlats);

				blockOfFlats = new BlockOfFlats("100");
				blockOfFlats.AddStair(2, "A");
				blockOfFlats.AddStair(5, "B");
				market.AddNewBlockOfFlats(blockOfFlats);
				
				house = new House(1, "Vitacom Electronics");
				market.AddNewHouse(house);

				house = new House(2, "Hotel Continental");
				market.AddNewHouse(house);

				neighborhood.AddMarket(market);

				market = new Market("Piata Unirii", "12347");

				blockOfFlats = new BlockOfFlats("150");
				blockOfFlats.AddStair(13, "A");
				blockOfFlats.AddStair(18, "B");
				market.AddNewBlockOfFlats(blockOfFlats);

				blockOfFlats = new BlockOfFlats("100");
				blockOfFlats.AddStair(20, "A");
				blockOfFlats.AddStair(51, "C");
				market.AddNewBlockOfFlats(blockOfFlats);

				house = new House(3, "Hype Culture");
				market.AddNewHouse(house);

				house = new House(4, "Farmacia Vlad");
				market.AddNewHouse(house);

				neighborhood.AddMarket(market);

                var boulevard = new Boulevard("Constantin Diaconovici Loga", "12346");

                blockOfFlats = new BlockOfFlats("50");
                blockOfFlats.AddStair(6, "A");
                blockOfFlats.AddStair(4, "B");
                blockOfFlats.AddStair(1, "C");
                blockOfFlats.AddStair(2, "D");
                blockOfFlats.AddStair(3, "E");
                boulevard.AddNewBlockOfFlats(blockOfFlats);

                blockOfFlats = new BlockOfFlats("100");
                blockOfFlats.AddStair(20, "A");
                blockOfFlats.AddStair(3, "B");
                boulevard.AddNewBlockOfFlats(blockOfFlats);

                neighborhood.AddBoulevard(boulevard);

                context.Neighborhoods.Add(neighborhood);

				neighborhood = new Neighborhood("Calea Sagului");

                var street = new Street("Aleea Actorilor", "12346");
                blockOfFlats = new BlockOfFlats("15");
                blockOfFlats.AddStair(6, "A");
                blockOfFlats.AddStair(4, "B");
                blockOfFlats.AddStair(1, "C");
                street.AddNewBlockOfFlats(blockOfFlats);
                
                house = new House(1, "Farmacia Farmado");
                street.AddNewHouse(house);

                neighborhood.AddStreet(street);

                context.Neighborhoods.Add(neighborhood);

				neighborhood = new Neighborhood("Iosefin");
				context.Neighborhoods.Add(neighborhood);

				neighborhood = new Neighborhood("Circumvalatiunii");
				context.Neighborhoods.Add(neighborhood);
				await context.SaveChangesAsync();
			}
		}
	}
}
