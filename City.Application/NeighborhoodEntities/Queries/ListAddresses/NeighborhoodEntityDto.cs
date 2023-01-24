using AutoMapper;
using City.Application.Common.Mappings;
using City.Domain.Entities.NeighborhoodEntities;

namespace City.Application.NeighborhoodEntities.Queries.ListAddresses
{
    public class NeighborhoodEntityDto: IMapFrom<NeighborhoodEntity>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PostalCode { get; set; }
        public string? Neighborhood { get; set; }
        public NeighborhoodEntityType NeighborhoodEntityType { get; private set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<NeighborhoodEntity, NeighborhoodEntityDto>()
                .ForMember(n => n.Neighborhood, opt => opt.MapFrom(s => s.Neighborhood!.Name));
        }
    }
}
