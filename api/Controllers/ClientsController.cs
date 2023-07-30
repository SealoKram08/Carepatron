using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services.IServices;
using api.Models.Dto;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientServices _clientServices;

        public ClientsController(IClientServices clientServices)
        {
            this._clientServices = clientServices;
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var clients = await _clientServices.SearchByName(name);

            return Ok(clients);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientServices.GetAll();

            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientDto client)
        {
            try
            {
                if (ModelState.IsValid) {

                   await _clientServices.Create(client);
                }

                return Ok(client);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new client record");
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, ClientDto client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != client.Id)
                    {
                        return BadRequest();
                    }

                    var result = await _clientServices.Update(client);

                    if (!result)
                        return NotFound();
                }

                return Ok(client);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new client record");
            }
        }
    }
}
