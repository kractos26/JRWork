using JWork.Administracion.Dto;
using JWork.Administracion.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JWork.Administracion.Business.Aplicacion.TipoPersona;
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

        [HttpPut]
        public async Task<ActionResult<Response<TipoPersonaDto>>> Put(Registrar.TipoPersonaUpdateCommand command)
        {
            Response<TipoPersonaDto> respon;
            try
            {
                TipoPersonaDto TipoIdentificacion = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = TipoIdentificacion,
                    Mensaje = "TipoIdentificacion actualizada correctamente",
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

        // DELETE api/<TipoIdentificacionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            Response<bool> response = new();
            try
            {

                Registrar.TipoPersonaEliminarCommand command = new()
                {
                    TipoPersonaId = id
                };

                bool exitoso = await _mediator.Send(command);

                response.Mensaje = "TipoIdentificacion elimiminada correctamenta";
                response.Entidad = exitoso;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = false,
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }
    }
}
