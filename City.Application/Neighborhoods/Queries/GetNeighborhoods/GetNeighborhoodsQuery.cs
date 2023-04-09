using AutoMapper;
using AutoMapper.QueryableExtensions;
using City.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace City.Application.Neighborhoods.Queries.GetNeighborhoods
{
    public class GetNeighborhoodsQuery : IRequest<List<NeighborhoodDto>>
    {
    }

    public class GetNeighborhoodsQueryHandler : IRequestHandler<GetNeighborhoodsQuery, List<NeighborhoodDto>>
    {
        private readonly ICityContext context;
        private readonly IMapper mapper;

        public GetNeighborhoodsQueryHandler(ICityContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<NeighborhoodDto>> Handle(GetNeighborhoodsQuery request, CancellationToken cancellationToken)
        {
            return await context.Neighborhoods.OrderBy(n => n.Name).ProjectTo<NeighborhoodDto>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
