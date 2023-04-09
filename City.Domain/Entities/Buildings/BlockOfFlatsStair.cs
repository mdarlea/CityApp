using City.Domain.Common;

namespace City.Domain.Entities.Buildings
{
	public class BlockOfFlatsStair: BaseAuditableEntity
	{
		internal BlockOfFlatsStair(int numberOfApartments, string stair) 
		{			
			NumberOfApartments = numberOfApartments;
			Stair = stair;
		}

		public BlockOfFlats? BlockOfFlats { get; set; }
		public int NumberOfApartments { get; private set; }
		public string Stair { get; private set; }
	}
}
