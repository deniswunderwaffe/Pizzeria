using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizzeria.Core.Dtos.CustomerDtos;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, ICustomerService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<IEnumerable<CustomerReadDto>> GetAllCustomers(
            [FromQuery] CustomerParameters customerParameters)
        {
            var allCustomers = _service.GetAllCustomersPaged(customerParameters);
            var allCustomersReadDto = _mapper.Map<IEnumerable<CustomerReadDto>>(allCustomers);

            var metadata = new
            {
                allCustomers.TotalCount,
                allCustomers.PageSize,
                allCustomers.CurrentPage,
                allCustomers.TotalPages,
                allCustomers.HasNext,
                allCustomers.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(allCustomersReadDto);
        }

        //[Authorize("use:everything")]
        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult<CustomerReadDto> GetCustomerById(int id)
        {
            var customer = _service.GetCustomerById(id);
            if (customer is null) return NotFound();
            var customerReadDto = _mapper.Map<CustomerReadDto>(customer);
            return Ok(customerReadDto);
        }

        [HttpPost]
        public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto createDto)
        {
            var customerModel = _mapper.Map<Customer>(createDto);
            _service.AddCustomer(customerModel);

            var customerReadDto = _mapper.Map<CustomerReadDto>(customerModel);
            return CreatedAtRoute(nameof(GetCustomerById), new { Id = customerReadDto.Id }, customerReadDto);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchCustomer(int id, JsonPatchDocument<CustomerUpdateDto> patchDoc)
        {
            var customerModel = _service.GetCustomerById(id);
            if (customerModel is null) return NotFound();

            var customerToPatch = _mapper.Map<CustomerUpdateDto>(customerModel);
            patchDoc.ApplyTo(customerToPatch, ModelState);

            if (!TryValidateModel(customerToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(customerToPatch, customerModel);
            _service.UpdateCustomer(customerModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerModel = _service.GetCustomerById(id);
            if (customerModel is null) return NotFound();
            _service.RemoveCustomer(customerModel);
            return NoContent();
        }
    }
}