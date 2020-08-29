using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoBack.DTOs;
using ToDoBack.Helper;
using ToDoBack.Services;

namespace ToDoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ToDosController : ControllerBase
    {
        private readonly IToDosService _toDosService;
        public ToDosController(IToDosService toDosService)
        {
            _toDosService = toDosService;
        }


        //Post:api/ToDos/Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]ToDosAddDto model)
        {
            
            var result =await _toDosService.ToDosAdd(model);

            if (result.Message != ApiResultMessages.Ok)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //Get:api/ToDos/Get
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _toDosService.ToDosGet();

            return Ok(result);
        }

        //Delete: api/ToDos/Delete/id
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _toDosService.ToDosDelete(id);
            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
