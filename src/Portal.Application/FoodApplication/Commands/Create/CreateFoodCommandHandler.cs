using System.Threading;
using System.Threading.Tasks;
using Portal.Persisatance;
using MediatR;
using Portal.Domain.Common;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, int>
    {
        private readonly PortalDbContext db;

        public CreateFoodCommandHandler(PortalDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var entity = db.Foods.Add(new Domain.Food()
            {
                Description = request.Description,
                FoodType = request.FoodType,
                Name = request.Name,
                Price = request.Price
            });

            await db.SaveChangesAsync();
            return entity.Entity.Id;
        }
    }
}