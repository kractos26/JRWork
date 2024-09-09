using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TipoPersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<TipoPersonaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TipoPersonaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipoPersonaController>
        [HttpPost]
        public async Task<ActionResult<Response<TipoPersonaDto>>> Post(Registrar.TipoPersonaRegisterCommand tipoperRegister)
        {
            Response<TipoPersonaDto> respon;
            try
            {
                TipoPersonaDto area = await _mediator.Send(tipoperRegister);
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
                respon = new Response<TipoPersonaDto>()
                {
                    Entidad = new TipoPersonaDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }


        // PUT api/<TipoPersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoPersonaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
