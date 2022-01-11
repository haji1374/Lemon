using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Foods;
using Portal.Application.Foods.Models;
using MediatR;
using Portal.Application.FoodApplication.Commands;
using Portal.Application.FoodApplication.Query.FindById;
using Portal.Application.FoodApplication.Query.FindAll;
using Portal.Application.FoodApplication.Commands.Create;
using Portal.Application.FoodApplication.Commands.Edit;

namespace Portal.Web.Controllers
{
    [ApiController]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IMediator madiator;
        public FoodController(IFoodService foodService, IMediator madiator)
        {
            this.madiator = madiator;
            _foodService = foodService;
        }

        [HttpGet]
        [Route("api/food")]
        public async Task<IActionResult> FindAll()
        {
            var result = await madiator.Send(new FindAllFoodQuery()
            {
            });

            return Ok(result);
        }

        [HttpGet]
        [Route("api/food/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await madiator.Send(new FindByIdFoodQuery()
            {
                id = id
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("api/food")]
        public async Task<IActionResult> Create(FoodAddInfo model)
        {
            var result = await madiator.Send(new CreateFoodCommand()
            {
                Description = model.Description,
                FoodType = model.FoodType,
                Name = model.Name,
                Price = new Domain.Common.Money(model.Price)
            });

            return Ok(result);
        }


        [HttpPut]
        [Route("api/food")]
        public async Task<IActionResult> Edit(FoodEditInfo model)
        {
            var result = await madiator.Send(new EditFoodCommand()
            {
                Description = model.Description,
                FoodType = model.FoodType,
                Name = model.Name,
                Price = new Domain.Common.Money(model.Price),
                Id = model.Id
            });

            return Ok(result);
        }
    }
}