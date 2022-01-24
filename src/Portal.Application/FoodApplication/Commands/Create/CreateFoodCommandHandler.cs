using System.Threading;
using System.Threading.Tasks;
using Portal.Persisatance;
using MediatR;
using Portal.Domain.Common;
using Portal.Application.FoodApplication.Commands.Create.Notifications;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, int>
    {
        private readonly PortalDbContext db;
        private readonly IMediator mediator;

        public CreateFoodCommandHandler(PortalDbContext db, IMediator mediator)
        {
            this.mediator = mediator;
            this.db = db;
        }

        public async Task<int> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.Foods.AddAsync(new Domain.Food()
            {
                Description = request.Description,
                FoodType = request.FoodType,
                Name = request.Name,
                Price = request.Price
            });

            await mediator.Publish(new CreateFoodCommandNotification() { Message = "For First test" });

            // await db.SaveChangesAsync();
            return entity.Entity.Id;
        }
    }
}