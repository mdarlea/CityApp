using MediatR;

namespace City.Application.NeighborhoodEntities.Commands.CreateNeighborhoodEntity
{
    public abstract class CreateNeighborhoodEntityCommand : IRequest<int>
    {
        public int NeighborhoodId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string PostalCode {get; set; } = string.Empty;
    }
}
