using City.Domain.Entities.NeighborhoodEntities;

namespace City.Application.NeighborhoodEntities.Queries.SearchAddress
{
    public class BlockOfFlatsAddressDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PostalCode { get; set; }
        public NeighborhoodEntityType NeighborhoodEntityType { get; set; }
        public List<BlockOfFlatsDto> BlockOfFlats { get; init; } = new List<BlockOfFlatsDto>();
        public int NumberOfBlockOfFlats { get; set; }
        public int NumberOfHouses { get; set; }
    }
}
