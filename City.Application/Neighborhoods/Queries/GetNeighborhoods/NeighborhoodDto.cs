using City.Application.Common.Mappings;
using City.Domain.Entities;

namespace City.Application.Neighborhoods.Queries.GetNeighborhoods
{
    public class NeighborhoodDto : IMapFrom<Neighborhood>
    {
        public int Id { get; set; } = 0;
        public string Name { get; private set; } = string.Empty;
    }
}
