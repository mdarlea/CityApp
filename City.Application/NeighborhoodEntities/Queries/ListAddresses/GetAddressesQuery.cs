using AutoMapper;
using AutoMapper.QueryableExtensions;
using City.Application.Common.Interfaces;
using City.Application.Common.Mappings;
using City.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace City.Application.NeighborhoodEntities.Queries.ListAddresses
{
    public record GetAddressesQuery : IRequest<PaginatedList<NeighborhoodEntityDto>> 
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, PaginatedList<NeighborhoodEntityDto>>
    {
        private readonly ICityContext context;
        private readonly IMapper mapper;

        public GetAddressesQueryHandler(ICityContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<NeighborhoodEntityDto>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            var result = await context.NeighborhoodEntities
                            .AsNoTracking()
                            .Include(ne => ne.Neighborhood)
                            .OrderBy(ne => ne.Neighborhood!.Name)
                                    .ThenBy(ne => ne.Type)
                                        .ThenBy(ne => ne.PostalCode)
                                            .ThenBy(ne => ne.Name)
                            .ProjectTo<NeighborhoodEntityDto>(mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }



}
