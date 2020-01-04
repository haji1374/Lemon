﻿using MediatR;
using Portal.Application.Common;
using Portal.Domain;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.OrderApplication.Commands
{
    public class OrderCreateCommandHandler :
        IRequestHandler<OrderCreateCommand, OperationResult<OrderCreateCommandResult>>
    {
        private readonly PortalDbContext _db;
        private readonly IMediator _mediator;

        public OrderCreateCommandHandler(PortalDbContext db, IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        public async Task<OperationResult<OrderCreateCommandResult>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var order = new Order { State = OrderState.New, TimeCreated = DateTime.Now, UserId = request.UserId };
            order.Items = new List<OrderItem>();
            _db.Orders.Add(order);
            var foods = _db.Foods.ToList();
            //var orderItems = new List<OrderItem>();
            foreach (var item in request.Items)
            {
                var food = foods.Single(f => f.Id == item.FoodId);
                //orderItems.Add();
                order.Items.Add(new OrderItem
                {
                    FoodId = item.FoodId,
                    Count = item.Count,
                    OrderId = order.Id,
                    UnitPrice = food.Price.Value,
                    TotalPrice = food.Price.Value * item.Count
                });
            }
            //order.Items.AddRange(orderItems);
            //await _mediator.Publish(new OrderCreatedNotification());

            var result = OperationResult<OrderCreateCommandResult>
               .BuildSuccessResult(new OrderCreateCommandResult
               {
                   OrderId = order.Id
               });
            await Task.CompletedTask;
            return result;

        }
    }
}