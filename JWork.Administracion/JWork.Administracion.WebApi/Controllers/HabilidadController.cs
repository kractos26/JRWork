using JWork.Administracion.Business.Aplicacion.Habilidad;
using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWork.Administracion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HabilidadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<HabilidadController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HabilidadController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult<Response<Dto.HabilidadDto>>> Post(Registrar.HabilidadRegisterCommand habilidadRegister)
        {
            Response<Dto.HabilidadDto> respon;
            try
            {
                Dto.HabilidadDto area = await _mediator.Send(habilidadRegister);
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
                respon = new Response<Dto.HabilidadDto>()
                {
                    Entidad = new Dto.HabilidadDto() { },
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(respon);
            }

        }

        // PUT api/<HabilidadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HabilidadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
