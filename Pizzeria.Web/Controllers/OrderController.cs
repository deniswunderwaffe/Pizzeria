using System.Collections.Generic;
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Core.Dtos.OrderDtos;
using Pizzeria.Core.Dtos.PizzaDtos;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;
using Pizzeria.Infrastructure.Data;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<OrderReadDto> GetAllOrders()
        {
            var orders = _orderService.GetAllOrdersIncludingAllDetails();
            var mappedResult = _mapper.Map<IEnumerable<OrderReadDto>>(orders);

            return Ok(mappedResult);
        }
        [HttpGet("{id}",Name = "GetOrderById")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var order = _orderService.GetOrderByIdIncludingAllDetails(id);
            if (order is null)
            {
                return NotFound();
            }
            var mappedResult = _mapper.Map<OrderReadDto>(order);
            return Ok(mappedResult);
        }
        [HttpPatch("{id}")]
        public ActionResult PatchOrder(int id, JsonPatchDocument<OrderUpdateDto> patchDoc)
        {
            
            var orderFromDb = _orderService.GetOrderByIdIncludingAllDetails(id);
            if (orderFromDb is null)
            {
                return NotFound();
            }
           
            var orderToPatch = _mapper.Map<OrderUpdateDto>(orderFromDb);
            patchDoc.ApplyTo(orderToPatch, ModelState);
            if(!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(orderToPatch, orderFromDb);
            
            _orderService.UpdateOrder(orderFromDb);
            
            return NoContent();
        }
    }
}