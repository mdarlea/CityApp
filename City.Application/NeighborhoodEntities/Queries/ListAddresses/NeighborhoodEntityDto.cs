using AutoMapper;
using City.Application.Common.Mappings;
using City.Domain.Entities.NeighborhoodEntities;
using Microsoft.EntityFrameworkCore;

namespace City.Application.NeighborhoodEntities.Queries.ListAddresses
{
    public class NeighborhoodEntityDto: IMapFrom<NeighborhoodEntity>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PostalCode { get; set; }
        public string? Neighborhood { get; set; }
        public string? NeighborhoodEntityType { get; private set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<NeighborhoodEntity, NeighborhoodEntityDto>()
                .ForMember(n => n.Neighborhood, opt => opt.MapFrom(s => s.Neighborhood!.Name))
                .ForMember(n => n.NeighborhoodEntityType, opt => opt.MapFrom(s => s.Type.ToString()));
        }
    }
}
