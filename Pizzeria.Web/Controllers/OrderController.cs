using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizzeria.Core.Dtos.OrderDtos;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper, IOrderService service)
        {
            _mapper = mapper;
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders([FromQuery] OrderParameters orderParameters)
        {
            var allOrders = _service.GetAllOrdersPaged(orderParameters);
            var allOrdersReadDto = _mapper.Map<IEnumerable<OrderReadDto>>(allOrders);
            
            var metadata = new
            {
                allOrders.TotalCount,
                allOrders.PageSize,
                allOrders.CurrentPage,
                allOrders.TotalPages,
                allOrders.HasNext,
                allOrders.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(allOrdersReadDto);
        }
        
        [HttpGet("{id}",Name = "GetOrderById")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var order = _service.GetOrderById(id);
            if (order is null)
            {
                return NotFound();
            }
            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderReadDto);
        }
        
        [HttpPost]
        public ActionResult<OrderReadDto> CreateOrder(OrderCreateDto createDto)
        {
            var orderModel = _mapper.Map<Order>(createDto);
            //var promotionalCodeToCheck = createDto.PromotionalCode;
            _service.AddOrder(orderModel);

            //TODO на случай если нужно вернуть полный обьект
            //orderModel = _service.GetorderById(orderModel.Id);
            
            var orderReadDto = _mapper.Map<OrderReadDto>(orderModel);
            return CreatedAtRoute(nameof(GetOrderById), new { Id = orderReadDto.Id }, orderReadDto);
        }
        [HttpPatch("{id}")]
        public ActionResult PatchOrder(int id, JsonPatchDocument<OrderUpdateDto> patchDoc)
        {
            var orderModel = _service.GetOrderById(id);
            if (orderModel is null)
            {
                return NotFound();
            }
            
            var orderToPatch = _mapper.Map<OrderUpdateDto>(orderModel);
            patchDoc.ApplyTo(orderToPatch, ModelState);
            
            if(!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            _mapper.Map(orderToPatch, orderModel);
            _service.UpdateOrder(orderModel);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var orderModel = _service.GetOrderById(id);
            if (orderModel is null)
            {
                return NotFound();
            }
            _service.RemoveOrder(orderModel);
            return NoContent();
        }
    }
}