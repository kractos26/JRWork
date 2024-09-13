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
                TipoPersonaDto TipoPersona = await _mediator.Send(command);
                respon = new()
                {
                    Entidad = TipoPersona,
                    Mensaje = "TipoPersona actualizada correctamente",
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

        // DELETE api/<TipoPersonaController>/5
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

                response.Mensaje = "TipoPersona elimiminada correctamenta";
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

        [HttpGet]
        public async Task<ActionResult<Response<List<TipoPersonaDto>>>> Get()
        {
            Response<List<TipoPersonaDto>> response = new();
            try
            {

                Buscar.TipoPersonaBuscarTodoCommand command = new()
                {

                };

                List<TipoPersonaDto> TipoPersonaDtos = await _mediator.Send(command);

                response.Mensaje = "TipoPersona elimiminada correctamenta";
                response.Entidad = TipoPersonaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new List<TipoPersonaDto>(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response<TipoPersonaDto>>> Get(int id)
        {
            Response<TipoPersonaDto> response = new();
            try
            {

                Buscar.TipoPersonaBuscarIdCommand command = new()
                {
                    TipoPersonaId = id
                };

                TipoPersonaDto TipoPersonaDtos = await _mediator.Send(command);

                response.Mensaje = "TipoPersona elimiminada correctamenta";
                response.Entidad = TipoPersonaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new TipoPersonaDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<Response<TipoPersonaDto>>> Get(Buscar.TipoPersonaBuscarIdCommand command)
        {
            Response<TipoPersonaDto> response = new();
            try
            {

                TipoPersonaDto TipoPersonaDtos = await _mediator.Send(command);

                response.Mensaje = "";
                response.Entidad = TipoPersonaDtos;
                response.Status = System.Net.HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Entidad = new TipoPersonaDto(),
                    Mensaje = ex.Message,
                    Status = System.Net.HttpStatusCode.BadRequest

                };
                return BadRequest(response);
            }
        }
    }
}
