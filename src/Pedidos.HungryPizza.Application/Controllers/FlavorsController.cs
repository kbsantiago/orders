using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces.Services;

namespace Application.Controllers
{
    [Route("hungrypizza/[controller]")]
    [ApiController]
    public class FlavorsController : ControllerBase
    {
        private readonly IFlavorService service;

        public FlavorsController(IFlavorService service)
        {
            this.service = service;
        }

        public async Task<ActionResult> GetOrders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}