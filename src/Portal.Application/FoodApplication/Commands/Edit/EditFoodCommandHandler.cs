using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Domain;
using Portal.Domain.Common;
using Portal.Persisatance;

namespace Portal.Application.FoodApplication.Commands.Edit
{
    public class EditFoodCommandHandler : IRequestHandler<EditFoodCommand, int>
    {
        private readonly PortalDbContext db;

        public EditFoodCommandHandler(PortalDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Handle(EditFoodCommand request, CancellationToken cancellationToken)
        {
            var food = new Food
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                FoodType = request.FoodType,
                Description = request.Description
            };

            db.Entry(food).State = EntityState.Modified;
            db.Entry(food.Price).State = EntityState.Modified;

            //db.Foods.Update(food);
            await db.SaveChangesAsync();
            return food.Id;
        }
    }
}