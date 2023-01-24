using City.Domain.Common;
using City.Domain.Entities.NeighborhoodEntities;

namespace City.Domain.Entities
{
	public class Neighborhood: BaseAuditableEntity
	{
		public Neighborhood(string name) 
		{
			Name = name;
		}

		public string Name { get; private set; }

		private readonly List<NeighborhoodEntity> neighborhoodEntities= new List<NeighborhoodEntity>();
		public IReadOnlyCollection<NeighborhoodEntity> NeighborhoodEntities => neighborhoodEntities.AsReadOnly();

		public void AddBoulevard(Boulevard boulevard) 
		{
			if (boulevard is null)
			{
				throw new ArgumentNullException(nameof(boulevard));
			}

			if (boulevard.IsTransient() || !neighborhoodEntities.Any(e => e.Id == boulevard.Id)) 
			{
				neighborhoodEntities.Add(boulevard);
			}
		}

		public void AddMarket(Market market)
		{
			if (market is null)
			{
				throw new ArgumentNullException(nameof(market));
			}

			if (market.IsTransient() || !neighborhoodEntities.Any(e => e.Id == market.Id))
			{
				neighborhoodEntities.Add(market);
			}
		}

		public void AddStreet(Street street)
		{
			if (street is null)
			{
				throw new ArgumentNullException(nameof(street));
			}

			if (street.IsTransient() || !neighborhoodEntities.Any(e => e.Id == street.Id))
			{
				neighborhoodEntities.Add(street);
			}
		}
	}
}
