using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Foods.Models;
using Portal.Domain;
using Portal.Persisatance;

namespace Portal.Application.FoodApplication.Query.FindAll
{
    public class FindAllFoodQueryHandler : IRequestHandler<FindAllFoodQuery, IList<FoodInfo>>
    {
        private readonly PortalDbContext _db;
        private readonly IMapper _mapper;

        public FindAllFoodQueryHandler(PortalDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IList<FoodInfo>> Handle(FindAllFoodQuery request, CancellationToken cancellationToken)
        {
            var model = await _db.Foods.ToListAsync();

            return model.Select(_mapper.Map<Food, FoodInfo>).ToList();
        }
    }
}