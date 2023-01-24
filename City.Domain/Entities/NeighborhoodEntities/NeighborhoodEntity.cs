using City.Domain.Common;
using City.Domain.Entities.Buildings;

namespace City.Domain.Entities.NeighborhoodEntities
{
    public enum NeighborhoodEntityType 
    {
        Boulevard, Market, Street
    }

    public abstract class NeighborhoodEntity : BaseAuditableEntity
	{
		protected NeighborhoodEntity(string name, string postalCode) 
		{
			Name = name;
			PostalCode = postalCode;			
		}

        public string Name { get; private set; }
        public string PostalCode { get; private set; }
        public NeighborhoodEntityType NeighborhoodEntityType { get; private set; }
        public Neighborhood? Neighborhood { get; set; }

		private readonly List<Building> buildings = new List<Building>();
		public IReadOnlyCollection<Building> Buildings => buildings.AsReadOnly();

		public IReadOnlyCollection<BlockOfFlats> BlockOfFlats => buildings.OfType<BlockOfFlats>().ToList().AsReadOnly();
		public IReadOnlyCollection<House> Houses => buildings.OfType<House>().ToList().AsReadOnly();

		public void AddNewBlockOfFlats(BlockOfFlats blockOfFlats) 
		{
			if (blockOfFlats is null)
			{
				throw new ArgumentNullException(nameof(blockOfFlats));
			}

			if (blockOfFlats.IsTransient() || !buildings.Any(b => b.Id == blockOfFlats.Id))
			{
				buildings.Add(blockOfFlats);
			}
		}

		public void AddNewHouse(House house)
		{
			if (house is null)
			{
				throw new ArgumentNullException(nameof(house));
			}

			if (house.IsTransient() || !buildings.Any(b => b.Id == house.Id))
			{
				buildings.Add(house);
			}
		}
    }
}
