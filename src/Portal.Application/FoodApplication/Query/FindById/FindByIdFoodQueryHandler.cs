using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portal.Application.Foods.Models;
using Portal.Domain;
using Portal.Persisatance;

namespace Portal.Application.FoodApplication.Query.FindById
{
    public class FindByIdFoodQueryHandler : IRequestHandler<FindByIdFoodQuery, FoodInfo>
    {
        private readonly PortalDbContext _db;
        private readonly IMapper _mapper;

        public FindByIdFoodQueryHandler(PortalDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<FoodInfo> Handle(FindByIdFoodQuery request, CancellationToken cancellationToken)
        {
            var model = await _db.Foods.FindAsync(request.id);
            return _mapper.Map<Food, FoodInfo>(model);
        }
    }
}