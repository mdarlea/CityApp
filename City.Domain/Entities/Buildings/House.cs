namespace City.Domain.Entities.Buildings
{
	public class House : Building
	{
		public House(int houseNumber, string name)
		{
			HouseNumber = houseNumber;
			Name = name;
		}
		public int HouseNumber { get; private set; }
		public string Name { get; private set; }

	}
}
