using City.Domain.Entities.NeighborhoodEntities;

namespace City.Application.NeighborhoodEntities.Queries.Neighborhoods
{
    public class NeighborhoodDto
    {
        public string? Neighborhood { get; set; }
        public string Type { get; set; }
        public int NumberOfAddressType {get; set; }
    }
}
