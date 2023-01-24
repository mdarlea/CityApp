namespace City.Domain.Entities.Buildings
{
	public class BlockOfFlats: Building
	{
		public BlockOfFlats(string blockNumber)
		{
			BlockNumber= blockNumber;
		}

		public string BlockNumber { get; private set; }

		private readonly List<BlockOfFlatsStair> blockOfFlatsStairs = new();
		public IReadOnlyCollection<BlockOfFlatsStair> BlockOfFlatsStairs => blockOfFlatsStairs.AsReadOnly();

		public void AddStair(int numberOfApartments, string stair) 
		{
			if (numberOfApartments < 1) 
			{
				throw new ArgumentOutOfRangeException(nameof(numberOfApartments));
			}
			if (string.IsNullOrEmpty(stair)) 
			{
				throw new ArgumentNullException(nameof(stair));
			}

			if (!blockOfFlatsStairs.Any(s => s.Stair == stair))
			{
				var blockOfFlatsStair = new BlockOfFlatsStair(numberOfApartments, stair);
                blockOfFlatsStairs.Add(blockOfFlatsStair);
			}
		}
	}
}
