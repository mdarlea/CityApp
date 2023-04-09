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

        private readonly List<Boulevard> boulevards = new List<Boulevard>();
        public IReadOnlyCollection<Boulevard> Boulevards => boulevards.AsReadOnly();

        public void AddBoulevard(Boulevard boulevard) 
		{
			if (boulevard is null)
			{
				throw new ArgumentNullException(nameof(boulevard));
			}

			if (boulevard.IsTransient() || !boulevards.Any(e => e.Id == boulevard.Id)) 
			{
				boulevards.Add(boulevard);
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
