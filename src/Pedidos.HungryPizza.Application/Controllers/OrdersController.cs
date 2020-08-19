using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces.Services;

namespace Pedidos.HungryPizza.Application.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("hungrypizza/Orders")]
        public async Task<ActionResult> GetOrders() 
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { return Ok(await service.GetAll()); }
            catch (ArgumentException e) { return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); }
        }
        
        [HttpPost]
        [Route("hungrypizza/Orders")]
        public async Task<ActionResult> Order([FromBody] OrderDto order)
        {
            if (!ModelState.IsValid) { return  BadRequest(ModelState); }

            try { return Ok(await service.Create(order)); }
            catch (ArgumentException e) { return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); }
        }

        [HttpPost]
        [Route("hungrypizza/Checkout/{id}")]
        public ActionResult CheckOut(long id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try 
            {
                var order = service.Get(id);
                service.CheckOut(order.Result); 
                return Ok("Success"); 
            }
            catch (ArgumentException e) { return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); }
        }
                
        [HttpGet]
        [Route("hungrypizza/ClientHistory/{id}")]
        public async Task<ActionResult> ClientOrders(long id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { return Ok(await service.GetOrdersHistoryByClient(id)); }
            catch (ArgumentException e) { return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); }
        }
    }
}