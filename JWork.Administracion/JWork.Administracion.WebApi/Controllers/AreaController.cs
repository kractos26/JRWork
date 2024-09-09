using JWork.Administracion.Business.Aplicacion.Area;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AreaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<AreaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AreaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AreaController>
        [HttpPost]
        public async Task<ActionResult<Response<AreaDto>>> Post(Registrar.AreaRegisterCommand areaRegister)
        {
            Response<AreaDto> respon;
            try
            {
                AreaDto area = await _mediator.Send(areaRegister);
                respon = new()
                {
                    Entidad = area,
                    Mensaje = "Area creada correctamente",
                    Status = System.Net.HttpStatusCode.Created
                };
                return Ok(respon);
            }
            catch (Exception ex)
            {
                respon = new Response<AreaDto>()
                {
                    Entidad = new AreaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }
        // PUT api/<AreaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AreaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
