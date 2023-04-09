using City.Application.Common.Interfaces;
using City.Domain.Entities.NeighborhoodEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace City.Application.NeighborhoodEntities.Commands.CreateNeighborhoodEntity
{
    public class CreateBoulevardCommand : CreateNeighborhoodEntityCommand
    {
    }

    public class CreateBoulevardCommandHandler : IRequestHandler<CreateBoulevardCommand, int>
    {
        private readonly ICityContext context;

        public CreateBoulevardCommandHandler(ICityContext context) 
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(CreateBoulevardCommand request, CancellationToken cancellationToken)
        {
            var neighborhood = context.Neighborhoods.Include(n => n.Boulevards).FirstOrDefault(n => n.Id == request.NeighborhoodId);
            if (neighborhood == null) 
            {
                throw new NullReferenceException($"Cannot find neighborhood {request.NeighborhoodId}");
            }

            var boulevard = new Boulevard(request.Name, request.PostalCode);
            neighborhood.AddBoulevard(boulevard);

            await context.SaveChangesAsync(cancellationToken);

            return boulevard.Id;


        }
    }
}
