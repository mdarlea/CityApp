using City.Application.Common.Interfaces;
using City.Application.Common.Mappings;
using City.Application.Common.Models;
using City.Domain.Entities.NeighborhoodEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace City.Application.NeighborhoodEntities.Queries.Neighborhoods
{
    public record GetNeighborhoodsQuery: IRequest<PaginatedList<NeighborhoodDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetNeighborhoodsQueryHandler : IRequestHandler<GetNeighborhoodsQuery, PaginatedList<NeighborhoodDto>>
    {
        private readonly ICityContext context;

        public GetNeighborhoodsQueryHandler(ICityContext context) 
        {
            this.context = context;
        }

        public async Task<PaginatedList<NeighborhoodDto>> Handle(GetNeighborhoodsQuery request, CancellationToken cancellationToken)
        {
            var results = await (from n in context.Neighborhoods
                          join ne in context.NeighborhoodEntities on n.Id equals ne.Neighborhood!.Id
                          group new { n, ne } by new { n.Name, NeighborhoodEntityType = EF.Property<NeighborhoodEntityType>(ne, "Type") } into gr
                          select new NeighborhoodDto
                          {
                              Neighborhood = gr.Key.Name,
                              Type = gr.Key.NeighborhoodEntityType.ToString(),
                              NumberOfAddressType = gr.Count()
                          }).PaginatedListAsync(request.PageNumber, request.PageSize);

            return results;
        }
    }
}
