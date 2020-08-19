using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Interfaces.Services;

namespace Application.Controllers
{
    [Route("hungrypizza/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService service;

        public ItemsController(IItemService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] List<ItemDto> itemsDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try 
            {
                await service.Save(itemsDto);                               
                return Ok(); 
            }
            catch (ArgumentException e) { return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); }
        }
    }
}